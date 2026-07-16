public class Materia
{
    public required string Nombre { get; set; }
    public string Turno { get; set; }
    public required string Docente { get; set; }

    public Materia()
    {
        estudiantes = new List<Estudiante>();
    }

    private List<Estudiante> estudiantes;

    public List<Estudiante> Estudiantes => estudiantes;

    public void AgregarEstudiante(Estudiante estudiante)
    {
        estudiantes.Add(estudiante);
    }

}