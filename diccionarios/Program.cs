using System.Diagnostics;

namespace hashes;

class Program
{
    static void Main(string[] args)
    {
        // Console.WriteLine("Entendiendo Hashes");

        // string nombre = "Eddy James Anastacio cardozo Villena y Zenteno";
        // Console.WriteLine(nombre.GetHashCode());

        // string otroNombre = "Eduardo Lopez Zuniga";
        // Console.WriteLine(otroNombre.GetHashCode());

        // otroNombre = "eduardo lopez zuniga";
        // Console.WriteLine(otroNombre.GetHashCode());

        // int edad = 40;
        // Console.WriteLine(edad.GetHashCode());

        // DateOnly fecha = new DateOnly(2026,7,23);
        // Console.WriteLine(fecha.GetHashCode());

        // bool resultado =(edad > 50) ? true: false;
        // Console.WriteLine(resultado.GetHashCode());

        // Guid miValor = Guid.NewGuid();
        // Console.WriteLine(miValor.ToString());
        // Console.WriteLine(miValor.GetHashCode());

        // Definamos un diccionario
        // Dictionary<string,int> tienda = new Dictionary<string, int>();
        // tienda.Add("RockStar", 15);
        // tienda.Add("Powerade", 10);
        // tienda.Add("Redd Bull", 12);
        // tienda.Add("Chocolin", 20);
        // tienda.Add("Karpil Naranja", 5);
        // tienda.Add("Karpil Limon", 30);
        // Console.WriteLine($"En mi tienda tengo {tienda.Count} productos");

        // tienda.Add("Karpil Manzana", 5);

        // tienda["Karpil Naranja"] += 10;
        // Console.WriteLine($"Karpil Naranja tengo: {tienda["Karpil Naranja"]}");
        // tienda["Karpil Naranja"] += 10;
        // foreach(KeyValuePair<string, int> item in tienda)
        // {
        //     Console.WriteLine($"Producto {item.Key} - Cantidad {item.Value}");
        // }
        
        // tienda.TryGetValue("Fresquin",out int cantidad);
        // Console.WriteLine($"Fresquin: {cantidad}");

        // int salida = 0;
        // tienda.TryGetValue("Fresquin",out salida);
        //  Console.WriteLine($"Fresquin: {salida}");

        //  tienda.Remove("Chocolin");
        //  foreach(KeyValuePair<string, int> item in tienda)
        // {
        //      Console.WriteLine($"Producto {item.Key} - Cantidad {item.Value}");
        // }

        // Transaccion transaccion = new ()
        // {
        //     Id = Guid.NewGuid(),
        //     Fecha = DateTime.Now,
        //     Monto = 100m,
        //     Nombre = "Juan Perez",
        //     Movimiento = TipoTransaccion.Ingreso
        // };

        // Dictionary<Guid, Transaccion> operaciones = new Dictionary<Guid, Transaccion>();
        // operaciones.Add(transaccion.Id, transaccion);

        // Dictionary<string, List<Transaccion>> misOperaciones  = new Dictionary<string, List<Transaccion>>();

        // Versus (Array, List, Diccionario)
        int itemsACrear = 10_000_000;

        String[] clientes = new string[]
        {
            "Eduardo Lopez Zuniga",
            "Juan Perez",
            "Carlos Carrasco",
            "Adrian Barrientos",
            "Pamela Cavero",
            "Joaquin Soruco",
            "Alex Fabian Ortiz",
            "Marlova Vera",
            "Mayeli Lema",
            "Manuel Mendez"
        };

        Guid[] llaves = new Guid[8];
        llaves[0] = new Guid("11111111-1111-1111-1111-000000000000");
        llaves[1] = new Guid("11111111-1111-1111-1111-111111111111");
        llaves[2] = new Guid("11111111-1111-1111-1111-222222222222");
        llaves[3] = new Guid("11111111-1111-1111-1111-333333333333");
        llaves[4] = new Guid("11111111-1111-1111-1111-444444444444");
        llaves[5] = new Guid("11111111-1111-1111-1111-555555555555");
        llaves[6] = new Guid("11111111-1111-1111-1111-666666666666");
       

        DateTime fechaBase = new DateTime(2026,1,1);

        Transaccion[] arrTransacciones = new Transaccion[itemsACrear];
        List<Transaccion> lstTransacciones = new List<Transaccion>(itemsACrear);
        Dictionary<Guid, Transaccion> dicTransacciones = new Dictionary<Guid, Transaccion>(itemsACrear);

        Random rnd = new Random();

        Transaccion transaccion;

        for (int i = 0; i < itemsACrear; i++)
        {
             transaccion = new Transaccion()
            {
              Id = Guid.NewGuid(),
              Fecha = fechaBase.AddDays(rnd.Next(0,365)),
              Nombre = clientes[rnd.Next(0,10)],
              Monto = rnd.Next(1, 10001),
              Movimiento = (rnd.Next(0, 2) == 0) ? TipoTransaccion.Ingreso : TipoTransaccion.Egreso,
            };

            if (i == 1_000_000) transaccion.Id = llaves[0];
            if (i == 2_000_000) transaccion.Id = llaves[1];
            if (i == 3_000_000) transaccion.Id = llaves[2];
            if (i == 4_000_000) transaccion.Id = llaves[3];
            if (i == 7_000_000) transaccion.Id = llaves[4];
            if (i == 8_000_000) transaccion.Id = llaves[5];
            if (i == 9_500_000) transaccion.Id = llaves[6];

            if (i == itemsACrear -1) llaves[7] = transaccion.Id;

            arrTransacciones[i] = transaccion;
            lstTransacciones.Add(transaccion);
            dicTransacciones.Add(transaccion.Id, transaccion);
        }

        Stopwatch cronometro = new Stopwatch();
        Transaccion resultante;
        cronometro.Start();

        foreach(Guid llave in llaves)
        {
            resultante = dicTransacciones[llave];
            //Console.WriteLine(resultante);
        }

        cronometro.Stop();
        Console.WriteLine($"El tiempo de busqueda con diccionarios es {cronometro.Elapsed.TotalMilliseconds} ms.");

        cronometro.Restart();
        foreach(Guid llave in llaves)
        {
            resultante = lstTransacciones.Find(x => x.Id == llave);
            //Console.WriteLine(resultante);
        }

        cronometro.Stop();
        Console.WriteLine($"El tiempo de busqueda con listas es {cronometro.Elapsed.TotalMilliseconds} ms.");

        cronometro.Restart();
        foreach(Guid llave in llaves)
        {
            resultante = Array.Find<Transaccion>(arrTransacciones, x => x.Id ==llave);
            //Console.WriteLine(resultante.ToString());
        }

        cronometro.Stop();
        Console.WriteLine($"El tiempo de busqueda con arrays es {cronometro.Elapsed.TotalMilliseconds} ms.");






    }
}
