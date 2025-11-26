using Entidades;
using Modelo;
using System.Text.RegularExpressions;

namespace Controladora
{
    public class Controladora
    {
        private static Controladora instancia;
        public static Controladora Instancia
        {
            get
            {
                if (instancia == null)
                    instancia = new Controladora();

                return instancia;
            }
        }

        private readonly Repositorio repo = new Repositorio();
        private Controladora() { }

        private bool ValidarISBN(string isbn)
        {
            // Formato "XXX-X-XXXX-XXXX-X"
            var regex = new Regex(@"^\d{3}-\d-\d{4}-\d{4}-\d$");
            return regex.IsMatch(isbn);
        }

        private bool ValidarDNI(string dni)
        {
            var regex = new Regex(@"^\d{8}$"); // 8 dígitos
            return regex.IsMatch(dni);
        }

        private bool ValidarEmail(string email)
        {
            var regex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            return regex.IsMatch(email);
        }

        private bool ValidarTelefono(string tel)
        {
            // 10 dígitos total: "1234-567890" o "1234567890"
            var regex = new Regex(@"^(\d{4}-\d{6}|\d{10})$");
            return regex.IsMatch(tel);
        }

        public string AgregarLibro(string isbn, string titulo, string autor)
        {
            if (!ValidarISBN(isbn))
                return "Error: ISBN inválido (formato XXX-X-XXXX-XXXX-X).";

            if (string.IsNullOrWhiteSpace(titulo))
                return "Error: El título no puede estar vacío.";

            if (string.IsNullOrWhiteSpace(autor))
                return "Error: El autor no puede estar vacío.";

            // Evitar duplicado por ISBN
            var existente = repo.BuscarLibroPorISBN(isbn);
            if (existente != null)
                return "Error: Ya existe un libro con ese ISBN.";

            var libro = new Libro
            {
                ISBN = isbn,
                Titulo = titulo,
                Autor = autor,
                Estado = "disponible"
            };

            repo.AgregarLibro(libro);
            return "Libro agregado correctamente.";
        }

        public List<Libro> ListarLibros()
        {
            return repo.ListarLibros();
        }

        public Libro ConsultarLibroPorISBN(string isbn)
        {
            return repo.BuscarLibroPorISBN(isbn);
        }

        public string AgregarSocio(string dni, string nombre, string email, string telefono)
        {
            if (!ValidarDNI(dni))
                return "Error: DNI inválido (debe tener 8 dígitos).";

            if (string.IsNullOrWhiteSpace(nombre))
                return "Error: El nombre no puede estar vacío.";

            if (!ValidarEmail(email))
                return "Error: Email inválido.";

            if (!ValidarTelefono(telefono))
                return "Error: Teléfono inválido (usar 1234-567890 o 10 dígitos).";

            // Evitar duplicado de socio por DNI
            var existente = repo.BuscarSocioPorDNI(dni);
            if (existente != null)
                return "Error: Ya existe un socio con ese DNI.";

            var socio = new Socio
            {
                DNI = dni,
                NombreCompleto = nombre,
                Email = email,
                Telefono = telefono
            };

            repo.AgregarSocio(socio);
            return "Socio agregado correctamente.";
        }

        public List<Socio> ListarSocios()
        {
            return repo.ListarSocios();
        }

        public Socio ConsultarSocioPorDNI(string dni)
        {
            return repo.BuscarSocioPorDNI(dni);
        }
        public string RegistrarPrestamo(int libroId, int socioId)
        {
            var libro = repo.BuscarLibroPorId(libroId);
            if (libro == null)
                return "Error: Libro no encontrado.";

            var socio = repo.BuscarSocioPorId(socioId);
            if (socio == null)
                return "Error: Socio no encontrado.";

            if (libro.Estado == "prestado")
                return "Error: Ese libro ya está prestado.";

            var prestamo = new Prestamo
            {
                LibroId = libro.LibroId,
                SocioId = socio.SocioId,
                FechaPrestamo = DateTime.Now,
                FechaDevolucion = null
            };

            repo.AgregarPrestamo(prestamo);

            return "Préstamo registrado correctamente.";
        }

        public List<Prestamo> ListarPrestamosActivos()
        {
            return repo.ListarPrestamosActivos();
        }

        public List<Prestamo> ListarPrestamos()
        {
            return repo.ListarPrestamos();
        }

        public string RegistrarDevolucion(int prestamoId)
        {
            // Verificar que el préstamo exista y esté activo
            var prestamo = repo.BuscarPrestamoPorId(prestamoId);
            if (prestamo == null)
                return "Error: Préstamo no encontrado.";

            if (prestamo.FechaDevolucion != null)
                return "Error: Ese préstamo ya fue devuelto.";

            // Registrar devolución en repositorio (esto también marca el libro en "disponible")
            repo.RegistrarDevolucion(prestamoId);

            return "Devolución registrada correctamente.";
        }
    }
}
