using System;

class Program
{
    static Pila miPila = new Pila(3); 
    static Cola miCola = new Cola(new string[] { "Goku", "Vegeta", "Trunks" });

    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("PILA:");
            Console.WriteLine("1. Push");
            Console.WriteLine("2. Pop");
            Console.WriteLine("3. Peek");
            Console.WriteLine("4. Tamaño");
            Console.WriteLine("5. Mostrar");
            Console.WriteLine();
            Console.WriteLine("COLA:");
            Console.WriteLine("6. Encolar");
            Console.WriteLine("7. Desencolar");
            Console.WriteLine("8. Peek");
            Console.WriteLine("9. Clonar");
            Console.WriteLine("10. Buscar");
            Console.WriteLine("11. Vaciar");
            Console.WriteLine("12. Mostrar");
            Console.WriteLine();
            Console.WriteLine("0. Salir");
            Console.Write("Opción: ");

            string opcion = Console.ReadLine();
            if (opcion == "0") break;

            Console.WriteLine();
            try
            {
                switch (opcion)
                {
                    case "1":
                        Console.Write("Valor (1-50): ");
                        miPila.Push(int.Parse(Console.ReadLine()));
                        break;
                    case "2": Console.WriteLine($"Pop: {miPila.Pop()}"); break;
                    case "3": Console.WriteLine($"Tope: {miPila.Peek()}"); break;
                    case "4": Console.WriteLine($"Tamaño: {miPila.Tamano()}"); break;
                    case "5": Console.WriteLine($"Pila: {miPila.ToString()}"); break;
                    
                    case "6":
                        Console.Write("Texto a encolar: ");
                        miCola.Encolar(Console.ReadLine());
                        break;
                    case "7": Console.WriteLine($"Desencolado: {miCola.DesenColar()}"); break;
                    case "8": Console.WriteLine($"Frente: {miCola.Peek()}"); break;
                    case "9": Console.WriteLine($"Clon: {miCola.Clonar().ToString()}"); break;
                    case "10":
                        Console.Write("Texto a buscar: ");
                        Console.WriteLine($"¿Existe?: {miCola.ContenieneElemento(Console.ReadLine())}");
                        break;
                    case "11": 
                        miCola.VaciarCola(); 
                        Console.WriteLine("Cola vaciada."); 
                        break;
                    case "12": Console.WriteLine($"Cola: {miCola.ToString()}"); break;
                    
                    default: Console.WriteLine("Opción inválida."); break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.WriteLine("\nEnter para continuar...");
            Console.ReadLine();
        }
    }
}