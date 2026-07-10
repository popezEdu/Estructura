using System.Runtime.InteropServices;

namespace referencia_valor;


public unsafe class ArrayUnsafeHeap
{
    // -----------
    // Propiedades
    // -----------
    private int _tamaño;
    private const int VACIO = int.MinValue;
    private int _indice;
    private int* _ptrArray;
    IntPtr memoria;


    // -----------
    // Constructor
    // -----------

    public ArrayUnsafeHeap(int tamaño)
    {
        if (tamaño < 1) throw new ArgumentException("El valor del argumento debe ser mayor que 0.");

        _tamaño = tamaño;
        _indice = 0;

        memoria = Marshal.AllocHGlobal(_tamaño * sizeof(int));
        _ptrArray = (int*)memoria.ToPointer();

        for (int i = 0; i < _tamaño; i++)
        {
            _ptrArray[i] = VACIO;
        }
    }

    // Propiedades 
    public int Tamaño => _tamaño;
    public bool SePuedeAgregar => (_indice < _tamaño);

    private string _nombre;
    public string Nombre
    {
        get { return _nombre; }
        set { _nombre = value; }
    }

    // Métodos
    public void Agregar(int valor)
    {
        if (SePuedeAgregar)
        {
            _ptrArray[_indice] = valor;
            _indice++;
        }
    }

    public void Eliminar()
    {
        if (_indice > 0)
        {
            _indice--;
            _ptrArray[_indice] = VACIO;
        }
    }

    public override string ToString()
    {
        string retornar = "[";
        for (int i = 0; i < _tamaño; i++)
        {
            if (_ptrArray[i] == VACIO)
            {
                retornar += "VACIO, ";
            }
            else
            {
                retornar += _ptrArray[i].ToString() + ", ";
            }
        }
        return retornar.Substring(0, retornar.Length - 2) + "]";
    }

    public void Destruir()
    {
        Marshal.FreeHGlobal(memoria);
    }
}