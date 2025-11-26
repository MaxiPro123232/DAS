using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ado_multiplestablas
{
        public class RepositorioPasajes
        {
            private List<Avion> listaAviones;
            private List<Pasajero> listaPasajeros;
            private List<PasajeVista> listaPasajes;

            private string cadena = "Data Source=MAXOPC\\SQLEXPRESS;Initial Catalog=PasajesAviones;Integrated Security=True;Persist Security Info=False;Pooling=False;Encrypt=False";

            public RepositorioPasajes()
            {
                listaAviones = new List<Avion>();
                listaPasajeros = new List<Pasajero>();
                listaPasajes = new List<PasajeVista>();
            }

            public List<Avion> ListarAviones()
            {
                listaAviones.Clear();
                string query = "SELECT IdAvion, Matricula, Modelo, Capacidad FROM Avion";
                try
                {
                    using (SqlConnection conexion = new SqlConnection(cadena))
                    {
                        SqlCommand comando = new SqlCommand(query, conexion);
                        conexion.Open();
                        SqlDataReader reader = comando.ExecuteReader();

                        while (reader.Read())
                        {
                            Avion a = new Avion();
                            a.IdAvion = int.Parse(reader["IdAvion"].ToString());
                            a.Matricula = reader["Matricula"].ToString();
                            a.Modelo = reader["Modelo"].ToString();
                            a.Capacidad = int.Parse(reader["Capacidad"].ToString());
                            listaAviones.Add(a);
                        }
                        conexion.Close();
                        return listaAviones;
                    }
                }
                catch (SqlException ex)
                {
                    throw new Exception("Error de BD al listar aviones: " + ex.Message);
                }
                catch (Exception ex)
                {
                    throw new Exception("Otro error inesperado al listar aviones: " + ex.Message);
                }
            }

            public string AgregarAvion(Avion avion)
            {
                string query = "INSERT INTO Avion (Matricula, Modelo, Capacidad) VALUES (@Matricula, @Modelo, @Capacidad)";
                using (SqlConnection conexion = new SqlConnection(cadena))
                {
                    SqlCommand comando = new SqlCommand(query, conexion);
                    comando.Parameters.AddWithValue("@Matricula", avion.Matricula);
                    comando.Parameters.AddWithValue("@Modelo", avion.Modelo);
                    comando.Parameters.AddWithValue("@Capacidad", avion.Capacidad);
                    try
                    {
                        conexion.Open();
                        comando.ExecuteNonQuery();
                        conexion.Close();
                        return "Avión agregado correctamente";
                    }
                    catch (SqlException ex)
                    {
                        throw new Exception("Error de BD al agregar avión: " + ex.Message);
                    }
                    catch (Exception)
                    {
                        throw new Exception("Error inesperado al agregar avión");
                    }
                }
            }

            public List<Pasajero> ListarPasajeros()
            {
                listaPasajeros.Clear();
                string query = "SELECT IdPasajero, Pasaporte, NombreApellido, Nacionalidad, FechaNacimiento FROM Pasajero";
                try
                {
                    using (SqlConnection conexion = new SqlConnection(cadena))
                    {
                        SqlCommand comando = new SqlCommand(query, conexion);
                        conexion.Open();
                        SqlDataReader reader = comando.ExecuteReader();

                        while (reader.Read())
                        {
                            Pasajero p = new Pasajero();
                            p.IdPasajero = int.Parse(reader["IdPasajero"].ToString());
                            p.Pasaporte = reader["Pasaporte"].ToString();
                            p.NombreApellido = reader["NombreApellido"].ToString();
                            p.Nacionalidad = reader["Nacionalidad"] == DBNull.Value ? null : reader["Nacionalidad"].ToString();
                            p.FechaNacimiento = reader["FechaNacimiento"] == DBNull.Value ? (DateTime?)null : DateTime.Parse(reader["FechaNacimiento"].ToString());
                            listaPasajeros.Add(p);
                        }
                        conexion.Close();
                        return listaPasajeros;
                    }
                }
                catch (SqlException ex)
                {
                    throw new Exception("Error de BD al listar pasajeros: " + ex.Message);
                }
                catch (Exception ex)
                {
                    throw new Exception("Otro error inesperado al listar pasajeros: " + ex.Message);
                }
            }

            public string AgregarPasajero(Pasajero pasajero)
            {
                string query = @"INSERT INTO Pasajero (Pasaporte, NombreApellido, Nacionalidad, FechaNacimiento)
                             VALUES (@Pasaporte, @NombreApellido, @Nacionalidad, @FechaNacimiento)";
                using (SqlConnection conexion = new SqlConnection(cadena))
                {
                    SqlCommand comando = new SqlCommand(query, conexion);
                    comando.Parameters.AddWithValue("@Pasaporte", pasajero.Pasaporte);
                    comando.Parameters.AddWithValue("@NombreApellido", pasajero.NombreApellido);
                    comando.Parameters.AddWithValue("@Nacionalidad", (object?)pasajero.Nacionalidad ?? DBNull.Value);
                    comando.Parameters.AddWithValue("@FechaNacimiento", (object?)pasajero.FechaNacimiento ?? DBNull.Value);

                    try
                    {
                        conexion.Open();
                        comando.ExecuteNonQuery();
                        conexion.Close();
                        return "Pasajero agregado correctamente";
                    }
                    catch (SqlException ex)
                    {
                        throw new Exception("Error de BD al agregar pasajero: " + ex.Message);
                    }
                    catch (Exception)
                    {
                        throw new Exception("Error inesperado al agregar pasajero");
                    }
                }
            }

            public List<PasajeVista> ListarPasajes()
            {
                listaPasajes.Clear();
                string query = @"
                SELECT pa.IdPasaje,
                       pa.NumeroAsiento,
                       pa.FechaVuelo,
                       a.IdAvion,
                       a.Matricula AS MatriculaAvion,
                       p.IdPasajero,
                       p.NombreApellido AS NombrePasajero
                FROM Pasaje pa
                INNER JOIN Avion a ON pa.IdAvion = a.IdAvion
                INNER JOIN Pasajero p ON pa.IdPasajero = p.IdPasajero
                ORDER BY pa.FechaVuelo, pa.NumeroAsiento";
                try
                {
                    using (SqlConnection conexion = new SqlConnection(cadena))
                    {
                        SqlCommand comando = new SqlCommand(query, conexion);
                        conexion.Open();
                        SqlDataReader reader = comando.ExecuteReader();

                        while (reader.Read())
                        {
                            PasajeVista pv = new PasajeVista();
                            pv.IdPasaje = int.Parse(reader["IdPasaje"].ToString());
                            pv.NumeroAsiento = reader["NumeroAsiento"].ToString();
                            pv.FechaVuelo = DateTime.Parse(reader["FechaVuelo"].ToString());
                            pv.IdAvion = int.Parse(reader["IdAvion"].ToString());
                            pv.MatriculaAvion = reader["MatriculaAvion"].ToString();
                            pv.IdPasajero = int.Parse(reader["IdPasajero"].ToString());
                            pv.NombrePasajero = reader["NombrePasajero"].ToString();
                            listaPasajes.Add(pv);
                        }
                        conexion.Close();
                        return listaPasajes;
                    }
                }
                catch (SqlException ex)
                {
                    throw new Exception("Error de BD al listar pasajes: " + ex.Message);
                }
                catch (Exception ex)
                {
                    throw new Exception("Otro error inesperado al listar pasajes: " + ex.Message);
                }
            }

            public string AgregarPasaje(Pasaje pasaje)
            {
                string query = @"INSERT INTO Pasaje (NumeroAsiento, FechaVuelo, IdAvion, IdPasajero)
                             VALUES (@NumeroAsiento, @FechaVuelo, @IdAvion, @IdPasajero)";
                using (SqlConnection conexion = new SqlConnection(cadena))
                {
                    SqlCommand comando = new SqlCommand(query, conexion);
                    comando.Parameters.AddWithValue("@NumeroAsiento", pasaje.NumeroAsiento);
                    comando.Parameters.AddWithValue("@FechaVuelo", pasaje.FechaVuelo);
                    comando.Parameters.AddWithValue("@IdAvion", pasaje.IdAvion);
                    comando.Parameters.AddWithValue("@IdPasajero", pasaje.IdPasajero);

                    try
                    {
                        conexion.Open();
                        comando.ExecuteNonQuery();
                        conexion.Close();
                        return "Pasaje agregado correctamente";
                    }
                    catch (SqlException ex)
                    {
                        throw new Exception("Error de BD al agregar pasaje: " + ex.Message);
                    }
                    catch (Exception)
                    {
                        throw new Exception("Error inesperado al agregar pasaje");
                    }
                }
            }
        }
    }