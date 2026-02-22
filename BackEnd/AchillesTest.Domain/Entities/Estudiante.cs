using System.ComponentModel.DataAnnotations;

namespace AchillesTest.Domain.Entities
{
    public class Estudiante
    {
        [Key]
        public int IdEstudiante { get; set; }
        public string? Apel_est { get; set; }
        public string? Nomb_est { get; set; }
        public int IdDistrito { get; set; }
        public virtual Distrito? Distrito { get; set; }
        public virtual ICollection<Matricula> Matriculas { get; set; } = new List<Matricula>();
    }
}
