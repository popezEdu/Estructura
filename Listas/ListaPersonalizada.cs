using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;

public class ListaPersonalizada
{
    private Nodo cabeza;
    private int contador;
    public ListaPersonalizada()
    {
        contador = 0;
    }

    public void Agregar(int valor)
    {
        if (cabeza == null)
        {
            cabeza = new Nodo();
            cabeza.Valor = valor;
        }
        else
        {
            Nodo nodo = cabeza;
            while (nodo.Puntero != null)
            {
                nodo = nodo.Puntero;
            }

            Nodo nuevoNodo = new Nodo();
            nuevoNodo.Valor = valor;
            nodo.Puntero = nuevoNodo;
        }

        contador++;
    }

    public int Cantidad => contador;

    public bool Any => (contador > 0);
    // public int Cantidad
    // {
    //     get
    //     {
    //         return contador;
    //     }
    // }

    public int ObtenerValor(int posicion)
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
}