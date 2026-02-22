using System.ComponentModel.DataAnnotations;

namespace AchillesTest.Domain.Entities
{
    public class Docente
    {
        [Key]
        public int IdDocente { get; set; }
        public string? Apel_doc { get; set; }
        public string? Nomb_doc { get; set; }
        public int IdProfesion { get; set; }
        public virtual Profesion? Profesion { get; set; }
        public virtual ICollection<Asignacion> Asignaciones { get; set; } = new List<Asignacion>();
    }
}
