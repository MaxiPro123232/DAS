namespace ado_multiplestablas
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
            dgvDatos = new DataGridView();
            btnAgregarAvion = new Button();
            btnListarAviones = new Button();
            btnListarPasajeros = new Button();
            btnListarPasajes = new Button();
            txtMatricula = new TextBox();
            txtModelo = new TextBox();
            txtCapacidad = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            btnProbarConexion = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvDatos).BeginInit();
            SuspendLayout();
            // 
            // dgvDatos
            // 
            dgvDatos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDatos.Location = new Point(274, 12);
            dgvDatos.Name = "dgvDatos";
            dgvDatos.Size = new Size(820, 498);
            dgvDatos.TabIndex = 0;
            // 
            // btnAgregarAvion
            // 
            btnAgregarAvion.Location = new Point(12, 24);
            btnAgregarAvion.Name = "btnAgregarAvion";
            btnAgregarAvion.Size = new Size(120, 23);
            btnAgregarAvion.TabIndex = 1;
            btnAgregarAvion.Text = "Agregar Avion";
            btnAgregarAvion.UseVisualStyleBackColor = true;
            btnAgregarAvion.Click += btnAgregarAvion_Click_1;
            // 
            // btnListarAviones
            // 
            btnListarAviones.Location = new Point(12, 68);
            btnListarAviones.Name = "btnListarAviones";
            btnListarAviones.Size = new Size(120, 23);
            btnListarAviones.TabIndex = 2;
            btnListarAviones.Text = "Listar Aviones";
            btnListarAviones.UseVisualStyleBackColor = true;
            btnListarAviones.Click += btnListarAviones_Click;
            // 
            // btnListarPasajeros
            // 
            btnListarPasajeros.Location = new Point(12, 97);
            btnListarPasajeros.Name = "btnListarPasajeros";
            btnListarPasajeros.Size = new Size(120, 23);
            btnListarPasajeros.TabIndex = 3;
            btnListarPasajeros.Text = "Listar Pasajeros";
            btnListarPasajeros.UseVisualStyleBackColor = true;
            btnListarPasajeros.Click += btnListarPasajeros_Click;
            // 
            // btnListarPasajes
            // 
            btnListarPasajes.Location = new Point(12, 138);
            btnListarPasajes.Name = "btnListarPasajes";
            btnListarPasajes.Size = new Size(120, 23);
            btnListarPasajes.TabIndex = 4;
            btnListarPasajes.Text = "Listar Pasajes";
            btnListarPasajes.UseVisualStyleBackColor = true;
            btnListarPasajes.Click += btnListarPasajes_Click_1;
            // 
            // txtMatricula
            // 
            txtMatricula.Location = new Point(138, 42);
            txtMatricula.Name = "txtMatricula";
            txtMatricula.Size = new Size(100, 23);
            txtMatricula.TabIndex = 5;
            // 
            // txtModelo
            // 
            txtModelo.Location = new Point(138, 86);
            txtModelo.Name = "txtModelo";
            txtModelo.Size = new Size(100, 23);
            txtModelo.TabIndex = 6;
            // 
            // txtCapacidad
            // 
            txtCapacidad.Location = new Point(138, 139);
            txtCapacidad.Name = "txtCapacidad";
            txtCapacidad.Size = new Size(100, 23);
            txtCapacidad.TabIndex = 7;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(157, 24);
            label1.Name = "label1";
            label1.Size = new Size(57, 15);
            label1.TabIndex = 8;
            label1.Text = "Matricula";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(163, 68);
            label2.Name = "label2";
            label2.Size = new Size(48, 15);
            label2.TabIndex = 9;
            label2.Text = "Modelo";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(157, 121);
            label3.Name = "label3";
            label3.Size = new Size(63, 15);
            label3.TabIndex = 10;
            label3.Text = "Capacidad";
            label3.Click += label3_Click;
            // 
            // btnProbarConexion
            // 
            btnProbarConexion.Location = new Point(12, 401);
            btnProbarConexion.Name = "btnProbarConexion";
            btnProbarConexion.Size = new Size(120, 23);
            btnProbarConexion.TabIndex = 11;
            btnProbarConexion.Text = "Probar conexion";
            btnProbarConexion.UseVisualStyleBackColor = true;
            btnProbarConexion.Click += btnProbarConexion_Click_1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1131, 532);
            Controls.Add(btnProbarConexion);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtCapacidad);
            Controls.Add(txtModelo);
            Controls.Add(txtMatricula);
            Controls.Add(btnListarPasajes);
            Controls.Add(btnListarPasajeros);
            Controls.Add(btnListarAviones);
            Controls.Add(btnAgregarAvion);
            Controls.Add(dgvDatos);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load_1;
            ((System.ComponentModel.ISupportInitialize)dgvDatos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvDatos;
        private Button btnAgregarAvion;
        private Button btnListarAviones;
        private Button btnListarPasajeros;
        private Button btnListarPasajes;
        private TextBox txtMatricula;
        private TextBox txtModelo;
        private TextBox txtCapacidad;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button btnProbarConexion;
    }
}
