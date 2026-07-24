public class Transaccion
{
    public Guid Id { get; set; }
    public DateTime Fecha { get; set; }
    public required string Nombre { get; set; }
    public decimal Monto { get; set; }
    public TipoTransaccion Movimiento { get; init;}

    public override string ToString()
    {
        return $"Id: {Id.ToString()} - Cliente: {Nombre} - Monto: {Monto} - Fecha: {Fecha.ToShortDateString()}";
    }


}

public enum TipoTransaccion
{
    Ingreso,
    Egreso
}