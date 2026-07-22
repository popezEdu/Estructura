using System;
using System.Text;

public class Pila
{
    private NodoPila tope;
    private int cantidad;
    private static readonly Random random = new Random();

    public Pila(int n)
    {
        tope = null;
        cantidad = 0;
        for(int i = 0; i < n; i++)
        {
            Push(random.Next(1, 51));
        }
    }

    public void Push(int valor)
    {
        if (valor < 1 || valor > 50)
        {
            throw new ArgumentOutOfRangeException("El valor debe estar en el dominio [1, 50].");
        }
        
        NodoPila nuevo = new NodoPila(valor);
        nuevo.Next = tope;
        tope = nuevo;
        cantidad++;
    }

    public int Pop()
    {
        if (EstaVacia()) throw new InvalidOperationException("La pila esta vacia");
        
        int valor = tope.Valor;
        tope = tope.Next;
        cantidad--;
        return valor;
    }

    public bool EstaVacia()
    {
        return tope == null;
    }

    public int Peek()
    {
        if (EstaVacia()) throw new InvalidOperationException("La pila esta vacia");
        return tope.Valor;
    }

    public int Tamano()
    {
        return cantidad;
    }

    public override string ToString()
    {
        if (EstaVacia()) return "[PILA VACIA]";
        
        var sb = new StringBuilder();
        NodoPila actual = tope;
        
        while (actual != null)
        {
            if (actual == tope && actual.Next == null)
            {
                sb.Append($"[TOPE: {actual.Valor}: BASE]");
            }
            else if (actual == tope)
            {
                sb.Append($"[TOPE: {actual.Valor}]");
            }
            else if (actual.Next == null)
            {
                sb.Append($"[{actual.Valor}: BASE]");
            }
            else
            {
                sb.Append($"[{actual.Valor}]");
            }
            actual = actual.Next;
        }
        return sb.ToString();
    }
}

public class Cola
{
    private NodoCola frente;
    private NodoCola final;
    private int Cantidad;

    public Cola()
    {
        Cantidad = 0;
        frente = null;
        final = null;
    }

    public Cola(string[] elementos) : this()
    {
        if (elementos != null)
        {
            foreach(string elemento in elementos)
            {
                Encolar(elemento);
            }
        }
    }

    public void Encolar(string valor)
    {
        NodoCola nuevo = new NodoCola(valor);
        if (frente == null)
        {
            frente = nuevo;
            final = nuevo;
        }
        else
        {
            final.Next = nuevo;
            final = nuevo;
        }
        Cantidad++;
    }

    public string DesenColar()
    {
        if (EstaVacia()) throw new InvalidOperationException("La Cola esta vacia");

        string valor = frente.Valor;
        frente = frente.Next;

        if (frente == null) final = null;
        
        Cantidad--;
        return valor;
    }

    public string Peek()
    {
        if (EstaVacia()) throw new InvalidOperationException("La Cola esta vacia");
        return frente.Valor;
    }

    public void VaciarCola()
    {
        frente = null;
        final = null;
        Cantidad = 0;
    }

    public Cola Clonar()
    {
        Cola copia = new Cola();
        NodoCola actual = frente;
        
        while(actual != null)
        {
            copia.Encolar(actual.Valor);
            actual = actual.Next;
        }
        return copia;
    }

    public bool ContenieneElemento(string valor)
    {
        NodoCola actual = frente;
        
        while (actual != null)
        {
            if (actual.Valor == valor) return true;
            actual = actual.Next;
        }
        return false;
    }

    public bool EstaVacia() => frente == null;

    public override string ToString()
    {
        if (EstaVacia()) return "[COLA VACIA]";
        
        var sb = new StringBuilder();
        NodoCola actual = frente;
        
        while (actual != null)
        {
            sb.Append($"[{actual.Valor}] ");
            actual = actual.Next;
        }
        return sb.ToString().TrimEnd();
    }
}