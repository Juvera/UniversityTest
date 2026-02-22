namespace AchillesTest.Application.DTOs
{
    public class EstudianteDto
    {
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Provincia { get; set; }

        public EstudianteDto(string? nombre, string? apellido, string? provincia)
        {
            Nombre = nombre;
            Apellido = apellido;
            Provincia = provincia;
        }
    }
}
