using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;



namespace Ejercicio02
{
     class Program
    {
        // Repos en memoria
        static RepositorioClientes repoClientes = new RepositorioClientes();
        static RepositorioPaquetes repoPaquetes = new RepositorioPaquetes();
        static RepositorioContratos repoContratos = new RepositorioContratos();

        static void Main(string[] args)
        {
            MenuPrincipal();
        }

        static void MenuPrincipal()
        {
            string opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("=== EMPRESA DE CABLE — MENÚ PRINCIPAL ===");
                Console.WriteLine("1) Agregar cliente");
                Console.WriteLine("2) Agregar paquete (Premium / Silver)");
                Console.WriteLine("3) Contratar paquete para un cliente");
                Console.WriteLine("4) Informe: detalle de paquetes y contrataciones");
                Console.WriteLine("5) Informe: total recaudado por mes");
                Console.WriteLine("6) Informe: paquete más vendido");
                Console.WriteLine("7) Informe: series con ranking > 3.5");
                Console.WriteLine("8) Listar clientes");
                Console.WriteLine("0) Salir");
                Console.Write("Opción: ");
                opcion = Console.ReadLine();

                try
                {
                    switch (opcion)
                    {
                        case "1": AltaCliente(); break;
                        case "2": AltaPaquete(); break;
                        case "3": ContratarPaquete(); break;
                        case "4": InformePaquetesYContratos(); break;
                        case "5": InformeTotalRecaudadoPorMes(); break;
                        case "6": InformePaqueteMasVendido(); break;
                        case "7": InformeSeriesRankingMayor(); break;
                        case "8": ListarClientes(); break;
                        case "0": Console.WriteLine("Saliendo..."); break;
                        default: Console.WriteLine("Opción inválida."); Pausa(); break;
                    }
                }
                catch (ClienteNoEncontradoException ex) { Console.WriteLine(ex.Message); Pausa(); }
                catch (PaqueteNoEncontradoException ex) { Console.WriteLine(ex.Message); Pausa(); }
                catch (Exception ex) { Console.WriteLine("Error: " + ex.Message); Pausa(); }

            } while (opcion != "0");
        }

        // === Altas / Contrataciones ===

        static void AltaCliente()
        {
            Console.Clear();
            Console.WriteLine("=== ALTA DE CLIENTE ===");

            int codigo = LeerEntero("Código de cliente: ");
            string nombre = LeerTexto("Nombre: ");
            string apellido = LeerTexto("Apellido: ");
            string dni = LeerTexto("DNI: ");
            DateTime fechaNac = LeerFecha("Fecha de nacimiento (dd/MM/yyyy): ");

            var cliente = new Cliente(codigo, nombre, apellido, dni, fechaNac);
            repoClientes.Agregar(cliente);
            Console.WriteLine("Cliente agregado correctamente.");
            Pausa();
        }

        static void AltaPaquete()
        {
            Console.Clear();
            Console.WriteLine("=== ALTA DE PAQUETE ===");
            Console.WriteLine("1) Premium (+20%)");
            Console.WriteLine("2) Silver (+15%)");
            string tipo = LeerTexto("Tipo (1/2): ");

            string nombre = LeerTexto("Nombre del paquete: ");
            double precioBase = LeerDouble("Precio base: ");

            Paquete paquete;

            if (tipo == "1")
            {
                paquete = new PaquetePremium(nombre, precioBase);
            }
            else if (tipo == "2")
            {
                paquete = new PaqueteSilver(nombre, precioBase);
            }
            else
            {
                Console.WriteLine("Tipo inválido.");
                Pausa();
                return;
            }

            repoPaquetes.Agregar(paquete);
            Console.WriteLine("Paquete agregado correctamente.");
            Pausa();
        }

        static void ContratarPaquete()
        {
            Console.Clear();
            Console.WriteLine("=== CONTRATAR PAQUETE ===");
            int codigoCliente = LeerEntero("Código de cliente: ");
            string nombrePaquete = LeerTexto("Nombre del paquete: ");

            var cliente = repoClientes.BuscarPorCodigo(codigoCliente);
            var paquete = BuscarPaquetePorNombreFlexible(nombrePaquete);

            var contrato = new Contrato(cliente, paquete);
            repoContratos.Agregar(contrato);

            Console.WriteLine("Contrato generado correctamente.");
            Console.WriteLine(contrato.ToString());
            Pausa();
        }

