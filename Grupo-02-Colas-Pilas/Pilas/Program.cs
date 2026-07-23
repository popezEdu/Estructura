using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Ingrese una cadena para crear la pila: ");
        string cadena = Console.ReadLine();

        Pila pila = new Pila(cadena);
        Pila copia = null;

        int opcion;

        do
        {
            Console.Clear();

            Console.WriteLine("========== MENÚ PILA ==========");
            Console.WriteLine("1. Push");
            Console.WriteLine("2. Pop");
            Console.WriteLine("3. Peek");
            Console.WriteLine("4. Vaciar pila");
            Console.WriteLine("5. Clonar pila");
            Console.WriteLine("6. Buscar elemento");
            Console.WriteLine("7. Mostrar pila");
            Console.WriteLine("8. Mostrar copia");
            Console.WriteLine("0. Salir");
            Console.WriteLine("===============================");

            Console.Write("Seleccione una opción: ");

            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine("Opción inválida.");
                Console.ReadKey();
                continue;
            }

            Console.Clear();

            switch (opcion)
            {
                case 1:

                    Console.Write("Ingrese un carácter: ");

                    char caracter = char.Parse(Console.ReadLine());

                    pila.Push(caracter);

                    Console.WriteLine("Elemento agregado correctamente.");

                    break;

                case 2:

                    try
                    {
                        Console.WriteLine("Elemento eliminado: " + pila.Pop());
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                    break;

                case 3:

                    try
                    {
                        Console.WriteLine("Elemento en la cima: " + pila.Peek());
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                    break;

                case 4:

                    pila.VaciarPila();

                    Console.WriteLine("La pila fue vaciada.");

                    break;

                case 5:

                    copia = pila.Clonar();

                    Console.WriteLine("Pila clonada correctamente.");

                    break;

                case 6:

                    Console.Write("Ingrese el carácter a buscar: ");

                    char buscar = char.Parse(Console.ReadLine());

                    if (pila.ContieneElemento(buscar))
                        Console.WriteLine("El elemento existe en la pila.");
                    else
                        Console.WriteLine("El elemento NO existe.");

                    break;

                case 7:

                    Console.WriteLine("Contenido de la pila:");

                    MostrarPila(pila);

                    break;

                case 8:

                    if (copia == null)
                    {
                        Console.WriteLine("Primero debe clonar la pila.");
                    }
                    else
                    {
                        Console.WriteLine("Contenido de la copia:");

                        MostrarPila(copia);
                    }

                    break;

                case 0:

                    Console.WriteLine("Hasta luego.");

                    break;

                default:

                    Console.WriteLine("Opción no válida.");

                    break;
            }

            if (opcion != 0)
            {
                Console.WriteLine("\nPresione una tecla para continuar...");
                Console.ReadKey();
            }

        } while (opcion != 0);
    }

    static void MostrarPila(Pila pila)
    {
        Pila auxiliar = pila.Clonar();

        while (true)
        {
            try
            {
                Console.Write(auxiliar.Pop() + " ");
            }
            catch
            {
                break;
            }
        }

        Console.WriteLine();
    }
}