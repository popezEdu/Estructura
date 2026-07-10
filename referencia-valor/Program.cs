using System.Runtime.InteropServices;

namespace referencia_valor;

class Program
{
    static void Main(string[] args)
    {
        // Parte 1 =  Por Valor    

        // Console.WriteLine("Entendamos lo que espor valor.");

        // int notaLuis = 80;
        // Console.WriteLine($"La nota de Luis es {notaLuis}");

        // int notaJose = 85;
        // Console.WriteLine($"La nota de José es {notaJose}");

        // notaLuis = 43;
        // Console.WriteLine($"La nueva nota de Luis es {notaLuis}");
        // Console.WriteLine($"La nota de José es {notaJose}");

        // Parte 2 = Referencia
        // Usuario Luis = new Usuario
        // {
        //     Id = 1,
        //     Nombre = "Luis",
        //     Direccion = "Luis de Fuentes",
        //     Nota = 80
        // };

        // Console.WriteLine(Luis.ToString());

        // Usuario Camilo = Luis;
        // Camilo.Nombre = "Camilo";
        // Camilo.Nota = 90;
        // Camilo.Direccion = "Villa Fátima";
        // Console.WriteLine(Camilo.ToString());

        // Console.WriteLine(Luis.Nota);
        // Console.WriteLine(Luis.Direccion);

        // Luis.Nota = 80;
        // Console.WriteLine(Camilo.ToString());

        // Parte 3 = Punteros

        // stack
        // unsafe
        // {
        //     int tamaño = 6;
        //     // Reservo el espacio de memoria
        //     int* ptrArray = stackalloc int[tamaño];
        //     int* referencia = null;
        //     referencia = ptrArray;

        //     // Asigno valores
        //     for (int i = 0; i < tamaño; i++)
        //     {
        //         *(ptrArray + i) = (i + 1) * 10;
        //     }

        //     // Mostrar Valores
        //     for (int i = 0; i < tamaño; i++)
        //     {
        //         Console.WriteLine($"Elemento {i} tiene el valor {*(referencia + i)}");
        //     }
        // }

        // // Heap
        // unsafe
        // {
        //     int tamaño = 6;
        //     IntPtr memoria = Marshal.AllocHGlobal(tamaño * sizeof(int));

        //     int* ptrArray = (int*)memoria.ToPointer();
        //     for (int i = 0; i < tamaño; i++)
        //     {
        //         ptrArray[i] = (i + 1) * 3;
        //     }

        //     // Mostramos los valores
        //     for (int i = 0; i < tamaño; i++)
        //     {
        //         Console.WriteLine($"Elemento {i} tiene el valor {ptrArray[i]}");

        //         int* ubicacion = ptrArray + i;
        //         Console.WriteLine($"Ubicación de Memoria: 0x{(long)ubicacion:X}");
        //     }

        //     Marshal.FreeHGlobal(memoria);
        // }

        // Examen

        try
        {
            ArrayUnsafeHeap arryconError = new ArrayUnsafeHeap(-7);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);

        }

        ArrayUnsafeHeap array = new ArrayUnsafeHeap(8);
        array.Agregar(32);
        array.Agregar(-92);
        array.Agregar(213);
        Console.WriteLine(array.SePuedeAgregar);
        Console.WriteLine(array.ToString());
        array.Agregar(782);
        array.Agregar(-892);
        Console.WriteLine(array.SePuedeAgregar);
        Console.WriteLine(array.ToString());
        array.Agregar(23);
        array.Agregar(9892);
        array.Agregar(-312);
        Console.WriteLine(array.SePuedeAgregar);
        Console.WriteLine(array.ToString());
        array.Eliminar();
        array.Eliminar();
        array.Eliminar();
        array.Eliminar();
        array.Eliminar();
        Console.WriteLine(array.ToString());
        Console.WriteLine(array.SePuedeAgregar);
        array.Eliminar();
        array.Eliminar();
        Console.WriteLine(array.ToString());
        array.Agregar(1414);
        Console.WriteLine(array.ToString());
        array.Destruir();
    }
}
