using System.Collections.Generic;
using System.Reflection.Emit;
using Entidades;
using Microsoft.EntityFrameworkCore;

namespace Modelo
{
    public class Context: DbContext
    {
        private string conexion = "Data Source=MAXOPC\\SQLEXPRESS;Initial Catalog=BibliotecaDB;Integrated Security=True;Persist Security Info=False;Pooling=False;Encrypt=False";
        public DbSet<Libro> Libros { get; set; }
        public DbSet<Socio> Socios { get; set; }
        public DbSet<Prestamo> Prestamos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(conexion);
    }
}
