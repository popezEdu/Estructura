using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Title = "Cola con Lista Enlazada";
        Console.Write("Ingrese la cantidad de elementos: ");
        int cantidad = int.Parse(Console.ReadLine());

        Console.Write("Ingrese el valor mínimo del rango: ");
        int minimo = int.Parse(Console.ReadLine());

        Console.Write("Ingrese el valor máximo del rango: ");
        int maximo = int.Parse(Console.ReadLine());

        Cola cola = new Cola(cantidad, minimo, maximo);

        int opcion;

        do
        {
            Console.Clear();

            Console.WriteLine("            MENÚ PRINCIPAL");
            Console.WriteLine("1. Mostrar cola");
            Console.WriteLine("2. Encolar elemento");
            Console.WriteLine("3. Desencolar elemento");
            Console.WriteLine("4. Ver primer elemento (Peek)");
            Console.WriteLine("5. Rotar cola");
            Console.WriteLine("6. Buscar posición de un valor");
            Console.WriteLine("7. Mostrar tamaño");
            Console.WriteLine("8. Salir");

            Console.Write("Seleccione una opción: ");
            opcion = int.Parse(Console.ReadLine());

            Console.Clear();

            try
            {
                switch (opcion)
                {
                    case 1:
                        Console.WriteLine("Contenido de la cola:");
                        Console.WriteLine(cola);
                        break;

                    case 2:

                        Console.Write("Ingrese el número a encolar: ");
                        int nuevo = int.Parse(Console.ReadLine());

                        cola.Encolar(nuevo);

                        Console.WriteLine("\nElemento agregado correctamente.");
                        Console.WriteLine(cola);
                        break;

                    case 3:

                        int eliminado = cola.Desencolar();

                        Console.WriteLine("Elemento eliminado: " + eliminado);
                        Console.WriteLine(cola);
                        break;

                    case 4:

                        Console.WriteLine("Primer elemento de la cola:");
                        Console.WriteLine(cola.Peek());
                        break;

                    case 5:

                        cola.Rotar();

                        Console.WriteLine("La cola fue rotada correctamente.");
                        Console.WriteLine(cola);
                        break;

                    case 6:

                        Console.Write("Ingrese el valor que desea buscar: ");
                        int buscar = int.Parse(Console.ReadLine());

                        int posicion = cola.ObtenerPosicion(buscar);

                        if (posicion == -1)
                        {
                            Console.WriteLine("El valor no se encuentra en la cola.");
                        }
                        else
                        {
                            Console.WriteLine("El valor se encuentra en la posición: " + posicion);
                        }

                        break;

                    case 7:

                        Console.WriteLine("Cantidad de elementos: " + cola.Tamaño());
                        break;

                    case 8:

                        Console.WriteLine("Gracias por utilizar el programa.");
                        break;

                    default:

                        Console.WriteLine("Opción incorrecta.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            if (opcion != 8)
            {
                Console.WriteLine("\nPresione una tecla para continuar...");
                Console.ReadKey();
            }

        } while (opcion != 8);
    }
}