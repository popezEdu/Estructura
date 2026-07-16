namespace estudiantes;

class Program
{
    static void Main(string[] args)
    {
        Materia calculo = new Materia
        {
            Nombre = "Calculo I",
            Docente = "Ludmila Baliuk"
        };

        Estudiante estudiante01 = new Estudiante();
        estudiante01.Nombre = "Juan Perez";
        estudiante01.Ci = 1010;
        estudiante01.Materia = calculo;

        Estudiante estudiante02 = new Estudiante();
        estudiante01.Nombre = "Monica Fortun";
        estudiante01.Ci = 2020;
        estudiante01.Materia = calculo;

        calculo.AgregarEstudiante(estudiante01);
        calculo.AgregarEstudiante(estudiante02);

        Console.WriteLine(calculo.Estudiantes.Count);

    }
}
