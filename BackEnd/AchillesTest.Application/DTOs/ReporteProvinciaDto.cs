namespace AchillesTest.Application.DTOs
{
    public class ReporteProvinciaDto
    {
        public string? Provincia { get; set; }
        public List<string> Alumnos { get; set; }

        public ReporteProvinciaDto(string? provincia, List<string> alumnos)
        {
            Provincia = provincia;
            Alumnos = alumnos;
        }
    }
}
