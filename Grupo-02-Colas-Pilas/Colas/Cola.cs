using System;
using System.Text;

public class Cola
{
    private Nodo frente;
    private Nodo fin;
    private int cantidad;

    public Cola(int n, int minimo, int maximo)
    {
        frente = null;
        fin = null;
        cantidad = 0;

        Random random = new Random();

        for (int i = 0; i < n; i++)
        {
            int numero = random.Next(minimo, maximo + 1);
            Encolar(numero);
        }
    }

    public void Encolar(int valor)
    {
        Nodo nuevo = new Nodo(valor);

        if (frente == null)
        {
            frente = nuevo;
            fin = nuevo;
        }
        else
        {
            fin.Siguiente = nuevo;

            fin = nuevo;
        }

        cantidad++;
    }

    public int Desencolar()
    {
        if (frente == null)
        {
            throw new Exception("La cola está vacía.");
        }

        int dato = frente.Dato;

        frente = frente.Siguiente;

        if (frente == null)
        {
            fin = null;
        }

        cantidad--;

        return dato;
    }

    public int Peek()
    {
        if (frente == null)
        {
            throw new Exception("La cola está vacía.");
        }

        return frente.Dato;
    }

    public void Rotar()
    {
        if (cantidad <= 1)
        {
            return;
        }

        int primero = Desencolar();

        Encolar(primero);
    }

    public int ObtenerPosicion(int valor)
    {
        Nodo auxiliar = frente;

        int posicion = 0;

        while (auxiliar != null)
        {
            if (auxiliar.Dato == valor)
            {
                return posicion;
            }

            auxiliar = auxiliar.Siguiente;
            posicion++;
        }

        return -1;
    }

    public int Tamaño()
    {
        return cantidad;
    }

    public bool EstaVacia()
    {
        return frente == null;
    }

    public override string ToString()
    {
        if (frente == null)
        {
            return "La cola está vacía.";
        }

        StringBuilder sb = new StringBuilder();

        Nodo auxiliar = frente;

        while (auxiliar != null)
        {
            sb.Append("[" + auxiliar.Dato + "] ");

            auxiliar = auxiliar.Siguiente;
        }

        return sb.ToString();
    }
}