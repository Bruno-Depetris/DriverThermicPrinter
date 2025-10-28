using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DriverThermicPrinter.Forms.Notificacion {
    public partial class msj : Form {
        public msj() {
            InitializeComponent();
            ConfigurarEstiloModerno();
        }

        #region Importaciones Win32
        [System.Runtime.InteropServices.DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);
        #endregion

        #region Variables
        private int posicionX, posicionY;
        private int ScreenWidth = Screen.PrimaryScreen.Bounds.Width;
        private int ScreenHeight = Screen.PrimaryScreen.Bounds.Height;
        private int contador = 0;
        private bool estado = true;
        private const int TIEMPO_VISIBLE = 300;
        private const int VELOCIDAD_ANIMACION = 5;
        #endregion

        #region Enums
        public enum TipoNotificacion {
            Exito,
            Error,
            Advertencia,
            Informacion,
            Dinero,
            Admin,
            BaseDatos,
            Buscar,
            Editar,
            Eliminar,
            Producto
        }

        public enum TipoSonido {
            Confirmacion = 1,
            Error = 2,
            Intermedio = 3,
            Money = 4,
            Start = 5,
            Archive = 6,
            Simple = 7,
            PopTres = 8,
            Silencio = 9
        }
        #endregion

        #region Rutas de Recursos
        private readonly Dictionary<string, string> RutasIconos = new Dictionary<string, string> {
            ["error"] = Path.Combine(Application.StartupPath, "Public/Img", "error.png"),
            ["ok"] = Path.Combine(Application.StartupPath, "Public/Img", "check.png"),
            ["cash"] = Path.Combine(Application.StartupPath, "Public/Img", "forex_trade_chart_stock.png"),
            ["admin"] = Path.Combine(Application.StartupPath, "Public/Img", "admin.png"),
            ["bd"] = Path.Combine(Application.StartupPath, "Public/Img", "bd.png"),
            ["buscar"] = Path.Combine(Application.StartupPath, "Public/Img", "buscar.png"),
            ["edit"] = Path.Combine(Application.StartupPath, "Public/Img", "edit.png"),
            ["delete"] = Path.Combine(Application.StartupPath, "Public/Img", "delete.png"),
            ["producto"] = Path.Combine(Application.StartupPath, "Public/Img", "zapatillas.png")
        };

        private readonly Dictionary<string, string> RutasSonidos = new Dictionary<string, string> {
            ["pop1"] = Path.Combine(Application.StartupPath, "Public/Song", "pop-1-269287.wav"),
            ["money"] = Path.Combine(Application.StartupPath, "Public/Song", "Money.wav"),
            ["pop3"] = Path.Combine(Application.StartupPath, "Public/Song", "pop-sound-effect-226110.wav"),
            ["start"] = Path.Combine(Application.StartupPath, "Public/Song", "start-13691.wav"),
            ["archive"] = Path.Combine(Application.StartupPath, "Public/Song", "achive-sound-132273.wav"),
            ["simple"] = Path.Combine(Application.StartupPath, "Public/Song", "simple-notification-152054.wav"),
            ["ui"] = Path.Combine(Application.StartupPath, "Public/Song", "ui-3-sound-effect-warn-242229.wav"),
            ["error"] = Path.Combine(Application.StartupPath, "Public/Song", "error-126627.wav")
        };
        #endregion

        #region Configuración de Estilos
        private void ConfigurarEstiloModerno() {
            this.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            this.BackColor = Color.FromArgb(245, 248, 252);
        }

        private struct ConfiguracionNotificacion {
            public string IconoKey;
            public Color ColorBarra;
            public string SonidoKey;
        }

        private readonly Dictionary<TipoNotificacion, ConfiguracionNotificacion> Configuraciones = new Dictionary<TipoNotificacion, ConfiguracionNotificacion> {
            [TipoNotificacion.Exito] = new ConfiguracionNotificacion {
                IconoKey = "ok",
                ColorBarra = Color.FromArgb(76, 175, 80),
                SonidoKey = "pop1"
            },
            [TipoNotificacion.Error] = new ConfiguracionNotificacion {
                IconoKey = "error",
                ColorBarra = Color.FromArgb(244, 67, 54),
                SonidoKey = "error"
            },
            [TipoNotificacion.Advertencia] = new ConfiguracionNotificacion {
                IconoKey = "error",
                ColorBarra = Color.FromArgb(255, 152, 0),
                SonidoKey = "ui"
            },
            [TipoNotificacion.Informacion] = new ConfiguracionNotificacion {
                IconoKey = "ok",
                ColorBarra = Color.FromArgb(33, 150, 243),
                SonidoKey = "simple"
            },
            [TipoNotificacion.Dinero] = new ConfiguracionNotificacion {
                IconoKey = "cash",
                ColorBarra = Color.FromArgb(76, 175, 80),
                SonidoKey = "money"
            },
            [TipoNotificacion.Admin] = new ConfiguracionNotificacion {
                IconoKey = "admin",
                ColorBarra = Color.FromArgb(156, 39, 176),
                SonidoKey = "start"
            },
            [TipoNotificacion.BaseDatos] = new ConfiguracionNotificacion {
                IconoKey = "bd",
                ColorBarra = Color.FromArgb(33, 150, 243),
                SonidoKey = "archive"
            },
            [TipoNotificacion.Buscar] = new ConfiguracionNotificacion {
                IconoKey = "buscar",
                ColorBarra = Color.FromArgb(103, 58, 183),
                SonidoKey = "simple"
            },
            [TipoNotificacion.Editar] = new ConfiguracionNotificacion {
                IconoKey = "edit",
                ColorBarra = Color.FromArgb(255, 193, 7),
                SonidoKey = "pop3"
            },
            [TipoNotificacion.Eliminar] = new ConfiguracionNotificacion {
                IconoKey = "delete",
                ColorBarra = Color.FromArgb(244, 67, 54),
                SonidoKey = "error"
            },
            [TipoNotificacion.Producto] = new ConfiguracionNotificacion {
                IconoKey = "producto",
                ColorBarra = Color.FromArgb(0, 150, 136),
                SonidoKey = "pop1"
            }
        };
        #endregion

        #region Métodos Públicos Simplificados
        /// <summary>
        /// Muestra una notificación con configuración automática según el tipo
        /// </summary>
        public void Mostrar(string titulo, string mensaje, TipoNotificacion tipo = TipoNotificacion.Informacion) {
            if (Configuraciones.TryGetValue(tipo, out ConfiguracionNotificacion config)) {
                MostrarNotificacion(titulo, mensaje, config);
            }
        }

        /// <summary>
        /// Muestra una notificación personalizada
        /// </summary>
        public void MostrarPersonalizada(string titulo, string mensaje, Color colorBarra, string rutaIcono, TipoSonido sonido = TipoSonido.Simple) {
            label_Titulo.Text = titulo;
            label_Mensaje.Text = mensaje;
            panel_Color.BackColor = Color.FromArgb(120, colorBarra);

            CargarIcono(rutaIcono);
            ReproducirSonidoPorTipo(sonido);

            this.Show();
        }
        #endregion

        #region Métodos Privados
        private void MostrarNotificacion(string titulo, string mensaje, ConfiguracionNotificacion config) {
            label_Titulo.Text = titulo;
            label_Mensaje.Text = mensaje;
            panel_Color.BackColor = Color.FromArgb(120, config.ColorBarra);

            if (RutasIconos.TryGetValue(config.IconoKey, out string rutaIcono)) {
                CargarIcono(rutaIcono);
            }

            if (RutasSonidos.TryGetValue(config.SonidoKey, out string rutaSonido)) {
                ReproducirSonido(rutaSonido);
            }

            this.Show();
        }

        private void CargarIcono(string rutaIcono) {
            try {
                if (File.Exists(rutaIcono)) {
                    parrotPictureBox_ImagenNot.Image = RedondearImagen(Image.FromFile(rutaIcono));
                }
            } catch (Exception ex) {
                Console.WriteLine($"Error al cargar ícono: {ex.Message}");
            }
        }

        private void ReproducirSonidoPorTipo(TipoSonido tipo) {
            string sonidoKey;
            switch (tipo) {
                case TipoSonido.Confirmacion:
                    sonidoKey = "pop1";
                    break;
                case TipoSonido.Error:
                    sonidoKey = "error";
                    break;
                case TipoSonido.Intermedio:
                    sonidoKey = "ui";
                    break;
                case TipoSonido.Money:
                    sonidoKey = "money";
                    break;
                case TipoSonido.Start:
                    sonidoKey = "start";
                    break;
                case TipoSonido.Archive:
                    sonidoKey = "archive";
                    break;
                case TipoSonido.Simple:
                    sonidoKey = "simple";
                    break;
                case TipoSonido.PopTres:
                    sonidoKey = "pop3";
                    break;
                default:
                    sonidoKey = "simple";
                    break;
            }

            if (tipo != TipoSonido.Silencio && RutasSonidos.TryGetValue(sonidoKey, out string rutaSonido)) {
                ReproducirSonido(rutaSonido);
            }
        }

        private void ReproducirSonido(string rutaArchivo) {
            try {
                if (File.Exists(rutaArchivo)) {
                    using (var player = new System.Media.SoundPlayer(rutaArchivo)) {
                        player.Play();
                    }
                }
            } catch (Exception ex) {
                Console.WriteLine($"Error al reproducir sonido: {ex.Message}");
            }
        }

        private Image RedondearImagen(Image img) {
            Bitmap bmp = new Bitmap(img.Width, img.Height);
            using (Graphics g = Graphics.FromImage(bmp)) {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (GraphicsPath path = new GraphicsPath()) {
                    path.AddEllipse(0, 0, img.Width, img.Height);
                    g.SetClip(path);
                    g.DrawImage(img, 0, 0, img.Width, img.Height);
                }
            }
            return bmp;
        }
        #endregion

        #region Animación y Timer
        private void timer_Muestra_Tick(object sender, EventArgs e) {
            if (!estado) {
                if (posicionY >= ScreenHeight - this.Height - 30) {
                    posicionY -= VELOCIDAD_ANIMACION;
                } else {
                    estado = true;
                    contador = TIEMPO_VISIBLE;
                }
            } else {
                contador--;

                if (contador <= 100 && contador >= 0) {
                    posicionY += VELOCIDAD_ANIMACION;

                    if (posicionY >= ScreenHeight) {
                        CerrarNotificacion();
                    }
                }
            }

            this.Location = new Point(posicionX, posicionY);
        }

        private void CerrarNotificacion() {
            timer_Muestra.Stop();
            timer_Muestra.Dispose();
            this.Close();
        }

        private void Mensaje_Load(object sender, EventArgs e) {
            InicializarPosicion();
        }

        private void InicializarPosicion() {
            posicionY = ScreenHeight - this.Height;
            posicionX = ScreenWidth - this.Width - 30;
            this.Location = new Point(posicionX, ScreenHeight);
            timer_Muestra.Start();
            estado = false;
        }
        #endregion

        #region Renderizado
        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);

            using (Pen pen = new Pen(Color.FromArgb(40, 0, 0, 0), 1)) {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.DrawPath(pen, GetRoundedRectPath(new Rectangle(1, 1, Width - 3, Height - 3), 18));
            }
        }

        private GraphicsPath GetRoundedRectPath(Rectangle bounds, int radius) {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(bounds.X, bounds.Y, radius, radius, 180, 90);
            path.AddArc(bounds.Right - radius, bounds.Y, radius, radius, 270, 90);
            path.AddArc(bounds.Right - radius, bounds.Bottom - radius, radius, radius, 0, 90);
            path.AddArc(bounds.X, bounds.Bottom - radius, radius, radius, 90, 90);
            path.CloseFigure();
            return path;
        }
        #endregion
    }
}