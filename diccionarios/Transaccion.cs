public class Transaccion
{
    public Guid Id { get; set; }
    public DateTime Fecha { get; set; }
    public required string Nombre { get; set; }
    public decimal Monto { get; set; }
    public TipoTransaccion Movimiento { get; init;}

}

public enum TipoTransaccion
{
    Ingreso,
    Egreso
}