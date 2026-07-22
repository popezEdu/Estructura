using System.Runtime.InteropServices;
using System.Threading.Tasks.Sources;

public class Cola
{
    public Nodo Frente;
    public Nodo Final;
    private int Contador;
    public bool EstaVacia() => Frente==null;

    public Cola (int cantidad)
    {
        Random random = new Random();
        while (cantidad > 0)
        {
            Encolar(random.Next(1,51));
            cantidad--;
        }
    }

    public Cola()
    {
        Frente = null;
        Final = null;
    }

    public void Encolar(int encolado)
    {
        if (Frente == null && Final == null)
        {
            Nodo nodo = new Nodo();
            nodo.Valor = encolado;
            Frente = nodo;
            Final = nodo;
            Contador++;
        }
        else
        {
            //Ya tenemos el Final definido, solo lo actualizamos.
            Nodo actual = Final;
            Nodo nodoNuevo = new Nodo();
            nodoNuevo.Valor = encolado;
            nodoNuevo.Next = actual;
            actual.Back = nodoNuevo;
            Final = nodoNuevo;
            Contador++;
        }
    }

    public int Desencolar()
    {
        int resultado = 0;

        if (Frente == null) throw new InvalidOperationException("Lista vacia");
        if (Frente.Back == null)
        {
            resultado = Frente.Valor;
            Frente = null;
            Final = null;
            Contador --;
        }
        else
        {
            Nodo nodo = Frente;
            Nodo antes = nodo.Back;
            resultado = nodo.Valor;
            antes.Next = null;
            Frente = antes;
            Contador --;
        }
        return resultado;
    }

    public int Peek()
    {
        if (!EstaVacia()) return Frente.Valor;
        return 0;
    }

    public int Tamanio()
    {
        return Contador;
    }
    public override string ToString()
    {
        if (Frente == null) return "[]"; 
        if (Frente == Final) return $"[FRENTE: {Frente.Valor}: FINAL]";
        Nodo nodo = Frente;
        string resultado = $"[FRENTE: {nodo.Valor}]";
        nodo = nodo.Back;
        while(nodo.Back != null)
        {
            resultado += $"[{nodo.Valor}]";
            nodo = nodo.Back;
        }
        resultado += $"[{nodo.Valor}: FINAL]";
        return resultado;
    }



}