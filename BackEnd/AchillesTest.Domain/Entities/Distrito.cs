using System.ComponentModel.DataAnnotations;

namespace AchillesTest.Domain.Entities
{
    public class Distrito
    {
        [Key]
        public int IdDistrito { get; set; }
        public string? Nomb_dis { get; set; }
        public int Idprovincia { get; set; }
        public virtual Provincia? Provincia { get; set; }
        public virtual ICollection<Estudiante> Estudiantes { get; set; } = new List<Estudiante>();
    }
}
