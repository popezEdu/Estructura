using System.ComponentModel.DataAnnotations;

namespace Listas;

class Program
{
    static void Main(string[] args)
    {
        // Console.WriteLine("Trabajando con Listas");
        ListaEnteros lista = new ListaEnteros(6);

        // lista.Agregar(14);
        // Console.WriteLine(lista.ExisteValor(14));
        // Console.WriteLine(lista.ExisteValor(78));
        // Console.WriteLine(lista.ToString());

        // Manejo Manual
        // Nodo nodo = new Nodo();
        // nodo.Valor = 3;

        // Nodo segundo = new Nodo();
        // segundo.Valor = 5;
        // nodo.Puntero = segundo;

        // Nodo tercero = new Nodo();
        // tercero.Valor = 7;
        // segundo.Puntero = tercero;

        // Nodo cuarto = new Nodo();
        // cuarto.Valor = 9;
        // tercero.Puntero = cuarto;

        // Nodo quinto = new Nodo();
        // quinto.Valor = 11;
        // cuarto.Puntero = quinto;

        // Console.WriteLine(ObtenerValor(nodo, 2));
        // Console.WriteLine(ExisteValor(nodo, 11));

        // Manejo mas limpio
        ListaPersonalizada miLista = new ListaPersonalizada();
        Console.WriteLine(miLista.Any.ToString());
        Console.WriteLine(miLista.Cantidad.ToString());
        miLista.Agregar(34);
        Console.WriteLine(miLista.Any.ToString());
        Console.WriteLine(miLista.Cantidad.ToString());
        miLista.Agregar(40);
        miLista.Agregar(50);
        Console.WriteLine(miLista.Cantidad.ToString());
        Console.WriteLine(miLista.Any.ToString());
    }














    public static int ObtenerValor(Nodo cabeza, int posicion)
    {
        if (cabeza == null) return int.MinValue;

        int indice = 0;
        Nodo nodo = cabeza;

        while (nodo != null)
        {
            if (indice == posicion) return nodo.Valor;

            indice++;
            nodo = nodo.Puntero;
        }

        return int.MinValue;
    }

    public static int ExisteValor(Nodo cabeza, int valor)
    {
        if (cabeza == null) return int.MinValue;

        int indice = 0;
        Nodo nodo = cabeza;

        while (nodo != null)
        {
            if (valor == nodo.Valor) return indice;

            indice++;
            nodo = nodo.Puntero;
        }

        return int.MinValue;
    }
}
