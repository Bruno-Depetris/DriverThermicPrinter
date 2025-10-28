using DriverThermicPrinter.Forms;
using DriverThermicPrinter.Forms.Notificacion;
using System;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DriverThermicPrinter {
    public class PrinterServer {
        private readonly HttpListener listener;
        private bool running = false;
        private Form_Configurar formConfiguracion;

        public PrinterServer(int port, Form_Configurar configurar) {
            listener = new HttpListener();
            listener.Prefixes.Add($"http://localhost:{port}/");
            formConfiguracion = configurar;
        }

        public void Start() {
            running = true;
            listener.Start();
            Task.Run(() => Loop());
        }

        public void Stop() {
            running = false;
            listener.Stop();
        }

        private async Task Loop() {
            while (running) {
                try {
                    var coneccion = await listener.GetContextAsync();

                    coneccion.Response.AddHeader("Access-Control-Allow-Origin", "*");
                    coneccion.Response.AddHeader("Access-Control-Allow-Methods", "GET, POST, OPTIONS");
                    coneccion.Response.AddHeader("Access-Control-Allow-Headers", "Content-Type");

                    // Manejar preflight OPTIONS
                    if (coneccion.Request.HttpMethod == "OPTIONS") {
                        coneccion.Response.StatusCode = 200;
                        coneccion.Response.Close();
                        continue;
                    }

                    string body;

                    using (var reader = new StreamReader(coneccion.Request.InputStream, Encoding.UTF8)) {
                        body = await reader.ReadToEndAsync();
                    }

                    if (coneccion.Request.HttpMethod == "POST" && coneccion.Request.Url.AbsolutePath == "/print") {
                        bool success = Print(body);

                        string jsonResponse = success ?
                            "{\"status\":\"ok\",\"message\":\"Impresión enviada correctamente\"}" :
                            "{\"status\":\"error\",\"message\":\"Error al imprimir\"}";

                        byte[] responseBytes = Encoding.UTF8.GetBytes(jsonResponse);
                        coneccion.Response.ContentType = "application/json";
                        coneccion.Response.StatusCode = success ? 200 : 500;
                        coneccion.Response.OutputStream.Write(responseBytes, 0, responseBytes.Length);
                    } else if (coneccion.Request.HttpMethod == "GET" && coneccion.Request.Url.AbsolutePath == "/status") {
                        string impresora = formConfiguracion?.ObtenerImpresoraSeleccionada() ?? "No configurada";
                        string jsonStatus = $"{{\"status\":\"running\",\"printer\":\"{impresora}\"}}";

                        byte[] statusBytes = Encoding.UTF8.GetBytes(jsonStatus);
                        coneccion.Response.ContentType = "application/json";
                        coneccion.Response.OutputStream.Write(statusBytes, 0, statusBytes.Length);
                    } else {
                        coneccion.Response.StatusCode = 404;
                        byte[] notFound = Encoding.UTF8.GetBytes("{\"status\":\"error\",\"message\":\"Endpoint no encontrado\"}");
                        coneccion.Response.OutputStream.Write(notFound, 0, notFound.Length);
                    }

                    coneccion.Response.Close();

                } catch (Exception ex) {
                    msj mensaje = new msj();

                    
                    System.Diagnostics.Debug.WriteLine($"Error en servidor: {ex.Message}");
                }
            }
        }


        private bool Print(string text) {
            try {
                PrintDocument doc = new PrintDocument();

                if (formConfiguracion != null) {
                    doc.PrinterSettings.PrinterName = formConfiguracion.ObtenerImpresoraSeleccionada();
                }

                doc.PrintPage += (s, e) => {
                    try {
                        Font fuente = formConfiguracion?.ObtenerFuenteConfiguracion() ?? new Font("Consolas", 10);

                        float margenIzquierdo = 0;
                        float margenSuperior = 0;
                        float anchoMaximo = e.PageBounds.Width - ( margenIzquierdo * 2 );

                        RectangleF area = new RectangleF(margenIzquierdo, margenSuperior, anchoMaximo, e.PageBounds.Height);
                        StringFormat formato = new StringFormat {
                            Alignment = StringAlignment.Near,
                            LineAlignment = StringAlignment.Near
                        };

                        e.Graphics.DrawString(text, fuente, Brushes.Black, area, formato);
                    } catch (Exception ex) {
                        System.Diagnostics.Debug.WriteLine($"Error al dibujar: {ex.Message}");
                    }
                };

                doc.Print();
                return true;
            } catch (Exception ex) {
                System.Diagnostics.Debug.WriteLine($"Error al imprimir: {ex.Message}");
                return false;
            }
        }
    }
}