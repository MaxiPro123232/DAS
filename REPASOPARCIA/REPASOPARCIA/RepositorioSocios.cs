using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace REPASOPARCIA
{
    public class RepositorioSocios
    {
        #region Cadena y Lista
        private List<Socio> ListaSocio;
        private string cadena = "Data Source = MAXOPC\\SQLEXPRESS;Initial Catalog = club; Integrated Security = True; Persist Security Info=False;Pooling=False; Encrypt=False";
        public RepositorioSocios()
        {
            ListaSocio = new List<Socio>();
        }
        #endregion
        #region Alta
        public void AgregarSocio(Socio socio)
        {
            string query = "INSERT INTO Socios (nombre, apellido, dni, fecha_nacimiento, numero_socio, cuota_al_dia) VALUES (@nombre, @apellido, @dni, @fecha_nacimiento, @numero_socio, @cuota_al_dia)";
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                SqlCommand comando = new SqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@nombre", socio.nombre);
                comando.Parameters.AddWithValue("@apellido", socio.apellido);
                comando.Parameters.AddWithValue("@dni", socio.DNI);
                comando.Parameters.AddWithValue("@fecha_nacimiento", socio.fechaNacimiento);
                comando.Parameters.AddWithValue("@numero_socio", socio.NumSocio);
                comando.Parameters.AddWithValue("@cuota_al_dia", socio.CuotaAlDia);
                try
                {
                    conexion.Open();
                    comando.ExecuteNonQuery();
                    conexion.Close();
                }
                catch (SqlException ex)
                {
                    throw new Exception("Error de BD al agregar el socio: " + ex.Message);
                }
                catch (Exception)
                {
                    throw new Exception("Error inesperado al agregar el socio");
                }
            }
        }
        #endregion
        #region Baja
        public void EliminarSocio(int id)
        {
            const string q = "DELETE FROM Socios WHERE id=@id";
            using (var conexion = new SqlConnection(cadena))
            using (var comando = new SqlCommand(q, conexion))
            {
                comando.Parameters.Add("@id", SqlDbType.Int).Value = id;
                try
                {
                    conexion.Open();
                    int filas = comando.ExecuteNonQuery();
                    conexion.Close();
                    if (filas != 1)
                        throw new Exception("No se encontró el socio para eliminar.");
                }
                catch (SqlException ex)
                {
                    throw new Exception("Error de BD al eliminar el socio: " + ex.Message);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error inesperado al eliminar el socio: " + ex.Message);
                }
            }
        }
        #endregion
        #region Listar
        public List<Socio> ListarSocios()
        {
            ListaSocio.Clear();
            string query = "SELECT id, nombre, apellido, dni, fecha_nacimiento, numero_socio, cuota_al_dia FROM Socios";
            try
            {
                using (SqlConnection conexion = new SqlConnection(cadena))
                {
                    SqlCommand comando = new SqlCommand(query, conexion);
                    conexion.Open();
                    SqlDataReader reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        Socio s = new Socio();
                        s.Id = reader.GetInt32(0);
                        s.nombre = reader.GetString(1);
                        s.apellido = reader.GetString(2);
                        s.DNI = reader.GetString(3);
                        s.fechaNacimiento = reader.GetDateTime(4);
                        s.NumSocio = reader.GetInt32(5);
                        s.CuotaAlDia = reader.GetBoolean(6);
                        ListaSocio.Add(s);
                    }
                    conexion.Close();
                    return ListaSocio;
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error de BD al listar socios: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Otro error inesperado al listar socios: " + ex.Message);
            }
        }
        #endregion
        #region Modificar
        public void ModificarSocio(Socio socio)
        {
            const string q = @"UPDATE Socios SET
               nombre=@n, apellido=@a, dni=@dni, fecha_nacimiento=@f,
               numero_socio=@num, cuota_al_dia=@cuota
               WHERE id=@id";
            using (var cx = new SqlConnection(cadena))
            using (var cmd = new SqlCommand(q, cx))
            {
                cmd.Parameters.Add("@n", SqlDbType.NVarChar, 50).Value = socio.nombre;
                cmd.Parameters.Add("@a", SqlDbType.NVarChar, 50).Value = socio.apellido;
                cmd.Parameters.Add("@dni", SqlDbType.VarChar, 15).Value = socio.DNI;
                cmd.Parameters.Add("@f", SqlDbType.Date).Value = socio.fechaNacimiento.Date;
                cmd.Parameters.Add("@num", SqlDbType.Int).Value = socio.NumSocio;
                cmd.Parameters.Add("@cuota", SqlDbType.Bit).Value = socio.CuotaAlDia;
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = socio.Id;

                try
                {
                    cx.Open();
                    int filas = cmd.ExecuteNonQuery();
                    cx.Close();
                    if (filas != 1)
                        throw new Exception("No se encontró el socio para modificar.");
                }
                catch (SqlException ex)
                {
                    throw new Exception("Error de BD al modificar el socio: " + ex.Message);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error inesperado al modificar el socio: " + ex.Message);
                }
            }
        }
        #endregion
        #region Mayores de esa edad
        public List<Socio> ListarSociosMayoresA(int edad)
        {
            var lista = new List<Socio>();
            const string q = @"
        SELECT id, nombre, apellido, dni, fecha_nacimiento, numero_socio, cuota_al_dia
        FROM Socios
        WHERE DATEADD(year, @edad, fecha_nacimiento) <= CAST(GETDATE() AS date)
        ORDER BY apellido, nombre";
            try
            {
                using (var cx = new SqlConnection(cadena))
                using (var cmd = new SqlCommand(q, cx))
                {
                    cmd.Parameters.Add("@edad", SqlDbType.Int).Value = edad;
                    cx.Open();
                    using (var r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            lista.Add(new Socio
                            {
                                Id = r.GetInt32(0),
                                nombre = r.GetString(1),
                                apellido = r.GetString(2),
                                DNI = r.GetString(3),
                                fechaNacimiento = r.GetDateTime(4),
                                NumSocio = r.GetInt32(5),
                                CuotaAlDia = r.GetBoolean(6)
                            });
                        }
                    }
                }
                return lista;
            }
            catch (SqlException ex)
            {
                throw new Exception("Error de BD al listar socios por edad: " + ex.Message);
            }
        }
        #endregion
        #region Cuotas al dia
        public int ContarSociosConCuotaAlDia()
        {
            return ListarSocios().Count(s => s.CuotaAlDia);
        }
        #endregion  
    }
}