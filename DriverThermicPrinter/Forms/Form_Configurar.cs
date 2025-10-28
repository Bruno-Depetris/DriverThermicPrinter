using DriverThermicPrinter.Forms.Notificacion;
using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;
using static DriverThermicPrinter.Forms.Notificacion.msj;

namespace DriverThermicPrinter.Forms {
    public partial class Form_Configurar : Form {

        // Configuración actual
        private string impresoraSeleccionada = "";
        private string tipografiaSeleccionada = "Consolas";
        private int tamañoLetraSeleccionado = 10;
        public event Action<int> OnPuertoCambiado;
        public Form_Configurar() {
            InitializeComponent();
            InicializarFormulario();

    
         }

// Corrección de nomenclatura y argumento requerido
        private void ComboBoxPuertos() {
            // Limpiar primero los elementos existentes
            poisonComboBox_PuertosDisponibles.Items.Clear();

            // Recorrer los puertos y agregarlos al ComboBox
            for (int i = 0; i < ConfigurarPuerto.Instancia.Puertos.Length; i++) {
                poisonComboBox_PuertosDisponibles.Items.Add(ConfigurarPuerto.Instancia.Puertos[i]);
            }
        }

        private void InicializarFormulario() {
            CargarImpresoras();
            ComboBoxPuertos();
            CargarTipografias();

            CargarTamañosLetra();

            CargarConfiguracion();

            ConfigurarEventos();

            labelEdit_PuertoActivo.Text = Convert.ToString(ConfigurarPuerto.Instancia.LeerPuerto());
        }

        #region Carga Inicial

        private void CargarImpresoras() {
            try {
                poisonDataGridView_Impresoras.Rows.Clear();

                foreach (string printer in PrinterSettings.InstalledPrinters) {
                    int rowIndex = poisonDataGridView_Impresoras.Rows.Add();
                    poisonDataGridView_Impresoras.Rows[rowIndex].Cells["Column_Impresora"].Value = printer;

                    PrinterSettings settings = new PrinterSettings();
                    if (printer == settings.PrinterName) {
                        poisonDataGridView_Impresoras.Rows[rowIndex].DefaultCellStyle.BackColor = Color.FromArgb(230, 235, 255);
                    }
                }

                if (poisonDataGridView_Impresoras.Rows.Count == 0) {
                    MostrarNotificacion("Advertencia", "No se encontraron impresoras instaladas", TipoNotificacion.Advertencia);
                }
            } catch (Exception ex) {
                MostrarNotificacion("Error", $"Error al cargar impresoras: {ex.Message}", TipoNotificacion.Error);
            }
        }

        private void CargarTipografias() {
            string[] fuentesRecomendadas = new string[] {
                "Consolas",
                "Courier New",
                "Lucida Console",
                "Arial",
                "Segoe UI",
                "Calibri",
                "Times New Roman",
                "Verdana"
            };

            poisonComboBox_Tipografia.Items.Clear();

            foreach (string fuente in fuentesRecomendadas) {
                if (IsFuenteDisponible(fuente)) {
                    poisonComboBox_Tipografia.Items.Add(fuente);
                }
            }

            poisonComboBox_Tipografia.SelectedIndex = 0;
        }

        private void CargarTamañosLetra() {
            int[] tamaños = new int[] { 6, 7, 8, 9, 10, 11, 12, 14, 16, 18, 20, 24 };

            poisonComboBox_TamañoLetra.Items.Clear();

            foreach (int tamaño in tamaños) {
                poisonComboBox_TamañoLetra.Items.Add($"{tamaño} pt");
            }

            poisonComboBox_TamañoLetra.SelectedIndex = 4; // 10 pt por defecto
        }

        private bool IsFuenteDisponible(string nombreFuente) {
            using (var testFont = new Font(nombreFuente, 10, FontStyle.Regular, GraphicsUnit.Pixel)) {
                return testFont.Name == nombreFuente;
            }
        }

        #endregion

        #region Configuración y Guardado

