public class Venta
{
    public int Numero { get; set; }
    public required Cafe Cafe { get; set; }
    public DateOnly Fecha { get; set; }
    public Estados Estado { get; set; }
    public decimal Costo { get; set; }
}

public enum Estados
{
    Aceptada,
    Devuelta
}