using System.ComponentModel.DataAnnotations;

namespace AchillesTest.Domain.Entities
{
    public class Asignacion
    {
        [Key]
        public int IdAsignacion { get; set; }
        public DateTime Fect_asi { get; set; }
        public int IdDocente { get; set; }
        public int IdCurso { get; set; }
        public virtual Docente? Docente { get; set; }
        public virtual Curso? Curso { get; set; }
    }
}
