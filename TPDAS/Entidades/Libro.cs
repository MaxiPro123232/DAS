namespace Entidades
{
    public class Libro
    {
        public int LibroId { get; set; } 
        public string ISBN { get; set; } 
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Estado { get; set; }
        public List<Prestamo> Prestamos { get; set; }
    }
}
