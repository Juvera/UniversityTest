namespace AchillesTest.Application.DTOs
{
    public class ReporteDocenteDto
    {
        public string? Docente { get; set; }
        public List<ReporteCursoDto> Cursos { get; set; }

        public ReporteDocenteDto(string? docente, List<ReporteCursoDto> cursos)
        {
            Docente = docente;
            Cursos = cursos;
        }
    }
}
