using Entidades;
using Microsoft.EntityFrameworkCore;

namespace Modelo
{
    public class Repositorio
    {
        private readonly Context _context;

        public Repositorio()
        {
            _context = new Context();
        }


        public List<Libro> ListarLibros()
        {
            return _context.Libros.ToList();
        }

        public void AgregarLibro(Libro libro)
        {
            _context.Libros.Add(libro);
            _context.SaveChanges();
        }

        public Libro BuscarLibroPorId(int libroId)
        {
            return _context.Libros.FirstOrDefault(l => l.LibroId == libroId);
        }

        public Libro BuscarLibroPorISBN(string isbn)
        {
            return _context.Libros.FirstOrDefault(l => l.ISBN == isbn);
        }
        public List<Socio> ListarSocios()
        {
            return _context.Socios.ToList();
        }

        public void AgregarSocio(Socio socio)
        {
            _context.Socios.Add(socio);
            _context.SaveChanges();
        }
        public Socio BuscarSocioPorId(int socioId)
        {
            return _context.Socios.FirstOrDefault(s => s.SocioId == socioId);
        }
        public Socio BuscarSocioPorDNI(string dni)
        {
            return _context.Socios.FirstOrDefault(s => s.DNI == dni);
        }
        public List<Prestamo> ListarPrestamos()
        {
            return _context.Prestamos
                           .Include(p => p.Libro)
                           .Include(p => p.Socio)
                           .ToList();
        }
        public List<Prestamo> ListarPrestamosActivos()
        {
            return _context.Prestamos
                           .Include(p => p.Libro)
                           .Include(p => p.Socio)
                           .Where(p => p.FechaDevolucion == null)
                           .ToList();
        }
        public void AgregarPrestamo(Prestamo prestamo)
        {
            _context.Prestamos.Add(prestamo);

            // Marcar libro como prestado
            var libro = _context.Libros.FirstOrDefault(l => l.LibroId == prestamo.LibroId);
            if (libro != null)
            {
                libro.Estado = "prestado";
                _context.Libros.Update(libro);
            }

            _context.SaveChanges();
        }
        public Prestamo BuscarPrestamoPorId(int prestamoId)
        {
            return _context.Prestamos
                           .Include(p => p.Libro)
                           .Include(p => p.Socio)
                           .FirstOrDefault(p => p.PrestamoId == prestamoId);
        }
        public void RegistrarDevolucion(int prestamoId)
        {
            var prestamo = _context.Prestamos
                                   .Include(p => p.Libro)
                                   .FirstOrDefault(p => p.PrestamoId == prestamoId);

            if (prestamo != null && prestamo.FechaDevolucion == null)
            {
                // marcar devolución
                prestamo.FechaDevolucion = DateTime.Now;
                _context.Prestamos.Update(prestamo);

                // marcar libro como disponible otra vez
                if (prestamo.Libro != null)
                {
                    prestamo.Libro.Estado = "disponible";
                    _context.Libros.Update(prestamo.Libro);
                }

                _context.SaveChanges();
            }
        }
    }
}
