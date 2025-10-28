using System;
using System.IO;
using System.Windows.Forms;

namespace DriverThermicPrinter {
    public class ConfigurarPuerto {
        private static ConfigurarPuerto _instancia;
        public static ConfigurarPuerto Instancia {
            get {
                if (_instancia == null)
                    _instancia = new ConfigurarPuerto();
                return _instancia;
            }
        }

        private readonly string path;
        string appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

        public int[] Puertos = new int[] { 49152, 50000, 55000, 60000, 65000 };
        public int PuertoServidor { get; private set; }

        private ConfigurarPuerto() {
            path = Path.Combine(appData, "DriverThermicPrinter", "config.txt");
            ComprobarArchivo();
            PuertoServidor = LeerPuerto();
        }

        private void ComprobarArchivo() {
            if (!File.Exists(path)) {
                Console.WriteLine("Archivo de configuración no encontrado. Creando...");

                // Crear el directorio si no existe
                string directorio = Path.GetDirectoryName(path);
                if (!Directory.Exists(directorio)) {
                    Directory.CreateDirectory(directorio);
                }

                File.WriteAllText(path, "PORT=55000");
            }
        }

        public int LeerPuerto() {
            try {
                string[] lineas = File.ReadAllLines(path);
                foreach (string linea in lineas) {
                    if (linea.StartsWith("PORT=")) {
                        if (int.TryParse(linea.Replace("PORT=", "").Trim(), out int puerto)) {
                            PuertoServidor = puerto;
                            return puerto;
                        }
                    }
                }
            } catch (Exception ex) {
                Console.WriteLine("Error al leer el puerto: " + ex.Message);
            }

            // Solo si NO se encontró o hubo error
            PuertoServidor = 55000;
            return PuertoServidor;
        }

        public void CambiarPuerto(int nuevoPuerto) {
            try {
                // Asegurar que el directorio existe
                string directorio = Path.GetDirectoryName(path);
                if (!Directory.Exists(directorio)) {
                    Directory.CreateDirectory(directorio);
                }

                File.WriteAllText(path, $"PORT={nuevoPuerto}");
                PuertoServidor = nuevoPuerto;
                Console.WriteLine("Puerto cambiado a: " + nuevoPuerto);
            } catch (Exception ex) {
                Console.WriteLine("Error al cambiar el puerto: " + ex.Message);
            }
        }
    }
}
