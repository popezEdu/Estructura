using System;

namespace TrabajoGrupo1;

class Program
{
    static PilaEnlazadaSimple pila = new PilaEnlazadaSimple();
    static Cola cola = new Cola();

    static void Main(string[] args)
    {
        int opcion;
        do
        {
            MostrarMenu();
            opcion = LeerOpcion();

            switch (opcion)
            {
                case 1: MenuPila(); break;
                case 2: MenuCola(); break;
                case 0: Console.WriteLine("Saliendo..."); break;
                default: Console.WriteLine("Opción inválida."); break;
            }

        } while (opcion != 0);
    }

    static void MostrarMenu()
    {
        Console.WriteLine();
        Console.WriteLine("=== MENU PRINCIPAL ===");
        Console.WriteLine("1. Probar Pila");
        Console.WriteLine("2. Probar Cola");
        Console.WriteLine("0. Salir");
        Console.Write("Elige una opción: ");
    }

    static int LeerOpcion()
    {
        string? input = Console.ReadLine();
        if (input == null) return 0; 
        bool valido = int.TryParse(input, out int op);
        return valido ? op : -1;
    }

    static void MenuPila()
    {
        int opcion;
        do
        {
            Console.WriteLine();
            Console.WriteLine("--- MENU PILA ---");
            Console.WriteLine("1. Push");
            Console.WriteLine("2. Pop");
            Console.WriteLine("3. Peek");
            Console.WriteLine("4. Invertir");
            Console.WriteLine("5. ObtenerMaximo");
            Console.WriteLine("6. Tamaño");
            Console.WriteLine("7. Mostrar pila completa");
            Console.WriteLine("8. Crear pila desde array de ejemplo");
            Console.WriteLine("0. Volver");
            Console.Write("Elige una opción: ");
            opcion = LeerOpcion();

            switch (opcion)
            {
                case 1:
                    Console.Write("Valor a apilar (double): ");
                    double valorPush;
                    if (double.TryParse(Console.ReadLine(), out valorPush))
                    {
                        pila.Push(valorPush);
                        Console.WriteLine($"Se apiló {valorPush}. Tamaño actual: {pila.Tamanio()}");
                    }
                    else
                    {
                        Console.WriteLine("Valor inválido.");
                    }
                    break;

                case 2:
                    try
                    {
                        double valorPop = pila.Pop();
                        Console.WriteLine($"Se desapiló: {valorPop}. Tamaño actual: {pila.Tamanio()}");
                    }
                    catch (InvalidOperationException ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                    break;

                case 3:
                    try
                    {
                        Console.WriteLine($"Tope actual: {pila.Peek()}");
                    }
                    catch (InvalidOperationException ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                    break;

                case 4:
                    pila.Invertir();
                    Console.WriteLine($"Pila invertida. Tamaño actual: {pila.Tamanio()}");
                    Console.WriteLine(pila.Mostrar());
                    break;

                case 5:
                    try
                    {
                        Console.WriteLine($"Valor máximo: {pila.ObtenerMaximo()}");
                    }
                    catch (InvalidOperationException ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                    break;

                case 6:
                    Console.WriteLine($"Tamaño actual: {pila.Tamanio()}");
                    break;

                case 7:
                    Console.WriteLine("Contenido (tope -> fondo):");
                    Console.WriteLine(pila.Mostrar());
                    break;

                case 8:
                    double[] ejemplo = { 34.12, 12.3, 10.5, 11.4 };
                    pila = new PilaEnlazadaSimple(ejemplo);
                    Console.WriteLine("Pila creada desde array {34.12, 12.3, 10.5, 11.4}.");
                    Console.WriteLine($"El tope debería ser 11.4. Tope actual: {pila.Peek()}");
                    break;

                case 0:
                    break;

                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }

        } while (opcion != 0);
    }

    static void MenuCola()
    {
        int opcion;
        do
        {
            Console.WriteLine();
            Console.WriteLine("--- MENU COLA ---");
            Console.WriteLine("1. Encolar");
            Console.WriteLine("2. Desencolar");
            Console.WriteLine("3. Peek/Frente");
            Console.WriteLine("4. EstaVacia");
            Console.WriteLine("5. Tamaño");
            Console.WriteLine("6. Mostrar (ToString)");
            Console.WriteLine("7. Crear cola aleatoria (N elementos)");
            Console.WriteLine("0. Volver");
            Console.Write("Elige una opción: ");
            opcion = LeerOpcion();

            switch (opcion)
            {
                case 1:
                    Console.Write("Valor a encolar (1-50): ");
                    int valorEncolar;
                    if (int.TryParse(Console.ReadLine(), out valorEncolar))
                    {
                        cola.Encolar(valorEncolar);
                        Console.WriteLine($"Se encoló {valorEncolar}. Tamaño actual: {cola.Tamanio()}");
                    }
                    else
                    {
                        Console.WriteLine("Valor inválido.");
                    }
                    break;

                case 2:
                    try
                    {
                        int valorDesencolar = cola.Desencolar();
                        Console.WriteLine($"Se desencoló: {valorDesencolar}. Tamaño actual: {cola.Tamanio()}");
                    }
                    catch (InvalidOperationException ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                    break;

                case 3:
                    if (cola.EstaVacia())
                        Console.WriteLine("La cola está vacía.");
                    else
                        Console.WriteLine($"Frente actual: {cola.Peek()}");
                    break;

                case 4:
                    Console.WriteLine($"¿Está vacía?: {cola.EstaVacia()}");
                    break;

                case 5:
                    Console.WriteLine($"Tamaño actual: {cola.Tamanio()}");
                    break;

                case 6:
                    if (cola.EstaVacia())
                        Console.WriteLine("La cola está vacía.");
                    else
                        Console.WriteLine(cola.ToString());
                    break;

                case 7:
                    Console.Write("¿Cuántos elementos aleatorios quieres encolar?: ");
                    int n;
                    if (int.TryParse(Console.ReadLine(), out n))
                    {
                        cola = new Cola(n);
                        Console.WriteLine($"Cola creada con {n} elementos aleatorios.");
                        Console.WriteLine(cola.ToString());
                    }
                    else
                    {
                        Console.WriteLine("Valor inválido.");
                    }
                    break;

                case 0:
                    break;

                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }

        } while (opcion != 0);
    }
}