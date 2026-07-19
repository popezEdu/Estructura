public class Fecha
{
    private DateOnly _fechaActual;
    private int _contador;

    public Fecha(DateOnly fecha)
    {
        _fechaActual = fecha;
        _contador = 0;
    }

    public DateOnly FechaActual => _fechaActual;
    public int ObtenerContador() => ++_contador;

}