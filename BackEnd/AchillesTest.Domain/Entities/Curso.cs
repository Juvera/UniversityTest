using System.ComponentModel.DataAnnotations;

namespace AchillesTest.Domain.Entities
{
    public class Curso
    {
        [Key]
        public int IdCurso { get; set; }
        public string? Nomb_cur { get; set; }
        public string? Dura_cur { get; set; }
        public virtual ICollection<Asignacion> Asignaciones { get; set; } = new List<Asignacion>();
        public virtual ICollection<Matricula> Matriculas { get; set; } = new List<Matricula>();
    }
}
