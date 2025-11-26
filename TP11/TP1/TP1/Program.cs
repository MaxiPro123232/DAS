using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;

class Program
{
    private static string connectionString =
        "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=TP1;Integrated Security=True;";

    static void Main()
    {
        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("===== MENU CRUD PRODUCTOS =====");
            Console.WriteLine("1) Crear producto");
            Console.WriteLine("2) Listar productos");
            Console.WriteLine("3) Actualizar producto");
            Console.WriteLine("4) Eliminar producto");
            Console.WriteLine("0) Salir");
            Console.Write("Opcion: ");

            string opcion = Console.ReadLine();

            if (opcion == "1")
            {
                Crear();
            }
            else if (opcion == "2")
            {
                Listar();
            }
            else if (opcion == "3")
            {
                Actualizar();
            }
            else if (opcion == "4")
            {
                Eliminar();
            }
            else if (opcion == "0")
            {
                break;
            }
            else
            {
                Console.WriteLine("Opcion incorrecta.");
            }
        }
    }

    static void Crear()
    {
        Console.Write("Ingrese nombre: ");
        string nombre = Console.ReadLine();

        Console.Write("Ingrese precio: ");
        string precioTexto = Console.ReadLine();
        decimal precio;

        if (!decimal.TryParse(precioTexto, out precio))
        {
            Console.WriteLine("El precio no es valido.");
            return;
        }

        SqlConnection cn = new SqlConnection(connectionString);
        cn.Open();

        string sql = "INSERT INTO Productos (Nombre, Precio) VALUES (@n, @p)";
        SqlCommand cmd = new SqlCommand(sql, cn);
        cmd.Parameters.AddWithValue("@n", nombre);
        cmd.Parameters.AddWithValue("@p", precio);

        int filas = cmd.ExecuteNonQuery();

        if (filas > 0)
        {
            Console.WriteLine("Producto agregado correctamente.");
        }
        else
        {
            Console.WriteLine("No se pudo agregar el producto.");
        }

        cn.Close();
    }

    static void Listar()
    {
        SqlConnection cn = new SqlConnection(connectionString);
        cn.Open();

        string sql = "SELECT Id, Nombre, Precio FROM Productos";
        SqlCommand cmd = new SqlCommand(sql, cn);
        SqlDataReader rd = cmd.ExecuteReader();

        Console.WriteLine("ID\tNOMBRE\t\tPRECIO");
        while (rd.Read())
        {
            int id = rd.GetInt32(0);
            string nombre = rd.GetString(1);
            decimal precio = rd.GetDecimal(2);

            Console.WriteLine(id + "\t" + nombre + "\t\t" + precio);
        }

        rd.Close();
        cn.Close();
    }

    static void Actualizar()
    {
        Console.Write("Ingrese ID a actualizar: ");
        string idTexto = Console.ReadLine();
        int id;

        if (!int.TryParse(idTexto, out id))
        {
            Console.WriteLine("El ID no es valido.");
            return;
        }

        Console.Write("Nuevo nombre: ");
        string nuevoNombre = Console.ReadLine();

        Console.Write("Nuevo precio: ");
        string precioTexto = Console.ReadLine();
        decimal nuevoPrecio;

        if (!decimal.TryParse(precioTexto, out nuevoPrecio))
        {
            Console.WriteLine("El precio no es valido.");
            return;
        }

        SqlConnection cn = new SqlConnection(connectionString);
        cn.Open();

        string sql = "UPDATE Productos SET Nombre=@n, Precio=@p WHERE Id=@id";
        SqlCommand cmd = new SqlCommand(sql, cn);
        cmd.Parameters.AddWithValue("@n", nuevoNombre);
        cmd.Parameters.AddWithValue("@p", nuevoPrecio);
        cmd.Parameters.AddWithValue("@id", id);

        int filas = cmd.ExecuteNonQuery();

        if (filas > 0)
        {
            Console.WriteLine("Producto actualizado.");
        }
        else
        {
            Console.WriteLine("No se encontro el producto con ese ID.");
        }

        cn.Close();
    }

    static void Eliminar()
    {
        Console.Write("Ingrese ID a eliminar: ");
        string idTexto = Console.ReadLine();
        int id;

        if (!int.TryParse(idTexto, out id))
        {
            Console.WriteLine("El ID no es valido.");
            return;
        }

        SqlConnection cn = new SqlConnection(connectionString);
        cn.Open();

        string sql = "DELETE FROM Productos WHERE Id=@id";
        SqlCommand cmd = new SqlCommand(sql, cn);
        cmd.Parameters.AddWithValue("@id", id);

        int filas = cmd.ExecuteNonQuery();

        if (filas > 0)
        {
            Console.WriteLine("Producto eliminado.");
        }
        else
        {
            Console.WriteLine("No se encontro el producto con ese ID.");
        }

        cn.Close();
    }
}


