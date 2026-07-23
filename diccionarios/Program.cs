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
        Dictionary<string,int> tienda = new Dictionary<string, int>();
        tienda.Add("RockStar", 15);
        tienda.Add("Powerade", 10);
        tienda.Add("Redd Bull", 12);
        tienda.Add("Chocolin", 20);
        tienda.Add("Karpil Naranja", 5);
        tienda.Add("Karpil Limon", 30);
        Console.WriteLine($"En mi tienda tengo {tienda.Count} productos");

        tienda.Add("Karpil Manzana", 5);

        tienda["Karpil Naranja"] += 10;
        Console.WriteLine($"Karpil Naranja tengo: {tienda["Karpil Naranja"]}");
        tienda["Karpil Naranja"] += 10;
        foreach(KeyValuePair<string, int> item in tienda)
        {
            Console.WriteLine($"Producto {item.Key} - Cantidad {item.Value}");
        }
        
        tienda.TryGetValue("Fresquin",out int cantidad);
        Console.WriteLine($"Fresquin: {cantidad}");

        int salida = 0;
        tienda.TryGetValue("Fresquin",out salida);
         Console.WriteLine($"Fresquin: {salida}");

         tienda.Remove("Chocolin");
         foreach(KeyValuePair<string, int> item in tienda)
        {
             Console.WriteLine($"Producto {item.Key} - Cantidad {item.Value}");
        }

        Transaccion transaccion = new ()
        {
            Id = Guid.NewGuid(),
            Fecha = DateTime.Now,
            Monto = 100m,
            Nombre = "Juan Perez",
            Movimiento = TipoTransaccion.Ingreso
        };

        Dictionary<Guid, Transaccion> operaciones = new Dictionary<Guid, Transaccion>();
        operaciones.Add(transaccion.Id, transaccion);

        Dictionary<string, List<Transaccion>> misOperaciones  = new Dictionary<string, List<Transaccion>>();
    }
}
