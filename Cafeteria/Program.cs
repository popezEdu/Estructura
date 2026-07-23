namespace Cafeteria;

class Program
{
    static void Main(string[] args)
    {
        // Definimos la lista de cafés que venderemos.
        Cafe[] cafes =
        [
            new Cafe { Nombre = "Café Tinto", Precio = 10m },
            new Cafe { Nombre = "Café con Leche", Precio = 10.5m },
            new Cafe { Nombre = "Expreso", Precio = 11.5m },
            new Cafe { Nombre = "Doble", Precio = 13m },
            new Cafe { Nombre = "Café con Chocolate", Precio = 15.5m },
            new Cafe { Nombre = "Café con Vainilla", Precio = 16m },
            new Cafe { Nombre = "Café Oreo", Precio = 18m },
            new Cafe { Nombre = "Café Irlandes", Precio = 20m },
        ];

        // La clase Fecha encapsula lo que es la Fecha del día que trabajaremos, y también ahi se define el contador inicial del día. Iniciamos una fecha
        Fecha fecha = new Fecha(new DateOnly(2026, 7, 17));

        // Procedemos a realizar las ventas del día. Para tal fin la clase Ventas representa la lista personalizada.
        Ventas ventas = new Ventas
        {
            Cafes = cafes,
            Fecha = fecha
        };

        try
        {
            Console.WriteLine(ventas.GenerarVenta("Expreso").ToString());
            Console.WriteLine(ventas.GenerarVenta("Café Oreo").ToString());
            Console.WriteLine(ventas.GenerarVenta("Descafeinado").ToString());
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        Console.WriteLine(ventas.GenerarVenta("Café Irlandes").ToString());
        ventas.Devolver(2);
        ventas.Devolver(3);
        Console.WriteLine(ventas.GenerarVenta("Café Tinto").ToString());
        Console.WriteLine($"Devoluciones {ventas.Fecha.FechaActual.ToString("dd/MM/yyyy")}:\n" + ventas.GenerarDevoluciones(fecha.FechaActual));
        Console.WriteLine($"Rendimientos {ventas.Fecha.FechaActual.ToString("dd/MM/yyyy")}:\n" + ventas.GenerarRendimiento(fecha.FechaActual));
        ventas.GenerarVenta("Doble");
        Console.WriteLine($"Rendimientos {ventas.Fecha.FechaActual.ToString("dd/MM/yyyy")}:\n" + ventas.GenerarRendimiento(fecha.FechaActual));

        DateOnly fechaSinVentas = new DateOnly(2026, 7, 21);
        Console.WriteLine($"Rendimientos {fechaSinVentas.ToString("dd/MM/yyyy")}:\n" + ventas.GenerarRendimiento(fechaSinVentas));
        Console.WriteLine($"Devoluciones {fechaSinVentas.ToString("dd/MM/yyyy")}:\n" + ventas.GenerarDevoluciones(fechaSinVentas));
    }
}