        // === Informes ===

        static void InformePaquetesYContratos()
        {
            Console.Clear();
            Console.WriteLine("=== INFORME: PAQUETES Y CONTRATACIONES ===");

            var paquetes = repoPaquetes.Listar();
            if (paquetes.Count == 0)
            {
                Console.WriteLine("No hay paquetes cargados.");
                Pausa();
                return;
            }

            var contratos = repoContratos.Listar();

            foreach (var p in paquetes)
            {
                Console.WriteLine("-------------------------------------------");
                Console.WriteLine($"Paquete: {p.Nombre}");
                Console.WriteLine($"Precio base: ${p.PrecioBase:0.00}");
                Console.WriteLine($"Precio final: ${p.CalcularPrecioFinal():0.00}");

                // Clientes que lo contrataron
                var clientes = contratos
                    .Where(c => object.ReferenceEquals(c.Paquete, p))
                    .Select(c => c.Cliente)
                    .Distinct()
                    .ToList();

                Console.WriteLine($"Contrataciones: {clientes.Count}");
                if (clientes.Count > 0)
                {
                    Console.WriteLine("Clientes:");
                    foreach (var cli in clientes)
                    {
                        Console.WriteLine($" - {cli}");
                    }
                }


                if (p.Canales != null && p.Canales.Count > 0)
                {
                    Console.WriteLine("Canales:");
                    foreach (var canal in p.Canales)
                    {
                        Console.WriteLine($" * {canal.Nombre}{(canal.EsExclusivo ? " [Exclusivo]" : "")}");
                        if (canal.Series != null && canal.Series.Count > 0)
                        {
                            foreach (var s in canal.Series)
                            {
                                Console.WriteLine($"    - {s.Titulo} (Temp: {s.Temporadas}, Rank: {s.Ranking:0.0}, Dir: {s.Director})");
                                if (s.Episodios != null && s.Episodios.Count > 0)
                                {
                                    Console.WriteLine($"       Episodios ({s.Episodios.Count}):");
                                    foreach (var e in s.Episodios)
                                        Console.WriteLine($"         · {e.Titulo} ({e.DuracionMin} min)");
                                }
                            }
                        }
                    }
                }
               
            }

            Pausa();
        }

        static void InformeTotalRecaudadoPorMes()
        {
            Console.Clear();
            Console.WriteLine("=== INFORME: TOTAL RECAUDADO POR MES ===");

            int anio = LeerEntero("Año (ej. 2025): ");
            int mes = LeerEntero("Mes (1-12): ");

            var contratos = repoContratos.Listar();
            double totalMes = contratos
                .Where(c => c.FechaInicio.Year == anio && c.FechaInicio.Month == mes)
                .Sum(c => c.PrecioFinal);

            Console.WriteLine($"Total recaudado en {mes}/{anio}: ${totalMes:0.00}");

            // Info adicional: total general acumulado (si te sirve)
            double totalGeneral = repoContratos.CalcularTotalRecaudado();
            Console.WriteLine($"Total general acumulado: ${totalGeneral:0.00}");

            Pausa();
        }

        static void InformePaqueteMasVendido()
        {
            Console.Clear();
            Console.WriteLine("=== INFORME: PAQUETE MÁS VENDIDO ===");

            var paquete = repoContratos.PaqueteMasVendido();
            if (paquete == null)
            {
                Console.WriteLine("No hay contrataciones registradas.");
                Pausa();
                return;
            }

            Console.WriteLine($"Paquete más vendido: {paquete.Nombre}");
            Console.WriteLine($"Precio final: ${paquete.CalcularPrecioFinal():0.00}");
            if (paquete.Canales != null && paquete.Canales.Count > 0)
            {
                Console.WriteLine("Contenido:");
                foreach (var canal in paquete.Canales)
                {
                    Console.WriteLine($" * {canal.Nombre}{(canal.EsExclusivo ? " [Exclusivo]" : "")}");
                    if (canal.Series != null && canal.Series.Count > 0)
                    {
                        foreach (var s in canal.Series)
                            Console.WriteLine($"    - {s.Titulo} (Temp: {s.Temporadas}, Rank: {s.Ranking:0.0}, Dir: {s.Director})");
                    }
                }
            }
            // (Opcional) mostrar sus series cuando agregues Canal/Series
            Console.WriteLine("(Para ver canales y series, agregar clase Canal y enlazar Series).");
            Pausa();
        }

