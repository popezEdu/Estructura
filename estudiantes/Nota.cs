public class Nota
{
    public decimal Valor { get; set; }
    public DateTime Fecha { get; set; }
    public TiposDeNota TipoNota {get; set;}
    

}

public enum TiposDeNota
{
    Tareas,
    Examenes
}