namespace DriverThermicPrinter.Forms {
    partial class Form_Configurar {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && ( components != null )) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Configurar));
            this.airForm1 = new ReaLTaiizor.Forms.AirForm();
            this.panelPrincipal = new System.Windows.Forms.Panel();
            this.panelDerecho = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.poisonComboBox_PuertosDisponibles = new ReaLTaiizor.Controls.PoisonComboBox();
            this.hopeButton_CambiarPuerto = new ReaLTaiizor.Controls.HopeButton();
            this.labelEdit_PuertoActivo = new ReaLTaiizor.Controls.LabelEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox_Configuracion = new System.Windows.Forms.GroupBox();
            this.label_TamañoLetra = new System.Windows.Forms.Label();
            this.label_Tipografia = new System.Windows.Forms.Label();
            this.poisonComboBox_TamañoLetra = new ReaLTaiizor.Controls.PoisonComboBox();
            this.poisonComboBox_Tipografia = new ReaLTaiizor.Controls.PoisonComboBox();
            this.groupBox_ImpresoraActual = new System.Windows.Forms.GroupBox();
            this.labelEdit_ImpresoraSeleccionada = new ReaLTaiizor.Controls.LabelEdit();
            this.poisonLabel_ImpresoraActual = new ReaLTaiizor.Controls.PoisonLabel();
            this.panelIzquierdo = new System.Windows.Forms.Panel();
            this.poisonDataGridView_Impresoras = new ReaLTaiizor.Controls.PoisonDataGridView();
            this.Column_Impresora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Select = new System.Windows.Forms.DataGridViewImageColumn();
            this.bigLabel_Impresoras = new ReaLTaiizor.Controls.BigLabel();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.nightControlBox1 = new ReaLTaiizor.Controls.NightControlBox();
            this.nightLabel_SubTitulo = new ReaLTaiizor.Controls.NightLabel();
            this.bigLabel_Titulo = new ReaLTaiizor.Controls.BigLabel();
            this.crownDockPanel_Separador = new ReaLTaiizor.Docking.Crown.CrownDockPanel();
            this.airForm1.SuspendLayout();
            this.panelPrincipal.SuspendLayout();
            this.panelDerecho.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox_Configuracion.SuspendLayout();
            this.groupBox_ImpresoraActual.SuspendLayout();
            this.panelIzquierdo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.poisonDataGridView_Impresoras)).BeginInit();
            this.panelHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // airForm1
            // 
            this.airForm1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.airForm1.BorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.airForm1.Controls.Add(this.panelPrincipal);
            this.airForm1.Controls.Add(this.panelHeader);
            this.airForm1.Controls.Add(this.crownDockPanel_Separador);
            this.airForm1.Customization = "AAAA/1paWv9ycnL/";
            this.airForm1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.airForm1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.airForm1.Image = null;
            this.airForm1.Location = new System.Drawing.Point(0, 0);
            this.airForm1.MinimumSize = new System.Drawing.Size(900, 550);
            this.airForm1.Movable = true;
            this.airForm1.Name = "airForm1";
            this.airForm1.NoRounding = false;
            this.airForm1.Sizable = true;
            this.airForm1.Size = new System.Drawing.Size(900, 575);
            this.airForm1.SmartBounds = true;
            this.airForm1.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.airForm1.TabIndex = 0;
            this.airForm1.Text = "Printer Driver Manager - Configuración";
            this.airForm1.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.airForm1.Transparent = false;
            // 
            // panelPrincipal
            // 
            this.panelPrincipal.Controls.Add(this.panelDerecho);
            this.panelPrincipal.Controls.Add(this.panelIzquierdo);
            this.panelPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPrincipal.Location = new System.Drawing.Point(0, 106);
            this.panelPrincipal.Name = "panelPrincipal";
            this.panelPrincipal.Padding = new System.Windows.Forms.Padding(20);
            this.panelPrincipal.Size = new System.Drawing.Size(900, 469);
            this.panelPrincipal.TabIndex = 4;
            // 
            // panelDerecho
            // 
            this.panelDerecho.Controls.Add(this.groupBox1);
            this.panelDerecho.Controls.Add(this.groupBox_Configuracion);
            this.panelDerecho.Controls.Add(this.groupBox_ImpresoraActual);
            this.panelDerecho.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDerecho.Location = new System.Drawing.Point(420, 20);
            this.panelDerecho.Name = "panelDerecho";
            this.panelDerecho.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.panelDerecho.Size = new System.Drawing.Size(460, 429);
            this.panelDerecho.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox1.Controls.Add(this.poisonComboBox_PuertosDisponibles);
            this.groupBox1.Controls.Add(this.hopeButton_CambiarPuerto);
            this.groupBox1.Controls.Add(this.labelEdit_PuertoActivo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(70)))));
            this.groupBox1.Location = new System.Drawing.Point(15, 248);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(15, 10, 15, 15);
            this.groupBox1.Size = new System.Drawing.Size(445, 154);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "🔌 Configurar Puerto";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // poisonComboBox_PuertosDisponibles
            // 
            this.poisonComboBox_PuertosDisponibles.FormattingEnabled = true;
            this.poisonComboBox_PuertosDisponibles.ItemHeight = 23;
            this.poisonComboBox_PuertosDisponibles.Location = new System.Drawing.Point(21, 61);
            this.poisonComboBox_PuertosDisponibles.Name = "poisonComboBox_PuertosDisponibles";
            this.poisonComboBox_PuertosDisponibles.PromptText = "Selecciona un puerto...";
            this.poisonComboBox_PuertosDisponibles.Size = new System.Drawing.Size(400, 29);
            this.poisonComboBox_PuertosDisponibles.TabIndex = 4;
            this.poisonComboBox_PuertosDisponibles.UseSelectable = true;
            // 
            // hopeButton_CambiarPuerto
            // 
            this.hopeButton_CambiarPuerto.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(223)))), ((int)(((byte)(230)))));
            this.hopeButton_CambiarPuerto.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            this.hopeButton_CambiarPuerto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.hopeButton_CambiarPuerto.DangerColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
            this.hopeButton_CambiarPuerto.DefaultColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.hopeButton_CambiarPuerto.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.hopeButton_CambiarPuerto.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(49)))), ((int)(((byte)(51)))));
            this.hopeButton_CambiarPuerto.InfoColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(147)))), ((int)(((byte)(153)))));
            this.hopeButton_CambiarPuerto.Location = new System.Drawing.Point(156, 105);
            this.hopeButton_CambiarPuerto.Name = "hopeButton_CambiarPuerto";
            this.hopeButton_CambiarPuerto.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.hopeButton_CambiarPuerto.Size = new System.Drawing.Size(120, 40);
            this.hopeButton_CambiarPuerto.SuccessColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(194)))), ((int)(((byte)(58)))));
            this.hopeButton_CambiarPuerto.TabIndex = 4;
            this.hopeButton_CambiarPuerto.Text = "Cambiar";
            this.hopeButton_CambiarPuerto.TextColor = System.Drawing.Color.White;
            this.hopeButton_CambiarPuerto.WarningColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(162)))), ((int)(((byte)(60)))));
            this.hopeButton_CambiarPuerto.Click += new System.EventHandler(this.hopeButton_CambiarPuerto_Click);
            // 
            // labelEdit_PuertoActivo
            // 
            this.labelEdit_PuertoActivo.AutoSize = true;
            this.labelEdit_PuertoActivo.BackColor = System.Drawing.Color.Transparent;
            this.labelEdit_PuertoActivo.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.labelEdit_PuertoActivo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(120)))), ((int)(((byte)(255)))));
            this.labelEdit_PuertoActivo.Location = new System.Drawing.Point(111, 41);
            this.labelEdit_PuertoActivo.Name = "labelEdit_PuertoActivo";
            this.labelEdit_PuertoActivo.Size = new System.Drawing.Size(87, 19);
            this.labelEdit_PuertoActivo.TabIndex = 2;
            this.labelEdit_PuertoActivo.Text = "Cargando...";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(90)))));
            this.label2.Location = new System.Drawing.Point(18, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Puerto activo:";
            // 
            // groupBox_Configuracion
            // 
            this.groupBox_Configuracion.Controls.Add(this.label_TamañoLetra);
            this.groupBox_Configuracion.Controls.Add(this.label_Tipografia);
            this.groupBox_Configuracion.Controls.Add(this.poisonComboBox_TamañoLetra);
            this.groupBox_Configuracion.Controls.Add(this.poisonComboBox_Tipografia);
            this.groupBox_Configuracion.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox_Configuracion.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.groupBox_Configuracion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(70)))));
            this.groupBox_Configuracion.Location = new System.Drawing.Point(15, 63);
            this.groupBox_Configuracion.Name = "groupBox_Configuracion";
            this.groupBox_Configuracion.Padding = new System.Windows.Forms.Padding(15, 10, 15, 15);
            this.groupBox_Configuracion.Size = new System.Drawing.Size(445, 185);
            this.groupBox_Configuracion.TabIndex = 1;
            this.groupBox_Configuracion.TabStop = false;
            this.groupBox_Configuracion.Text = "⚙️ Configuración de Impresión";
            // 
            // label_TamañoLetra
            // 
            this.label_TamañoLetra.AutoSize = true;
            this.label_TamañoLetra.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label_TamañoLetra.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(90)))));
            this.label_TamañoLetra.Location = new System.Drawing.Point(18, 110);
            this.label_TamañoLetra.Name = "label_TamañoLetra";
            this.label_TamañoLetra.Size = new System.Drawing.Size(117, 17);
            this.label_TamañoLetra.TabIndex = 3;
            this.label_TamañoLetra.Text = "Tamaño de la letra";
            // 
            // label_Tipografia
            // 
            this.label_Tipografia.AutoSize = true;
            this.label_Tipografia.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label_Tipografia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(90)))));
            this.label_Tipografia.Location = new System.Drawing.Point(18, 45);
            this.label_Tipografia.Name = "label_Tipografia";
            this.label_Tipografia.Size = new System.Drawing.Size(93, 17);
            this.label_Tipografia.TabIndex = 2;
            this.label_Tipografia.Text = "Tipo de fuente";
            // 
            // poisonComboBox_TamañoLetra
            // 
            this.poisonComboBox_TamañoLetra.FormattingEnabled = true;
            this.poisonComboBox_TamañoLetra.ItemHeight = 23;
            this.poisonComboBox_TamañoLetra.Location = new System.Drawing.Point(21, 135);
            this.poisonComboBox_TamañoLetra.Name = "poisonComboBox_TamañoLetra";
            this.poisonComboBox_TamañoLetra.PromptText = "Seleccione el tamaño...";
            this.poisonComboBox_TamañoLetra.Size = new System.Drawing.Size(400, 29);
            this.poisonComboBox_TamañoLetra.TabIndex = 1;
            this.poisonComboBox_TamañoLetra.UseSelectable = true;
            this.poisonComboBox_TamañoLetra.SelectedIndexChanged += new System.EventHandler(this.poisonComboBox_TamañoLetra_SelectedIndexChanged);
            // 
            // poisonComboBox_Tipografia
            // 
            this.poisonComboBox_Tipografia.FormattingEnabled = true;
            this.poisonComboBox_Tipografia.ItemHeight = 23;
            this.poisonComboBox_Tipografia.Location = new System.Drawing.Point(21, 70);
            this.poisonComboBox_Tipografia.Name = "poisonComboBox_Tipografia";
            this.poisonComboBox_Tipografia.PromptText = "Seleccione la tipografía...";
            this.poisonComboBox_Tipografia.Size = new System.Drawing.Size(400, 29);
            this.poisonComboBox_Tipografia.TabIndex = 0;
            this.poisonComboBox_Tipografia.UseSelectable = true;
            this.poisonComboBox_Tipografia.SelectedIndexChanged += new System.EventHandler(this.poisonComboBox_Tipografia_SelectedIndexChanged);
            // 
            // groupBox_ImpresoraActual
            // 
            this.groupBox_ImpresoraActual.Controls.Add(this.labelEdit_ImpresoraSeleccionada);
            this.groupBox_ImpresoraActual.Controls.Add(this.poisonLabel_ImpresoraActual);
            this.groupBox_ImpresoraActual.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox_ImpresoraActual.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.groupBox_ImpresoraActual.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(70)))));
            this.groupBox_ImpresoraActual.Location = new System.Drawing.Point(15, 0);
            this.groupBox_ImpresoraActual.Name = "groupBox_ImpresoraActual";
            this.groupBox_ImpresoraActual.Padding = new System.Windows.Forms.Padding(15, 10, 15, 15);
            this.groupBox_ImpresoraActual.Size = new System.Drawing.Size(445, 63);
            this.groupBox_ImpresoraActual.TabIndex = 0;
            this.groupBox_ImpresoraActual.TabStop = false;
            this.groupBox_ImpresoraActual.Text = "🖨️ Impresora Activa";
            this.groupBox_ImpresoraActual.Enter += new System.EventHandler(this.groupBox_ImpresoraActual_Enter);
            // 
            // labelEdit_ImpresoraSeleccionada
            // 
            this.labelEdit_ImpresoraSeleccionada.AutoSize = true;
            this.labelEdit_ImpresoraSeleccionada.BackColor = System.Drawing.Color.Transparent;
            this.labelEdit_ImpresoraSeleccionada.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.labelEdit_ImpresoraSeleccionada.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(120)))), ((int)(((byte)(255)))));
            this.labelEdit_ImpresoraSeleccionada.Location = new System.Drawing.Point(153, 29);
            this.labelEdit_ImpresoraSeleccionada.Name = "labelEdit_ImpresoraSeleccionada";
            this.labelEdit_ImpresoraSeleccionada.Size = new System.Drawing.Size(167, 19);
            this.labelEdit_ImpresoraSeleccionada.TabIndex = 1;
            this.labelEdit_ImpresoraSeleccionada.Text = "Ninguna seleccionada...";
            // 
            // poisonLabel_ImpresoraActual
            // 
            this.poisonLabel_ImpresoraActual.AutoSize = true;
            this.poisonLabel_ImpresoraActual.Location = new System.Drawing.Point(18, 35);
            this.poisonLabel_ImpresoraActual.Name = "poisonLabel_ImpresoraActual";
            this.poisonLabel_ImpresoraActual.Size = new System.Drawing.Size(0, 0);
            this.poisonLabel_ImpresoraActual.TabIndex = 0;
            // 
            // panelIzquierdo
            // 
            this.panelIzquierdo.Controls.Add(this.poisonDataGridView_Impresoras);
            this.panelIzquierdo.Controls.Add(this.bigLabel_Impresoras);
            this.panelIzquierdo.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelIzquierdo.Location = new System.Drawing.Point(20, 20);
            this.panelIzquierdo.Name = "panelIzquierdo";
            this.panelIzquierdo.Padding = new System.Windows.Forms.Padding(0, 0, 15, 0);
            this.panelIzquierdo.Size = new System.Drawing.Size(400, 429);
            this.panelIzquierdo.TabIndex = 0;
            // 
            // poisonDataGridView_Impresoras
            // 
            this.poisonDataGridView_Impresoras.AllowUserToAddRows = false;
            this.poisonDataGridView_Impresoras.AllowUserToResizeRows = false;
            this.poisonDataGridView_Impresoras.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.poisonDataGridView_Impresoras.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.poisonDataGridView_Impresoras.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.poisonDataGridView_Impresoras.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(120)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(120)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.poisonDataGridView_Impresoras.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.poisonDataGridView_Impresoras.ColumnHeadersHeight = 35;
            this.poisonDataGridView_Impresoras.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_Impresora,
            this.Column_Select});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(90)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(235)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.poisonDataGridView_Impresoras.DefaultCellStyle = dataGridViewCellStyle2;
            this.poisonDataGridView_Impresoras.Dock = System.Windows.Forms.DockStyle.Fill;
            this.poisonDataGridView_Impresoras.EnableHeadersVisualStyles = false;
            this.poisonDataGridView_Impresoras.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.poisonDataGridView_Impresoras.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(245)))));
            this.poisonDataGridView_Impresoras.Location = new System.Drawing.Point(0, 52);
            this.poisonDataGridView_Impresoras.Name = "poisonDataGridView_Impresoras";
            this.poisonDataGridView_Impresoras.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.poisonDataGridView_Impresoras.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.poisonDataGridView_Impresoras.RowHeadersVisible = false;
            this.poisonDataGridView_Impresoras.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.poisonDataGridView_Impresoras.RowTemplate.Height = 40;
            this.poisonDataGridView_Impresoras.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.poisonDataGridView_Impresoras.Size = new System.Drawing.Size(385, 377);
            this.poisonDataGridView_Impresoras.TabIndex = 1;
            this.poisonDataGridView_Impresoras.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.poisonDataGridView_Impresoras_CellContentClick);
            // 
            // Column_Impresora
            // 
            this.Column_Impresora.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column_Impresora.HeaderText = "Nombre de Impresora";
            this.Column_Impresora.Name = "Column_Impresora";
            this.Column_Impresora.ReadOnly = true;
            // 
            // Column_Select
            // 
            this.Column_Select.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column_Select.HeaderText = "Seleccionar";
            this.Column_Select.Image = ((System.Drawing.Image)(resources.GetObject("Column_Select.Image")));
            this.Column_Select.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.Column_Select.Name = "Column_Select";
            this.Column_Select.ReadOnly = true;
            this.Column_Select.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column_Select.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column_Select.Width = 110;
            // 
            // bigLabel_Impresoras
            // 
            this.bigLabel_Impresoras.AutoSize = true;
            this.bigLabel_Impresoras.BackColor = System.Drawing.Color.Transparent;
            this.bigLabel_Impresoras.Dock = System.Windows.Forms.DockStyle.Top;
            this.bigLabel_Impresoras.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.bigLabel_Impresoras.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(70)))));
            this.bigLabel_Impresoras.Location = new System.Drawing.Point(0, 0);
            this.bigLabel_Impresoras.Name = "bigLabel_Impresoras";
            this.bigLabel_Impresoras.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.bigLabel_Impresoras.Size = new System.Drawing.Size(319, 52);
            this.bigLabel_Impresoras.TabIndex = 0;
            this.bigLabel_Impresoras.Text = "📋 Impresoras Disponibles";
            // 
            // panelHeader
            // 
            this.panelHeader.Controls.Add(this.nightControlBox1);
            this.panelHeader.Controls.Add(this.nightLabel_SubTitulo);
            this.panelHeader.Controls.Add(this.bigLabel_Titulo);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 1);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Padding = new System.Windows.Forms.Padding(20, 15, 20, 10);
            this.panelHeader.Size = new System.Drawing.Size(900, 105);
            this.panelHeader.TabIndex = 3;
            this.panelHeader.Paint += new System.Windows.Forms.PaintEventHandler(this.panelHeader_Paint);
            // 
            // nightControlBox1
            // 
            this.nightControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nightControlBox1.BackColor = System.Drawing.Color.Transparent;
            this.nightControlBox1.CloseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.nightControlBox1.CloseHoverForeColor = System.Drawing.Color.White;
            this.nightControlBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.nightControlBox1.DefaultLocation = true;
            this.nightControlBox1.DisableMaximizeColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.nightControlBox1.DisableMinimizeColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.nightControlBox1.EnableCloseColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.nightControlBox1.EnableMaximizeButton = false;
            this.nightControlBox1.EnableMaximizeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.nightControlBox1.EnableMinimizeButton = false;
            this.nightControlBox1.EnableMinimizeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.nightControlBox1.Location = new System.Drawing.Point(761, 0);
            this.nightControlBox1.MaximizeHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.nightControlBox1.MaximizeHoverForeColor = System.Drawing.Color.White;
            this.nightControlBox1.MinimizeHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.nightControlBox1.MinimizeHoverForeColor = System.Drawing.Color.White;
            this.nightControlBox1.Name = "nightControlBox1";
            this.nightControlBox1.Size = new System.Drawing.Size(139, 31);
            this.nightControlBox1.TabIndex = 2;
            // 
            // nightLabel_SubTitulo
            // 
            this.nightLabel_SubTitulo.AutoSize = true;
            this.nightLabel_SubTitulo.BackColor = System.Drawing.Color.Transparent;
            this.nightLabel_SubTitulo.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.nightLabel_SubTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(118)))), ((int)(((byte)(127)))));
            this.nightLabel_SubTitulo.Location = new System.Drawing.Point(23, 70);
            this.nightLabel_SubTitulo.Name = "nightLabel_SubTitulo";
            this.nightLabel_SubTitulo.Size = new System.Drawing.Size(390, 17);
            this.nightLabel_SubTitulo.TabIndex = 1;
            this.nightLabel_SubTitulo.Text = "Administre sus impresoras y configure las opciones de impresión";
            // 
            // bigLabel_Titulo
            // 
            this.bigLabel_Titulo.AutoSize = true;
            this.bigLabel_Titulo.BackColor = System.Drawing.Color.Transparent;
            this.bigLabel_Titulo.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.bigLabel_Titulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.bigLabel_Titulo.Location = new System.Drawing.Point(16, 18);
            this.bigLabel_Titulo.Name = "bigLabel_Titulo";
            this.bigLabel_Titulo.Size = new System.Drawing.Size(422, 45);
            this.bigLabel_Titulo.TabIndex = 0;
            this.bigLabel_Titulo.Text = "🖨️ Printer Driver Manager";
            // 
            // crownDockPanel_Separador
            // 
            this.crownDockPanel_Separador.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(230)))));
            this.crownDockPanel_Separador.Dock = System.Windows.Forms.DockStyle.Top;
            this.crownDockPanel_Separador.Location = new System.Drawing.Point(0, 0);
            this.crownDockPanel_Separador.Name = "crownDockPanel_Separador";
            this.crownDockPanel_Separador.Size = new System.Drawing.Size(900, 1);
            this.crownDockPanel_Separador.TabIndex = 2;
            // 
            // Form_Configurar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 575);
            this.Controls.Add(this.airForm1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(900, 550);
            this.Name = "Form_Configurar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuración - Printer Driver";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_Configurar_FormClosed);
            this.airForm1.ResumeLayout(false);
            this.panelPrincipal.ResumeLayout(false);
            this.panelDerecho.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox_Configuracion.ResumeLayout(false);
            this.groupBox_Configuracion.PerformLayout();
            this.groupBox_ImpresoraActual.ResumeLayout(false);
            this.groupBox_ImpresoraActual.PerformLayout();
            this.panelIzquierdo.ResumeLayout(false);
            this.panelIzquierdo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.poisonDataGridView_Impresoras)).EndInit();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ReaLTaiizor.Forms.AirForm airForm1;
        private System.Windows.Forms.Panel panelPrincipal;
        private System.Windows.Forms.Panel panelDerecho;
        private System.Windows.Forms.GroupBox groupBox_Configuracion;
        private System.Windows.Forms.Label label_TamañoLetra;
        private System.Windows.Forms.Label label_Tipografia;
        private ReaLTaiizor.Controls.PoisonComboBox poisonComboBox_TamañoLetra;
        private ReaLTaiizor.Controls.PoisonComboBox poisonComboBox_Tipografia;
        private System.Windows.Forms.GroupBox groupBox_ImpresoraActual;
        private ReaLTaiizor.Controls.LabelEdit labelEdit_ImpresoraSeleccionada;
        private ReaLTaiizor.Controls.PoisonLabel poisonLabel_ImpresoraActual;
        private System.Windows.Forms.Panel panelIzquierdo;
        private ReaLTaiizor.Controls.PoisonDataGridView poisonDataGridView_Impresoras;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Impresora;
        private System.Windows.Forms.DataGridViewImageColumn Column_Select;
        private ReaLTaiizor.Controls.BigLabel bigLabel_Impresoras;
        private System.Windows.Forms.Panel panelHeader;
        private ReaLTaiizor.Controls.NightLabel nightLabel_SubTitulo;
        private ReaLTaiizor.Controls.BigLabel bigLabel_Titulo;
        private ReaLTaiizor.Docking.Crown.CrownDockPanel crownDockPanel_Separador;
        private ReaLTaiizor.Controls.NightControlBox nightControlBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private ReaLTaiizor.Controls.LabelEdit labelEdit_PuertoActivo;
        private ReaLTaiizor.Controls.HopeButton hopeButton_CambiarPuerto;
        private ReaLTaiizor.Controls.PoisonComboBox poisonComboBox_PuertosDisponibles;
    }
}