        static void InformeSeriesRankingMayor()
        {
            Console.Clear();
            Console.WriteLine("=== INFORME: SERIES CON RANKING > 3.5 ===");

            // Requiere Paquete->Canal->Series cargadas
            bool estructuraLista = false;
            try
            {
                // Si existe la clase Canal y están asociadas series, esto funciona:
                var seriesTop = repoPaquetes.Listar()
                    .SelectMany(p => p.Canales ?? new List<Canal>())
                    .SelectMany(c => c.Series ?? new List<Serie>())
                    .Where(s => s.Ranking > 3.5)
                    .GroupBy(s => s.Titulo)
                    .Select(g => g.First())
                    .OrderByDescending(s => s.Ranking)
                    .ToList();

                if (seriesTop.Count > 0)
                {
                    estructuraLista = true;
                    foreach (var s in seriesTop)
                    {
                        Console.WriteLine($"- {s.Titulo} (Rank {s.Ranking:0.0}, Género: {s.Genero}, Dir: {s.Director})");
                    }
                }
            }
            catch
            {
                // Si no existe Canal todavía o no está enlazado, caemos acá.
            }

            if (!estructuraLista)
            {
                Console.WriteLine("Aún no se pueden listar porque falta enlazar Paquete → Canal → Series.");
            }

            Pausa();
        }

        static void ListarClientes()
        {
            Console.Clear();
            Console.WriteLine("=== LISTADO DE CLIENTES ===");
            var lista = repoClientes.Listar();
            if (lista.Count == 0)
            {
                Console.WriteLine("No hay clientes cargados.");
            }
            else
            {
                foreach (var c in lista)
                {
                    Console.WriteLine($"- {c}");
                }
            }
            Pausa();
        }

        // === Utilitarios ===

        static Paquete BuscarPaquetePorNombreFlexible(string nombre)
        {
            // Búsqueda case-insensitive sobre lo que ya tenés en memoria
            var paquete = repoPaquetes.Listar()
                .FirstOrDefault(p => string.Equals(p.Nombre, nombre, StringComparison.OrdinalIgnoreCase));

            if (paquete == null) throw new PaqueteNoEncontradoException(nombre);
            return paquete;
        }

        static string LeerTexto(string prompt, bool obligatorio = true)
        {
            string? texto;
            do
            {
                Console.Write(prompt);
                texto = Console.ReadLine();
                if (!obligatorio) break;
            } while (string.IsNullOrWhiteSpace(texto));
            return texto ?? string.Empty;
        }

        static int LeerEntero(string prompt)
        {
            int valor;
            while (true)
            {
                Console.Write(prompt);
                var s = Console.ReadLine();
                if (int.TryParse(s, out valor)) return valor;
                Console.WriteLine("Ingrese un número entero válido.");
            }
        }

        static double LeerDouble(string prompt)
        {
            double valor;
            while (true)
            {
                Console.Write(prompt);
                var s = Console.ReadLine();
                // Intento con InvariantCulture y cultura local
                if (double.TryParse(s, NumberStyles.Any, CultureInfo.InvariantCulture, out valor) ||
                    double.TryParse(s, out valor))
                    return valor;

                Console.WriteLine("Ingrese un número válido. Use coma o punto para decimales.");
            }
        }

        static DateTime LeerFecha(string prompt)
        {
            DateTime fecha;
            while (true)
            {
                Console.Write(prompt);
                var s = Console.ReadLine();
                if (DateTime.TryParseExact(s, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out fecha) ||
                    DateTime.TryParse(s, out fecha))
                    return fecha;

                Console.WriteLine("Formato inválido. Ejemplo: 31/12/2000");
            }
        }

        static void Pausa()
        {
            Console.WriteLine();
            Console.Write("Presione una tecla para continuar...");
            Console.ReadKey();
        }
    }
}

