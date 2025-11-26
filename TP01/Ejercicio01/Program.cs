using Ejercicio01;

var repoClientes = new RepositorioClientes();
var repoCuentas = new RepositorioCuentas();
IBancoService banco = new BancoService(repoClientes, repoCuentas);

while (true)
{
    Console.WriteLine("\n=== BANCO – MENÚ ===");
    Console.WriteLine("1) Alta cliente");
    Console.WriteLine("2) Listar clientes");
    Console.WriteLine("3) Crear Caja de Ahorro");
    Console.WriteLine("4) Crear Cuenta Corriente");
    Console.WriteLine("5) Depositar");
    Console.WriteLine("6) Extraer");
    Console.WriteLine("7) Listar cuentas por DNI");
    Console.WriteLine("0) Salir");
    Console.Write("Opción: ");
    var op = Console.ReadLine();

    try
    {
        switch (op)
        {
            case "1":
                Console.Write("DNI: "); var dni = Console.ReadLine()!;
                Console.Write("Nombre y Apellido: "); var nom = Console.ReadLine()!;
                Console.Write("Teléfono: "); var tel = Console.ReadLine()!;
                Console.Write("Email: "); var mail = Console.ReadLine()!;
                Console.Write("Fecha Nac (yyyy-mm-dd): "); var fn = DateTime.Parse(Console.ReadLine()!);
                banco.AltaCliente(new Cliente(dni, nom, tel, mail, fn));
                Console.WriteLine("✔ Cliente creado.");
                break;

            case "2":
                foreach (var c in banco.ListarClientes())
                    Console.WriteLine($"- {c.Dni} | {c.NombreApellido} | Edad: {c.Edad}");
                break;

            case "3":
                Console.Write("Código cuenta: "); var codCA = Console.ReadLine()!;
                Console.Write("DNI titular: "); var dniCA = Console.ReadLine()!;
                Console.Write("Tope extracción: "); var tope = decimal.Parse(Console.ReadLine()!);
                banco.CrearCajaDeAhorro(codCA, dniCA, tope);
                Console.WriteLine("✔ Caja de Ahorro creada.");
                break;

            case "4":
                Console.Write("Código cuenta: "); var codCC = Console.ReadLine()!;
                Console.Write("DNI titular: "); var dniCC = Console.ReadLine()!;
                Console.Write("Límite descubierto: "); var lim = decimal.Parse(Console.ReadLine()!);
                banco.CrearCuentaCorriente(codCC, dniCC, lim);
                Console.WriteLine("✔ Cuenta Corriente creada.");
                break;

            case "5":
                Console.Write("Código cuenta: "); var codDep = Console.ReadLine()!;
                Console.Write("Importe: "); var impDep = decimal.Parse(Console.ReadLine()!);
                banco.Depositar(codDep, impDep);
                Console.WriteLine("✔ Depósito realizado.");
                break;

            case "6":
                Console.Write("Código cuenta: "); var codExt = Console.ReadLine()!;
                Console.Write("Importe: "); var impExt = decimal.Parse(Console.ReadLine()!);
                banco.Extraer(codExt, impExt);
                Console.WriteLine("✔ Extracción realizada.");
                break;

            case "7":
                Console.Write("DNI: "); var dniList = Console.ReadLine()!;
                var cuentas = banco.ListarCuentasDe(dniList).ToList();
                if (!cuentas.Any()) { Console.WriteLine("No hay cuentas."); break; }
                foreach (var cu in cuentas)
                {
                    var tipo = cu is CajaDeAhorro ? "CA" : "CC";
                    Console.WriteLine($"- {cu.Codigo} ({tipo}) | Saldo: {cu.Saldo}");
                }
                break;

            case "0": return;
            default: Console.WriteLine("Opción inválida."); break;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine("⚠ Error: " + ex.Message);
    }
}