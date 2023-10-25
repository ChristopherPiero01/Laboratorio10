using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendadeCelulares
{
    internal class Program
    {
        static void MostrarEstadisticasFinales(int[] ventasProductos, string[] nombresProductos)
        {
            int totalVendido = 0;
            Console.Clear();
            Console.WriteLine("================================\nReporte Final\n================================");
            Console.WriteLine("Productos Vendidos | Cantidad");
            Console.WriteLine("--------------------------------");
            
            string[] nombresMostrar = { "mPhones", "mPads", "MAPBrooks", "mWatches" };

            for (int i = 0; i < nombresProductos.Length; i++)
            {
                Console.WriteLine($"{nombresMostrar[i].PadRight(20)}| {ventasProductos[i]}");
                totalVendido += ventasProductos[i];
            }

            Console.WriteLine("--------------------------------");
            Console.WriteLine($"Total{"".PadRight(21)}| {totalVendido}");
            Console.WriteLine("================================");
            Console.WriteLine("¡Hasta Luego!\n\n \n \n \nDiseñado Por: Christopher Piero Bellido");
            Console.ReadLine();
        }
        static int RegistrarVenta(string producto)
        {
            Console.Clear();
            Console.WriteLine($"================================\nRegistrar venta de:\n================================");
            Console.WriteLine($"Se va a registrar la venta de un {producto} ¿Desea Continuar?");
            Console.WriteLine("1: Sí\n2: No\n================================");
            int opcion = PedirOpcion();

            int ventas = 0;
            if (opcion == 1)
            {
                Console.Write($"Ingrese unidades vendidas de {producto}: ");
                ventas = int.Parse(Console.ReadLine());
                Console.WriteLine($"Se han registrado {ventas} ventas para {producto}.");
            }
            Console.WriteLine("\nPresione una tecla para continuar...");
            Console.ReadKey();
            return ventas;
        }

        static int DevolucionProducto(string producto, int ventasActuales)
        {
            Console.Clear();
            Console.WriteLine($"================================\nRegistrar devolución de:\n================================");
            Console.WriteLine($"Se va a registrar la devolución de {producto} ¿Desea Continuar?");
            Console.WriteLine("1: Sí\n2: No\n================================");
            int opcion = PedirOpcion();

            if (opcion == 1 && ventasActuales > 0)
            {
                Console.Clear();
                Console.Write($"¿Cuántas unidades de {producto} desea devolver? \n (Actualmente ha vendido {ventasActuales} unidades): ");
                int devoluciones = int.Parse(Console.ReadLine());

                if (devoluciones <= ventasActuales)
                {
                    ventasActuales -= devoluciones;
                    Console.WriteLine($"Se ha registrado la devolución de {devoluciones} unidades de {producto}.");
                }
                else
                {
                    Console.WriteLine("No puede devolver más unidades de las que ha vendido.");
                }
            }
            else if (ventasActuales <= 0)
            {
                Console.WriteLine($"No hay ventas registradas de {producto} para devolver.");
            }

            Console.WriteLine("\nPresione una tecla para continuar...");
            Console.ReadKey();

            return ventasActuales;
        }

        static int PedirOpcion()
        {
            Console.Write("Ingrese una opción: ");
            return int.Parse(Console.ReadLine());
        }

        static void Main()
        {
            int[] ventasProductos = new int[4];
            string[] nombresProductos = { "mPhone 3000", "mPad 3500", "MAPBrook 3800", "mWatch 8000" };

            while (true)
            {
                Console.Clear();
                Console.WriteLine("================================\nProductos de mPhone\n================================");
                for (int i = 0; i < nombresProductos.Length; i++)
                {
                    Console.WriteLine($"{i + 1}: Ventas de {nombresProductos[i]}");
                }
                Console.WriteLine($"{nombresProductos.Length + 1}: Salir\n================================");
                int opcion = PedirOpcion();

                if (opcion >= 1 && opcion <= nombresProductos.Length)
                {
                    Console.Clear();
                    Console.WriteLine($"================================\nRegistrar Venta de {nombresProductos[opcion - 1]}\n================================");
                    Console.WriteLine("1: Registrar Venta\n2: Registrar Devolución\n3: Menu Principal\n================================");
                    int subopcion = PedirOpcion();

                    if (subopcion == 1)
                    {
                        ventasProductos[opcion - 1] += RegistrarVenta(nombresProductos[opcion - 1]);
                    }
                    else if (subopcion == 2)
                    {
                        ventasProductos[opcion - 1] = DevolucionProducto(nombresProductos[opcion - 1], ventasProductos[opcion - 1]);
                    }
                }
                else
                {
                    Console.WriteLine("Opción inválida. Intente nuevamente.");
                }
                if (opcion == nombresProductos.Length + 1)
                {
                    MostrarEstadisticasFinales(ventasProductos, nombresProductos);
                    return;
                }
            }
        }
    }
}
