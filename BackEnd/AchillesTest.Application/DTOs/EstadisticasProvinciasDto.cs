namespace AchillesTest.Application.DTOs
{
    public class EstadisticasProvinciasDto
    {
        public string? Provincia { get; set; }
        public int Cantidad { get; set; }

        public EstadisticasProvinciasDto(string? provincia, int cantidad)
        {
            Provincia = provincia;
            Cantidad = cantidad;
        }
    }
}
