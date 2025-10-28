using DriverThermicPrinter.Forms;
using DriverThermicPrinter.Forms.Notificacion;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DriverThermicPrinter {
    public class TrayAppContext : ApplicationContext {
        private NotifyIcon trayIcon;
        private PrinterServer server;
        private Form_Configurar formConfigurar;

        public int PUERTO_SERVIDOR = ConfigurarPuerto.Instancia.LeerPuerto();

        public TrayAppContext(Form_Configurar configurar) {
            // Asegurarse de asignar la instancia antes de suscribirse al evento para evitar NullReferenceException.
            formConfigurar = configurar ?? throw new ArgumentNullException(nameof(configurar));
            formConfigurar.OnPuertoCambiado += ReiniciarServidorConNuevoPuerto;

            ConfigurarTrayIcon();

            IniciarServidor();

            MostrarNotificacionInicio();
        }

        private void ReiniciarServidorConNuevoPuerto(int nuevoPuerto) {
            try {
                // Detener servidor actual
                server?.Stop();

                // Actualizar puerto
                PUERTO_SERVIDOR = nuevoPuerto;

                // Iniciar con nuevo puerto
                server = new PrinterServer(PUERTO_SERVIDOR, formConfigurar);
                server.Start();

                // Mostrar notificación si el tray icon existe
                trayIcon?.ShowBalloonTip(3000,
                    "Puerto Actualizado",
                    $"Servidor reiniciado en puerto {PUERTO_SERVIDOR}",
                    ToolTipIcon.Info);

            } catch (Exception ex) {
                MessageBox.Show($"Error al cambiar puerto: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void ConfigurarTrayIcon() {
            try {
                string rutaIcono = System.IO.Path.Combine(Application.StartupPath, "Assets", "predits.ico");

                trayIcon = new NotifyIcon() {
                    Icon = System.IO.File.Exists(rutaIcono) ?
                        new Icon(rutaIcono) :
                        SystemIcons.Application,
                    Text = "Agente Impresión BY PREDITS",
                    Visible = true
                };

                ContextMenu menu = new ContextMenu(new MenuItem[] {
                    new MenuItem("🖨️ Configurar Impresora", ConfigurarFrom),
                    new MenuItem("-"), // Separador
                    new MenuItem("📁 Abrir Carpeta", AbrirCarpeta),
                    new MenuItem("ℹ️ Acerca de", MostrarAcercaDe),
                    new MenuItem("-"), // Separador
                    new MenuItem("❌ Salir", Exit)
                });

                trayIcon.ContextMenu = menu;

                trayIcon.DoubleClick += (s, e) => ConfigurarFrom(s, e);
            } catch (Exception ex) {
                MessageBox.Show($"Error al configurar icono de bandeja: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void IniciarServidor() {
            try {
                MessageBox.Show($"Iniciando servidor en puerto: {PUERTO_SERVIDOR}"); // ← AGREGA ESTO
                server = new PrinterServer(PUERTO_SERVIDOR, formConfigurar);
                server.Start();
            } catch (Exception ex) {
                MessageBox.Show($"Error al iniciar servidor en puerto {PUERTO_SERVIDOR}: {ex.Message}",
                    "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private void MostrarNotificacionInicio() {
            trayIcon?.ShowBalloonTip(3000,
                "Printer Driver Iniciado",
                $"Servidor escuchando en puerto {PUERTO_SERVIDOR}\nHaz clic derecho para configurar",
                ToolTipIcon.Info);
        }

        #region Eventos del menu

        private void ConfigurarFrom(object sender, EventArgs e) {
            try {
                if (formConfigurar.Visible) {
                    formConfigurar.Focus();
                    formConfigurar.BringToFront();
                } else {
                    formConfigurar.Show();
                    formConfigurar.BringToFront();
                }
            } catch (Exception ex) {
                MessageBox.Show($"Error al abrir configuración: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AbrirCarpeta(object sender, EventArgs e) {
            try {
                System.Diagnostics.Process.Start("explorer.exe", AppDomain.CurrentDomain.BaseDirectory);
            } catch (Exception ex) {
                MessageBox.Show($"Error al abrir carpeta: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarAcercaDe(object sender, EventArgs e) {
            string mensaje = "Printer Driver Manager v1.0\n\n" +
                           "Desarrollado por: Predits\n" +
                           $"Puerto: {PUERTO_SERVIDOR}\n\n" +
                           "Sistema de gestión de impresoras térmicas\n" +
                           "para integración con aplicaciones web.";

            MessageBox.Show(mensaje, "Acerca de Printer Driver",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Exit(object sender, EventArgs e) {
            DialogResult resultado = MessageBox.Show(
                "¿Está seguro que desea cerrar el agente de impresión?\n\n" +
                "Las aplicaciones no podrán imprimir hasta que la vuelva a iniciar nuevamente.",
                "Confirmar Salida",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes) {
                try {
                    trayIcon.Visible = false;
                    server?.Stop();
                    formConfigurar?.Dispose();
                    Application.Exit();
                } catch (Exception ex) {
                    MessageBox.Show($"Error al cerrar: {ex.Message}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
            }
        }

        #endregion

        protected override void Dispose(bool disposing) {
            if (disposing) {
                // Desuscribirse del evento para evitar referencias colgantes
                if (formConfigurar != null) {
                    try {
                        formConfigurar.OnPuertoCambiado -= ReiniciarServidorConNuevoPuerto;
                    } catch {
                        // Ignorar si la desuscripción falla por cualquier motivo
                    }
                }

                trayIcon?.Dispose();
                server?.Stop();
            }
            base.Dispose(disposing);
        }
    }
}