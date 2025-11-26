using System.Windows.Forms;

namespace REPASOPARCIA
{
    public partial class Form1 : Form
    {
        #region Listar
        private void btnListar_Click(object sender, EventArgs e)
        {
            try
            {
                dgvSocios.AutoGenerateColumns = true;     // si no creaste columnas a mano
                var lista = repo.ListarSocios();              // trae todos
                dgvSocios.DataSource = null;              // reset
                dgvSocios.DataSource = lista;             // bind
                if (lista.Count == 0)
                    MessageBox.Show("No hay socios cargados.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al listar");
            }
        }
        #endregion
        #region Formulario
        public Form1()
        {
            InitializeComponent();
            dgvSocios.AutoGenerateColumns = true;
            CargarGrid();
            dgvSocios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSocios.MultiSelect = false;
        }
        #endregion
        #region Modificacion
        private void btnModificacion_Click(object sender, EventArgs e)
        {
            if (dgvSocios.CurrentRow?.DataBoundItem is not Socio seleccionado)
            {
                MessageBox.Show("Selecciona un socio del listado.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidarCamposAlta(out Socio socioEditado)) return;

            socioEditado.Id = seleccionado.Id;

            try
            {
                repo.ModificarSocio(socioEditado);
                MessageBox.Show("Datos actualizados.", "OK",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al modificar",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
        #region Mayores De esa edad
        private void btnMayores_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtAnios.Text.Trim(), out int edad) || edad < 0)
            {
                MessageBox.Show("Ingresá una edad válida (número entero mayor 0).",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var lista = repo.ListarSociosMayoresA(edad);
                dgvSocios.DataSource = lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al filtrar por edad",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtAnios_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAnios.Text))
                CargarTodos();
        }
        #endregion
        #region Cantidad cuotas al dia
        private void btnCantidad_Click(object sender, EventArgs e)
        {
            try
            {
                int total = repo.ContarSociosConCuotaAlDia();

                MessageBox.Show($"Socios con la cuota al día: {total}",
                    "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al contar",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
        #region Alta
        private void btnAlta_Click(object sender, EventArgs e)
        {
            try
            {
                var socio = new Socio
                {
                    nombre = txtNombre.Text,
                    apellido = txtApellido.Text,
                    DNI = txtDNI.Text,
                    fechaNacimiento = dtpFecha.Value,
                    NumSocio = int.Parse(txtNumSoc.Text),
                    CuotaAlDia = chkCuota.Checked
                };
                repo.AgregarSocio(socio);
                dgvSocios.DataSource = null;
                dgvSocios.DataSource = repo.ListarSocios();
                MessageBox.Show("Socio agregado.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "No se pudo agregar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }
        #endregion
        #region Baja
        private readonly RepositorioSocios repo = new RepositorioSocios();
        private void btnBaja_Click(object sender, EventArgs e)
        {
            if (dgvSocios.CurrentRow?.DataBoundItem is not Socio s)
            {
                MessageBox.Show("Seleccioná un socio.");
                return;
            }

            if (MessageBox.Show($"¿Eliminar ID {s.Id} ({s.apellido}, {s.nombre})?",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            try
            {
                repo.EliminarSocio(s.Id);
                RefrescarGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al eliminar");
            }
        }
        #endregion
        #region Funciones
        private readonly BindingSource bs = new BindingSource();
        private void CargarTodos()
        {
            bs.DataSource = repo.ListarSocios();
            dgvSocios.DataSource = bs;
        }
        private bool ValidarCamposAlta(out Socio socio)
        {
            socio = null;

            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtApellido.Text) ||
                string.IsNullOrWhiteSpace(txtDNI.Text) ||
                string.IsNullOrWhiteSpace(txtNumSoc.Text))
            {
                MessageBox.Show("Completa Nombre, Apellido, DNI y Número de socio.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!int.TryParse(txtNumSoc.Text, out int numSocio) || numSocio <= 0)
            {
                MessageBox.Show("Número de socio inválido.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            socio = new Socio
            {
                nombre = txtNombre.Text.Trim(),
                apellido = txtApellido.Text.Trim(),
                DNI = txtDNI.Text.Trim(),
                fechaNacimiento = dtpFecha.Value.Date,
                NumSocio = numSocio,
                CuotaAlDia = chkCuota.Checked
            };
            return true;
        }
        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtDNI.Clear();
            txtNumSoc.Clear();
            chkCuota.Checked = false;
            dtpFecha.Value = DateTime.Today;
        }
        private void CargarGrid()
        {
            var repo = new RepositorioSocios();
            dgvSocios.AutoGenerateColumns = true;
            dgvSocios.DataSource = repo.ListarSocios();

        }
        private void RefrescarGrid()
        {
            dgvSocios.DataSource = null;
            dgvSocios.Columns.Clear();                    // evita columnas duplicadas
            dgvSocios.DataSource = repo.ListarSocios();   // lista con propiedades Id, nombre, etc.

            // oculto Id por nombre, no por índice
            if (dgvSocios.Columns["Id"] != null)
                dgvSocios.Columns["Id"].Visible = false;
        }
        #endregion
        #region No sirve
        private void label3_Click(object sender, EventArgs e)
        {

        }
        #endregion
    }
}