        private void CargarConfiguracion() {
            try {
                impresoraSeleccionada = Properties.Settings.Default.ImpresoraSeleccionada;
                tipografiaSeleccionada = Properties.Settings.Default.Tipografia;
                tamañoLetraSeleccionado = Properties.Settings.Default.TamañoLetra;

                // Actualizar UI
                ActualizarImpresoraSeleccionada();

                if (!string.IsNullOrEmpty(tipografiaSeleccionada)) {
                    poisonComboBox_Tipografia.SelectedItem = tipografiaSeleccionada;
                }

                if (tamañoLetraSeleccionado > 0) {
                    poisonComboBox_TamañoLetra.SelectedItem = $"{tamañoLetraSeleccionado} pt";
                }
            } catch {
                // Si hay error, usar valores por defecto
                tipografiaSeleccionada = "Consolas";
                tamañoLetraSeleccionado = 10;
            }
        }

        private void GuardarConfiguracion() {
            try {
                Properties.Settings.Default.ImpresoraSeleccionada = impresoraSeleccionada;
                Properties.Settings.Default.Tipografia = tipografiaSeleccionada;
                Properties.Settings.Default.TamañoLetra = tamañoLetraSeleccionado;
                Properties.Settings.Default.Save();

                MostrarNotificacion("Éxito", "Configuración guardada correctamente", TipoNotificacion.Exito);
            } catch (Exception ex) {
                MostrarNotificacion("Error", $"Error al guardar configuración: {ex.Message}", TipoNotificacion.Error);
            }
        }

        #endregion

        #region Eventos

        private void ConfigurarEventos() {
            // Evento para seleccionar impresora
            poisonDataGridView_Impresoras.CellClick += PoisonDataGridView_Impresoras_CellClick;

            // Eventos de ComboBox
            poisonComboBox_Tipografia.SelectedIndexChanged += PoisonComboBox_Tipografia_SelectedIndexChanged;
            poisonComboBox_TamañoLetra.SelectedIndexChanged += PoisonComboBox_TamañoLetra_SelectedIndexChanged;
        }

        private void PoisonDataGridView_Impresoras_CellClick(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex >= 0) {
                // Obtener el nombre de la impresora
                string nombreImpresora = poisonDataGridView_Impresoras.Rows[e.RowIndex].Cells["Column_Impresora"].Value?.ToString();

                if (!string.IsNullOrEmpty(nombreImpresora)) {
                    // Si hace clic en la columna de selección
                    if (e.ColumnIndex == poisonDataGridView_Impresoras.Columns["Column_Select"].Index) {
                        SeleccionarImpresora(nombreImpresora);
                    }
                }
            }
        }

        private void SeleccionarImpresora(string nombreImpresora) {
            try {
                PrinterSettings settings = new PrinterSettings();
                settings.PrinterName = nombreImpresora;

                if (settings.IsValid) {
                    impresoraSeleccionada = nombreImpresora;
                    ActualizarImpresoraSeleccionada();
                    GuardarConfiguracion();

                    // Resaltar fila seleccionada
                    foreach (DataGridViewRow row in poisonDataGridView_Impresoras.Rows) {
                        if (row.Cells["Column_Impresora"].Value?.ToString() == nombreImpresora) {
                            row.DefaultCellStyle.BackColor = Color.FromArgb(230, 235, 255);
                        } else {
                            row.DefaultCellStyle.BackColor = Color.White;
                        }
                    }

                    MostrarNotificacion("Impresora Seleccionada", $"Ahora imprimirás en: {nombreImpresora}", TipoNotificacion.Informacion);
                } else {
                    MostrarNotificacion("Error", "La impresora seleccionada no es válida", TipoNotificacion.Error);
                }
            } catch (Exception ex) {
                MostrarNotificacion("Error", $"Error al seleccionar impresora: {ex.Message}", TipoNotificacion.Error);
            }
        }

