using System;
class ListaEnteros
{

    private List<int> lista;

    public List<int> Lista => lista;

    public ListaEnteros()
    {
        lista = null;
    }
    public ListaEnteros(int cantidadDatosIniciales)
    {
        if (cantidadDatosIniciales < 1) throw new ArgumentOutOfRangeException("El valor no se encuentra dentro del rango");

        lista = new List<int>();

        Random random = new Random();
        for (int i = 0; i < cantidadDatosIniciales; i++)
        {
            lista.Add(random.Next(1, 100));
        }
    }

    public void Agregar(int valor)
    {
        lista.Add(valor);
    }

    public int ExisteValor(int valor)
    {
        // Si un valor no existe retornar -1;
        int retorno = -1;
        for (int i = 0; i < lista.Count; i++)
        {
            if (lista[i] == valor)
            {
                retorno = i;
                break;
            }
        }

        return retorno;
    }

    public override string ToString()
    {
        if (lista == null) return "";

        string resultado = "| ";
        for (int i = 0; i < lista.Count; i++)
        {
            resultado += lista[i] + " | ";
        }
        return resultado;
    }

}