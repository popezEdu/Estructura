using System.ComponentModel;

public class PilaEnlazadaSimple
{
    public NodoPila Tope;
    private int Contador;
    public PilaEnlazadaSimple()
    {
        Tope = null;
        Contador = 0;
    }
    public PilaEnlazadaSimple(double[] array)
    {
        for(int i = 0; i < array.Length; i++)
        {
            Push(array[i]);
        }
    }
    public void Push(double valor)
    {
        if (Tope == null)
        {
            NodoPila nodo = new NodoPila();
            nodo.Valor = valor;
            Tope = nodo;
            Contador++;
        }
        else
        {
            NodoPila nodonuevo = new NodoPila();
            NodoPila nodo = Tope;
            nodonuevo.Valor = valor;
            nodo.Next = nodonuevo;
            nodonuevo.Back = nodo;
            Tope = nodonuevo;
            Contador++;
        }
    }

    public double Pop()
    {
        if (Tope == null) throw new InvalidOperationException("Underflow: la pila está vacía");
        double retorno = 0;
        NodoPila nodo = Tope;
        retorno = nodo.Valor;
        if (nodo.Next == null && nodo.Back == null)
        {
            Tope = null;
            Contador --;
        }
        else
        {
            NodoPila nodoAnterior = Tope.Back;
            Tope = nodoAnterior;
            nodoAnterior.Next = null;  
            Contador --;          
        }
        return retorno;
    }

    public double Peek()
    {
        if (Tope == null) throw new InvalidOperationException("Underflow: la pila está vacía");
        NodoPila nodo = Tope;
        double retorno = nodo.Valor;
        return retorno;   
    }

    public void Invertir()
    {
        PilaEnlazadaSimple pilaInvertida = new PilaEnlazadaSimple();
        NodoPila nodo = Tope;
        while(nodo != null)
        {
            pilaInvertida.Push(Pop());
            nodo = nodo.Back;
        }
        Tope = pilaInvertida.Tope;
        Contador = pilaInvertida.Tamanio();
    }

    public double ObtenerMaximo()
    {
        if (Tope == null) throw new InvalidOperationException("Underflow: la pila está vacía");
        NodoPila nodo = Tope;
        double maximo = nodo.Valor;
        nodo = nodo.Back;
        while(nodo != null)
        {
            if (nodo.Valor > maximo) maximo = nodo.Valor;
            nodo = nodo.Back;
        }
        return maximo;
    }

    public int Tamanio()
    {
        return Contador;
    }

    public string Mostrar()
    {
        NodoPila nodo = Tope;
        string retorno = "";
        while (nodo != null)
        {
            retorno += $"[{nodo.Valor:N2}]\n";
            nodo = nodo.Back;
        }
        return retorno;
    }

}