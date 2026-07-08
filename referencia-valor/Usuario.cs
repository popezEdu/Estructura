public class Usuario()
{
    public int Id { get; set; }
    public required string Nombre { get; set; }
    public required string Direccion { get; set; }
    public int Nota { get; set; }

    public override string ToString()
    {
        return $"Mi nombre es {Nombre} y mi nota es {Nota}.";
    }
}