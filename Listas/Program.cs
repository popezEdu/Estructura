namespace Listas;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Trabajando con Listas");
        ListaEnteros lista = new ListaEnteros(6);

        lista.Agregar(14);
        Console.WriteLine(lista.ExisteValor(14));
        Console.WriteLine(lista.ExisteValor(78));
        Console.WriteLine(lista.ToString());

        // Creamos un nodo
        Nodo nodo = new Nodo();

    }
}
