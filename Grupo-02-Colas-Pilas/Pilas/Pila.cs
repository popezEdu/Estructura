using System;

public class Pila
{
    private Nodo cima;
    public Pila()
    {
        cima = null;
    }

    public Pila(string cadena)
    {
        cima = null;
        foreach (char c in cadena)
        {
            Push(c);
        }
    }

    public void Push(char x)
    {
        Nodo nuevo = new Nodo(x);
        nuevo.Siguiente = cima;
        cima = nuevo;
    }

    public char Pop()
    {
        if (cima == null)
            throw new InvalidOperationException("La pila está vacía.");
        char dato = cima.Dato;
        cima = cima.Siguiente;
        return dato;
    }

    public char Peek()
    {
        if (cima == null)
            throw new InvalidOperationException("La pila está vacía.");
        return cima.Dato;
    }

    public void VaciarPila()
    {
        cima = null;
    }
    public bool ContieneElemento(char x)
    {
        Nodo actual = cima;
        while (actual != null)
        {
            if (actual.Dato == x)
                return true;
            actual = actual.Siguiente;
        }
        return false;
    }
    public Pila Clonar()
    {
        Pila copia = new Pila();
        if (cima == null)
            return copia;
        int cantidad = Contar();
        char[] elementos = new char[cantidad];

        Nodo actual = cima;

        int i = 0;
        while (actual != null)
        {
            elementos[i] = actual.Dato;

            i++;

            actual = actual.Siguiente;
        }
        for (int j = cantidad - 1; j >= 0; j--)
        {
            copia.Push(elementos[j]);
        }
        return copia;
    }
    private int Contar()
    {
        int contador = 0;
        Nodo actual = cima;
        while (actual != null)
        {
            contador++;
            actual = actual.Siguiente;
        }
        return contador;
    }
}