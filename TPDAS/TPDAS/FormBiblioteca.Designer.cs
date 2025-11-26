namespace TPDAS
{
    partial class FormBiblioteca
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
            dgvLibros = new DataGridView();
            dgvPrestamosActivos = new DataGridView();
            dgvSocios = new DataGridView();
            btnAltaLibro = new Button();
            btnAltaSocio = new Button();
            btnPrestar = new Button();
            btnDevolver = new Button();
            txtISBN = new TextBox();
            txtTitulo = new TextBox();
            txtAutor = new TextBox();
            txtDNI = new TextBox();
            txtNombre = new TextBox();
            txtEmail = new TextBox();
            txtTelefono = new TextBox();
            btnBuscarLibro = new Button();
            btnBuscarSocio = new Button();
            txtBuscarDNI = new TextBox();
            txtBuscarISBN = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            btnListar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvLibros).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvPrestamosActivos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvSocios).BeginInit();
            SuspendLayout();
            // 
            // dgvLibros
            // 
            dgvLibros.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLibros.Location = new Point(12, 12);
            dgvLibros.Name = "dgvLibros";
            dgvLibros.Size = new Size(362, 266);
            dgvLibros.TabIndex = 0;
            // 
            // dgvPrestamosActivos
            // 
            dgvPrestamosActivos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPrestamosActivos.Location = new Point(382, 12);
            dgvPrestamosActivos.Name = "dgvPrestamosActivos";
            dgvPrestamosActivos.Size = new Size(362, 266);
            dgvPrestamosActivos.TabIndex = 1;
            // 
            // dgvSocios
            // 
            dgvSocios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSocios.Location = new Point(759, 12);
            dgvSocios.Name = "dgvSocios";
            dgvSocios.Size = new Size(362, 266);
            dgvSocios.TabIndex = 2;
            // 
            // btnAltaLibro
            // 
            btnAltaLibro.Location = new Point(197, 352);
            btnAltaLibro.Name = "btnAltaLibro";
            btnAltaLibro.Size = new Size(131, 23);
            btnAltaLibro.TabIndex = 3;
            btnAltaLibro.Text = "Dar libro de alta";
            btnAltaLibro.UseVisualStyleBackColor = true;
            btnAltaLibro.Click += btnAltaLibro_Click;
            // 
            // btnAltaSocio
            // 
            btnAltaSocio.Location = new Point(965, 313);
            btnAltaSocio.Name = "btnAltaSocio";
            btnAltaSocio.Size = new Size(131, 23);
            btnAltaSocio.TabIndex = 4;
            btnAltaSocio.Text = "Dar socio de alta";
            btnAltaSocio.UseVisualStyleBackColor = true;
            btnAltaSocio.Click += btnAltaSocio_Click;
            // 
            // btnPrestar
            // 
            btnPrestar.Location = new Point(60, 284);
            btnPrestar.Name = "btnPrestar";
            btnPrestar.Size = new Size(131, 23);
            btnPrestar.TabIndex = 5;
            btnPrestar.Text = "Prestar libro";
            btnPrestar.UseVisualStyleBackColor = true;
            btnPrestar.Click += btnPrestar_Click;
            // 
            // btnDevolver
            // 
            btnDevolver.Location = new Point(579, 284);
            btnDevolver.Name = "btnDevolver";
            btnDevolver.Size = new Size(131, 23);
            btnDevolver.TabIndex = 6;
            btnDevolver.Text = "Devolver Libro";
            btnDevolver.UseVisualStyleBackColor = true;
            btnDevolver.Click += btnDevolver_Click;
            // 
            // txtISBN
            // 
            txtISBN.Location = new Point(56, 320);
            txtISBN.Name = "txtISBN";
            txtISBN.Size = new Size(100, 23);
            txtISBN.TabIndex = 7;
            // 
            // txtTitulo
            // 
            txtTitulo.Location = new Point(56, 349);
            txtTitulo.Name = "txtTitulo";
            txtTitulo.Size = new Size(100, 23);
            txtTitulo.TabIndex = 8;
            // 
            // txtAutor
            // 
            txtAutor.Location = new Point(56, 378);
            txtAutor.Name = "txtAutor";
            txtAutor.Size = new Size(100, 23);
            txtAutor.TabIndex = 9;
            // 
            // txtDNI
            // 
            txtDNI.Location = new Point(834, 372);
            txtDNI.Name = "txtDNI";
            txtDNI.Size = new Size(100, 23);
            txtDNI.TabIndex = 10;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(834, 285);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(100, 23);
            txtNombre.TabIndex = 11;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(834, 314);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(100, 23);
            txtEmail.TabIndex = 12;
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(834, 343);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(100, 23);
            txtTelefono.TabIndex = 13;
            // 
            // btnBuscarLibro
            // 
            btnBuscarLibro.Location = new Point(579, 339);
            btnBuscarLibro.Name = "btnBuscarLibro";
            btnBuscarLibro.Size = new Size(131, 23);
            btnBuscarLibro.TabIndex = 14;
            btnBuscarLibro.Text = "Buscar Libro";
            btnBuscarLibro.UseVisualStyleBackColor = true;
            btnBuscarLibro.Click += btnBuscarLibro_Click;
            // 
            // btnBuscarSocio
            // 
            btnBuscarSocio.Location = new Point(579, 381);
            btnBuscarSocio.Name = "btnBuscarSocio";
            btnBuscarSocio.Size = new Size(131, 23);
            btnBuscarSocio.TabIndex = 15;
            btnBuscarSocio.Text = "Buscar Socio";
            btnBuscarSocio.UseVisualStyleBackColor = true;
            btnBuscarSocio.Click += btnBuscarSocio_Click;
            // 
            // txtBuscarDNI
            // 
            txtBuscarDNI.Location = new Point(464, 383);
            txtBuscarDNI.Name = "txtBuscarDNI";
            txtBuscarDNI.Size = new Size(100, 23);
            txtBuscarDNI.TabIndex = 16;
            // 
            // txtBuscarISBN
            // 
            txtBuscarISBN.Location = new Point(464, 340);
            txtBuscarISBN.Name = "txtBuscarISBN";
            txtBuscarISBN.Size = new Size(100, 23);
            txtBuscarISBN.TabIndex = 17;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(793, 379);
            label1.Name = "label1";
            label1.Size = new Size(30, 15);
            label1.TabIndex = 18;
            label1.Text = "DNI:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(337, 386);
            label2.Name = "label2";
            label2.Size = new Size(121, 15);
            label2.TabIndex = 19;
            label2.Text = "Buscar Socio por DNI:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(9, 380);
            label3.Name = "label3";
            label3.Size = new Size(40, 15);
            label3.TabIndex = 20;
            label3.Text = "Autor:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(9, 352);
            label4.Name = "label4";
            label4.Size = new Size(41, 15);
            label4.TabIndex = 21;
            label4.Text = "Título:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(15, 328);
            label5.Name = "label5";
            label5.Size = new Size(35, 15);
            label5.TabIndex = 22;
            label5.Text = "ISBN:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(771, 347);
            label6.Name = "label6";
            label6.Size = new Size(56, 15);
            label6.TabIndex = 23;
            label6.Text = "Teléfono:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(789, 321);
            label7.Name = "label7";
            label7.Size = new Size(39, 15);
            label7.TabIndex = 24;
            label7.Text = "Email:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(773, 288);
            label8.Name = "label8";
            label8.Size = new Size(54, 15);
            label8.TabIndex = 25;
            label8.Text = "Nombre:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(337, 346);
            label9.Name = "label9";
            label9.Size = new Size(121, 15);
            label9.TabIndex = 26;
            label9.Text = "Buscar libro por ISBN:";
            // 
            // btnListar
            // 
            btnListar.Location = new Point(433, 285);
            btnListar.Name = "btnListar";
            btnListar.Size = new Size(131, 23);
            btnListar.TabIndex = 27;
            btnListar.Text = "Listar ";
            btnListar.UseVisualStyleBackColor = true;
            btnListar.Click += btnListar_Click;
            // 
            // FormBiblioteca
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1133, 439);
            Controls.Add(btnListar);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtBuscarISBN);
            Controls.Add(txtBuscarDNI);
            Controls.Add(btnBuscarSocio);
            Controls.Add(btnBuscarLibro);
            Controls.Add(txtTelefono);
            Controls.Add(txtEmail);
            Controls.Add(txtNombre);
            Controls.Add(txtDNI);
            Controls.Add(txtAutor);
            Controls.Add(txtTitulo);
            Controls.Add(txtISBN);
            Controls.Add(btnDevolver);
            Controls.Add(btnPrestar);
            Controls.Add(btnAltaSocio);
            Controls.Add(btnAltaLibro);
            Controls.Add(dgvSocios);
            Controls.Add(dgvPrestamosActivos);
            Controls.Add(dgvLibros);
            Name = "FormBiblioteca";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dgvLibros).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvPrestamosActivos).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvSocios).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvLibros;
        private DataGridView dgvPrestamosActivos;
        private DataGridView dgvSocios;
        private Button btnAltaLibro;
        private Button btnAltaSocio;
        private Button btnPrestar;
        private Button btnDevolver;
        private TextBox txtISBN;
        private TextBox txtTitulo;
        private TextBox txtAutor;
        private TextBox txtDNI;
        private TextBox txtNombre;
        private TextBox txtEmail;
        private TextBox txtTelefono;
        private Button btnBuscarLibro;
        private Button btnBuscarSocio;
        private TextBox txtBuscarDNI;
        private TextBox txtBuscarISBN;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Button btnListar;
    }
}