        private void ActualizarImpresoraSeleccionada() {
            if (string.IsNullOrEmpty(impresoraSeleccionada)) {
                labelEdit_ImpresoraSeleccionada.Text = "Ninguna seleccionada...";
                labelEdit_ImpresoraSeleccionada.ForeColor = Color.FromArgb(114, 118, 127);
            } else {
                labelEdit_ImpresoraSeleccionada.Text = impresoraSeleccionada;
                labelEdit_ImpresoraSeleccionada.ForeColor = Color.FromArgb(100, 120, 255);
            }
        }

        private void PoisonComboBox_Tipografia_SelectedIndexChanged(object sender, EventArgs e) {
            if (poisonComboBox_Tipografia.SelectedItem != null) {
                tipografiaSeleccionada = poisonComboBox_Tipografia.SelectedItem.ToString();
                GuardarConfiguracion();
            }
        }

        private void PoisonComboBox_TamañoLetra_SelectedIndexChanged(object sender, EventArgs e) {
            if (poisonComboBox_TamañoLetra.SelectedItem != null) {
                string tamaño = poisonComboBox_TamañoLetra.SelectedItem.ToString().Replace(" pt", "");
                if (int.TryParse(tamaño, out int valor)) {
                    tamañoLetraSeleccionado = valor;
                    GuardarConfiguracion();
                }
            }
        }

        #endregion

        #region Métodos Públicos para PrinterServer

        public string ObtenerImpresoraSeleccionada() {
            return string.IsNullOrEmpty(impresoraSeleccionada) ?
                new PrinterSettings().PrinterName : impresoraSeleccionada;
        }

        public Font ObtenerFuenteConfiguracion() {
            return new Font(tipografiaSeleccionada, tamañoLetraSeleccionado);
        }

        #endregion

        #region Notificaciones

        private void MostrarNotificacion(string titulo, string mensaje, TipoNotificacion tipo) {
            msj notificacion = new msj();
            notificacion.Mostrar(titulo, mensaje, tipo);
        }

        #endregion

        #region Eventos del Form

        private void Form_Configurar_FormClosed(object sender, FormClosedEventArgs e) {
            this.Hide();

            // Prevenir el cierre completo
            if (e.CloseReason == CloseReason.UserClosing) {
                // No hacer nada adicional, solo ocultar
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e) {
            //si el usuario cierra el formulario, solo ocultarlo
            if (e.CloseReason == CloseReason.UserClosing) {
                e.Cancel = true;
                this.Hide();
            } else {
                base.OnFormClosing(e);
            }
        }

        #endregion

        private void poisonDataGridView_Impresoras_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void poisonComboBox_Tipografia_SelectedIndexChanged(object sender, EventArgs e) { }
        private void poisonComboBox_TamañoLetra_SelectedIndexChanged(object sender, EventArgs e) { }
        private void groupBox_ImpresoraActual_Enter(object sender, EventArgs e) { }

        private void groupBox1_Enter(object sender, EventArgs e) {

        }


        private void panelHeader_Paint(object sender, PaintEventArgs e) {

        }

        private void hopeButton_CambiarPuerto_Click(object sender, EventArgs e) {

            int nuevoPuerto = 0;    
           
            MessageBox.Show($"Puerto cambiado a {nuevoPuerto}. Servidor reiniciado.",
                "Puerto Actualizado", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (poisonComboBox_PuertosDisponibles.Text != null) {
                ConfigurarPuerto.Instancia.CambiarPuerto(Convert.ToInt32(poisonComboBox_PuertosDisponibles.Text));
                nuevoPuerto = Convert.ToInt32(poisonComboBox_PuertosDisponibles.Text);
                MostrarNotificacion("EXITO", "puerto cambiado con exito", TipoNotificacion.Exito);
                labelEdit_PuertoActivo.Text = Convert.ToString(ConfigurarPuerto.Instancia.LeerPuerto());
                OnPuertoCambiado?.Invoke(nuevoPuerto);
                return;
            }

            MostrarNotificacion("Error", "No se puede cambiar el puerto", TipoNotificacion.Error);

        }
    }
}