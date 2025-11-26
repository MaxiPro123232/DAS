namespace REPASOPARCIA
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvSocios = new DataGridView();
            btnAlta = new Button();
            btnBaja = new Button();
            btnModificacion = new Button();
            txtNombre = new TextBox();
            txtDNI = new TextBox();
            txtApellido = new TextBox();
            txtNumSoc = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            btnListar = new Button();
            dtpFecha = new DateTimePicker();
            chkCuota = new CheckBox();
            btnCantidad = new Button();
            btnMayores = new Button();
            txtAnios = new TextBox();
            label7 = new Label();
            btnClear = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvSocios).BeginInit();
            SuspendLayout();
            // 
            // dgvSocios
            // 
            dgvSocios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSocios.Location = new Point(228, 12);
            dgvSocios.Name = "dgvSocios";
            dgvSocios.Size = new Size(681, 356);
            dgvSocios.TabIndex = 0;
            // 
            // btnAlta
            // 
            btnAlta.Location = new Point(12, 81);
            btnAlta.Name = "btnAlta";
            btnAlta.Size = new Size(92, 23);
            btnAlta.TabIndex = 1;
            btnAlta.Text = "Alta";
            btnAlta.UseVisualStyleBackColor = true;
            btnAlta.Click += btnAlta_Click;
            // 
            // btnBaja
            // 
            btnBaja.Location = new Point(650, 398);
            btnBaja.Name = "btnBaja";
            btnBaja.Size = new Size(92, 23);
            btnBaja.TabIndex = 2;
            btnBaja.Text = "Baja";
            btnBaja.UseVisualStyleBackColor = true;
            btnBaja.Click += btnBaja_Click;
            // 
            // btnModificacion
            // 
            btnModificacion.Location = new Point(552, 398);
            btnModificacion.Name = "btnModificacion";
            btnModificacion.Size = new Size(92, 23);
            btnModificacion.TabIndex = 3;
            btnModificacion.Text = "Modificacion";
            btnModificacion.UseVisualStyleBackColor = true;
            btnModificacion.Click += btnModificacion_Click;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(110, 81);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(100, 23);
            txtNombre.TabIndex = 4;
            // 
            // txtDNI
            // 
            txtDNI.Location = new Point(110, 166);
            txtDNI.Name = "txtDNI";
            txtDNI.Size = new Size(100, 23);
            txtDNI.TabIndex = 6;
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(110, 125);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(100, 23);
            txtApellido.TabIndex = 7;
            // 
            // txtNumSoc
            // 
            txtNumSoc.Location = new Point(110, 259);
            txtNumSoc.Name = "txtNumSoc";
            txtNumSoc.Size = new Size(100, 23);
            txtNumSoc.TabIndex = 8;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(137, 63);
            label1.Name = "label1";
            label1.Size = new Size(51, 15);
            label1.TabIndex = 10;
            label1.Text = "Nombre";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(137, 107);
            label2.Name = "label2";
            label2.Size = new Size(51, 15);
            label2.TabIndex = 11;
            label2.Text = "Apellido";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(137, 151);
            label3.Name = "label3";
            label3.Size = new Size(25, 15);
            label3.TabIndex = 12;
            label3.Text = "Dni";
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(62, 192);
            label4.Name = "label4";
            label4.Size = new Size(117, 15);
            label4.TabIndex = 13;
            label4.Text = "Fecha de nacimiento";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(111, 236);
            label5.Name = "label5";
            label5.Size = new Size(99, 15);
            label5.TabIndex = 14;
            label5.Text = "Numero de Socio";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(124, 285);
            label6.Name = "label6";
            label6.Size = new Size(71, 15);
            label6.TabIndex = 15;
            label6.Text = "Cuota al Dia";
            // 
            // btnListar
            // 
            btnListar.Location = new Point(12, 12);
            btnListar.Name = "btnListar";
            btnListar.Size = new Size(92, 25);
            btnListar.TabIndex = 16;
            btnListar.Text = "Listar Socios";
            btnListar.UseVisualStyleBackColor = true;
            btnListar.Click += btnListar_Click;
            // 
            // dtpFecha
            // 
            dtpFecha.Location = new Point(22, 210);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(200, 23);
            dtpFecha.TabIndex = 17;
            // 
            // chkCuota
            // 
            chkCuota.AutoSize = true;
            chkCuota.Location = new Point(147, 310);
            chkCuota.Name = "chkCuota";
            chkCuota.Size = new Size(15, 14);
            chkCuota.TabIndex = 18;
            chkCuota.UseVisualStyleBackColor = true;
            // 
            // btnCantidad
            // 
            btnCantidad.Location = new Point(748, 398);
            btnCantidad.Name = "btnCantidad";
            btnCantidad.Size = new Size(161, 23);
            btnCantidad.TabIndex = 19;
            btnCantidad.Text = "Cantidad Cuota al dia";
            btnCantidad.UseVisualStyleBackColor = true;
            btnCantidad.Click += btnCantidad_Click;
            // 
            // btnMayores
            // 
            btnMayores.Location = new Point(228, 398);
            btnMayores.Name = "btnMayores";
            btnMayores.Size = new Size(92, 23);
            btnMayores.TabIndex = 20;
            btnMayores.Text = "Mayores de:";
            btnMayores.UseVisualStyleBackColor = true;
            btnMayores.Click += btnMayores_Click;
            // 
            // txtAnios
            // 
            txtAnios.Location = new Point(338, 398);
            txtAnios.Name = "txtAnios";
            txtAnios.Size = new Size(100, 23);
            txtAnios.TabIndex = 21;
            txtAnios.TextChanged += txtAnios_TextChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(372, 380);
            label7.Name = "label7";
            label7.Size = new Size(32, 15);
            label7.TabIndex = 22;
            label7.Text = "años";
            // 
            // btnClear
            // 
            btnClear.Location = new Point(12, 110);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(92, 23);
            btnClear.TabIndex = 23;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(935, 454);
            Controls.Add(btnClear);
            Controls.Add(label7);
            Controls.Add(txtAnios);
            Controls.Add(btnMayores);
            Controls.Add(btnCantidad);
            Controls.Add(chkCuota);
            Controls.Add(dtpFecha);
            Controls.Add(btnListar);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtNumSoc);
            Controls.Add(txtApellido);
            Controls.Add(txtDNI);
            Controls.Add(txtNombre);
            Controls.Add(btnModificacion);
            Controls.Add(btnBaja);
            Controls.Add(btnAlta);
            Controls.Add(dgvSocios);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dgvSocios).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvSocios;
        private Button btnAlta;
        private Button btnBaja;
        private Button btnModificacion;
        private TextBox txtNombre;
        private TextBox txtDNI;
        private TextBox txtApellido;
        private TextBox txtNumSoc;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Button btnListar;
        private DateTimePicker dtpFecha;
        private CheckBox chkCuota;
        private Button btnCantidad;
        private Button btnMayores;
        private TextBox txtAnios;
        private Label label7;
        private Button btnClear;
    }
}
