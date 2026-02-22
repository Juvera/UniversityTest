using System.ComponentModel.DataAnnotations;

namespace AchillesTest.Domain.Entities
{
    public class Profesion
    {
        [Key]
        public int IdProfesion { get; set; }
        public string? Nomb_pro { get; set; }
        public virtual ICollection<Docente> Docentes { get; set; } = new List<Docente>();
    }
}
