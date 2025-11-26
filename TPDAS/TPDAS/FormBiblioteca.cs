using Entidades;
using Controladora;
namespace TPDAS
{
    public partial class FormBiblioteca : Form
    {
        public FormBiblioteca()
        {
            InitializeComponent();
        }

        private void FormBiblioteca_Load(object sender, EventArgs e)
        {
            RefrescarLibros();
            RefrescarSocios();
            RefrescarPrestamos();
            ConfigurarGrillas();
        }
        private void ConfigurarGrillas()
        {
            dgvLibros.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLibros.MultiSelect = false;

            dgvSocios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSocios.MultiSelect = false;

            dgvPrestamosActivos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPrestamosActivos.MultiSelect = false;
        }
        private void RefrescarLibros()
        {
            var listaLibros = Controladora.Controladora
                                          .Instancia
                                          .ListarLibros();

            dgvLibros.DataSource = null;
            dgvLibros.DataSource = listaLibros
                .Select(l => new
                {
                    l.LibroId,
                    l.ISBN,
                    l.Titulo,
                    l.Autor,
                    l.Estado
                })
                .ToList();
        }
        private void LimpiarCamposLibro()
        {
            txtISBN.Text = "";
            txtTitulo.Text = "";
            txtAutor.Text = "";
        }
        private void btnAltaLibro_Click(object sender, EventArgs e)
        {
            string isbn = txtISBN.Text;
            string titulo = txtTitulo.Text;
            string autor = txtAutor.Text;

            string resultado = Controladora.Controladora
                                           .Instancia
                                           .AgregarLibro(isbn, titulo, autor);

            MessageBox.Show(resultado);

            RefrescarLibros();
            LimpiarCamposLibro();
        }
        private void btnAltaSocio_Click(object sender, EventArgs e)
        {
            string dni = txtDNI.Text;
            string nombre = txtNombre.Text;
            string email = txtEmail.Text;
            string telefono = txtTelefono.Text;

            string resultado = Controladora.Controladora
                                           .Instancia
                                           .AgregarSocio(dni, nombre, email, telefono);

            MessageBox.Show(resultado);

            RefrescarSocios();
            LimpiarCamposSocio();
        }
        private void RefrescarSocios()
        {
            var listaSocios = Controladora.Controladora
                                          .Instancia
                                          .ListarSocios();

            dgvSocios.DataSource = null;
            dgvSocios.DataSource = listaSocios
                .Select(s => new
                {
                    s.SocioId,
                    s.DNI,
                    s.NombreCompleto,
                    s.Email,
                    s.Telefono
                })
                .ToList();
        }

        private void LimpiarCamposSocio()
        {
            txtDNI.Text = "";
            txtNombre.Text = "";
            txtEmail.Text = "";
            txtTelefono.Text = "";
        }
        private void btnPrestar_Click(object sender, EventArgs e)
        {
            if (dgvLibros.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccioná un libro.");
                return;
            }


            if (dgvSocios.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccioná un socio.");
                return;
            }


            int libroId = (int)dgvLibros.SelectedRows[0].Cells["LibroId"].Value;
            int socioId = (int)dgvSocios.SelectedRows[0].Cells["SocioId"].Value;

            string resultado = Controladora.Controladora
                                           .Instancia
                                           .RegistrarPrestamo(libroId, socioId);

            MessageBox.Show(resultado);

            RefrescarLibros();            
            RefrescarPrestamosActivos();  
        }
        private void RefrescarPrestamosActivos()
        {
            var lista = Controladora.Controladora
                                    .Instancia
                                    .ListarPrestamosActivos()
                                    .Select(p => new
                                    {
                                        p.PrestamoId,
                                        Libro = p.Libro != null ? p.Libro.Titulo : "(?)",
                                        Socio = p.Socio != null ? p.Socio.NombreCompleto : "(?)",
                                        p.FechaPrestamo
                                    })
                                    .ToList();

            dgvPrestamosActivos.DataSource = null;
            dgvPrestamosActivos.DataSource = lista;
        }
        private void RefrescarPrestamos()
        {
            var listaPrestamos = Controladora.Controladora
                                             .Instancia
                                             .ListarPrestamos();

            dgvPrestamosActivos.DataSource = null;
            dgvPrestamosActivos.DataSource = listaPrestamos
                .Select(p => new
                {
                    p.PrestamoId,
                    Libro = p.Libro != null ? p.Libro.Titulo : "(desconocido)",
                    Socio = p.Socio != null ? p.Socio.NombreCompleto : "(desconocido)",
                    p.FechaPrestamo,
                    p.FechaDevolucion
                })
                .ToList();
        }
        private void btnDevolver_Click(object sender, EventArgs e)
        {
            if (dgvPrestamosActivos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un préstamo activo para devolver.");
                return;
            }

            int prestamoId = (int)dgvPrestamosActivos
                                    .SelectedRows[0]
                                    .Cells["PrestamoId"]
                                    .Value;

            string resultado = Controladora.Controladora
                                           .Instancia
                                           .RegistrarDevolucion(prestamoId);

            MessageBox.Show(resultado);
            RefrescarLibros();
            RefrescarSocios();
            RefrescarPrestamos();
        }
        private void btnBuscarLibro_Click(object sender, EventArgs e)
        {
            string isbnBuscado = txtBuscarISBN.Text.Trim();

            if (string.IsNullOrWhiteSpace(isbnBuscado))
            {
                MessageBox.Show("Por favor ingresá un ISBN para buscar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var libro = Controladora.Controladora
                                    .Instancia
                                    .ConsultarLibroPorISBN(isbnBuscado);

            if (libro == null)
            {
                MessageBox.Show("No se encontró ningún libro con ese ISBN.", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string info = $"Libro encontrado:\n\n" +
                          $"Título: {libro.Titulo}\n" +
                          $"Autor: {libro.Autor}\n" +
                          $"ISBN: {libro.ISBN}\n" +
                          $"Estado: {libro.Estado}";

            MessageBox.Show(info, "Resultado de búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnBuscarSocio_Click(object sender, EventArgs e)
        {
            string dniBuscado = txtBuscarDNI.Text.Trim();

            if (string.IsNullOrWhiteSpace(dniBuscado))
            {
                MessageBox.Show("Por favor ingresá un DNI para buscar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var socio = Controladora.Controladora
                                    .Instancia
                                    .ConsultarSocioPorDNI(dniBuscado);

            if (socio == null)
            {
                MessageBox.Show("No se encontró ningún socio con ese DNI.", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string info = $"Socio encontrado:\n\n" +
                          $"Nombre: {socio.NombreCompleto}\n" +
                          $"DNI: {socio.DNI}\n" +
                          $"Email: {socio.Email}\n" +
                          $"Teléfono: {socio.Telefono}";

            MessageBox.Show(info, "Resultado de búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btnListar_Click(object sender, EventArgs e)
        {
            RefrescarLibros();
            RefrescarSocios();
            RefrescarPrestamosActivos();

            MessageBox.Show("Listados actualizados correctamente.");
        }
    }
}