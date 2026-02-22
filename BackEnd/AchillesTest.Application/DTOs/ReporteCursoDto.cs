namespace AchillesTest.Application.DTOs
{
    public class ReporteCursoDto
    {
        public string? Curso { get; set; }
        public List<ReporteProvinciaDto> Provincias { get; set; }

        public ReporteCursoDto(string? curso, List<ReporteProvinciaDto> provincias)
        {
            Curso = curso;
            Provincias = provincias;
        }
    }
}
