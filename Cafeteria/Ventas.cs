using System.ComponentModel;

public class Ventas
{

    public required Cafe[] Cafes { get; set; }
    public required Fecha Fecha { get; set; }

    private Nodo? cabeza;
    public int GenerarVenta(string cafe)
    {
        // Determinamos si el café existe dado el nombre

        int posicion = -1;
        for (int i = 0; i < Cafes.Length; i++)
        {
            if (Cafes[i].Nombre == cafe)
            {
                posicion = i;
                break;
            }
        }

        if (posicion == -1) throw new Exception($"No existe el café indicado: {cafe}.");

        Venta venta = new Venta
        {
            Numero = Fecha.ObtenerContador(),
            Cafe = Cafes[posicion],
            Fecha = Fecha.FechaActual,
            Estado = Estados.Aceptada,
            Costo = Cafes[posicion].Precio
        };

        // Verificamos que la cabeza Exista
        if (cabeza == null)
        {
            cabeza = new Nodo
            {
                Venta = venta,
                Next = null
            };
        }
        else
        {
            // Existe por lo menos un elemento, procedemos a agregar la venta en la última posición.
            Nodo actual = cabeza;
            while (actual.Next != null)
            {
                actual = actual.Next;
            }
            actual.Next = new Nodo
            {
                Venta = venta,
                Next = null
            };
        }

        // Retornamos el número de venta.
        return venta.Numero;
    }

    public void Devolver(int numero)
    {
        if (cabeza == null) return;

        // Si la cabeza no es null, se procede a buscar la venta

        Nodo? actual = cabeza;
        while (actual != null)
        {
            if (actual.Venta.Numero == numero)
            {
                actual.Venta.Estado = Estados.Devuelta;
                actual = null;
            }
            else
            {
                actual = actual.Next;
            }
        }
    }

    public string GenerarRendimiento(DateOnly fecha)
    {
        if (cabeza == null) return "[]";

        Nodo? actual = cabeza;
        string reporte = string.Empty;

        while (actual != null)
        {
            if (actual.Venta.Estado == Estados.Aceptada && actual.Venta.Fecha == fecha)
            {
                reporte += $"[{actual.Venta.Numero.ToString("D3")} - Bs.{actual.Venta.Costo.ToString("F2")}]";
            }
            actual = actual.Next;
        }

        return !string.IsNullOrEmpty(reporte) ? reporte.Trim() : "[]";
    }

    public string GenerarDevoluciones(DateOnly fecha)
    {
        if (cabeza == null) return "[]";

        Nodo? actual = cabeza;
        string reporte = string.Empty;

        while (actual != null)
        {
            if (actual.Venta.Estado == Estados.Devuelta && actual.Venta.Fecha == fecha)
            {
                reporte += $"[{actual.Venta.Numero.ToString("D3")} - Bs.{actual.Venta.Costo.ToString("F2")}]";
            }
            actual = actual.Next;
        }

        return !string.IsNullOrEmpty(reporte) ? reporte.Trim() : "[]";
    }
}