using System.ComponentModel.DataAnnotations;

namespace AchillesTest.Domain.Entities
{
    public class Matricula
    {
        [Key]
        public int IdMatricula { get; set; }
        public DateTime Fech_mat { get; set; }
        public int IdEstudiante { get; set; }
        public int IdCurso { get; set; }
        public virtual Estudiante? Estudiante { get; set; }
        public virtual Curso? Curso { get; set; }
    }
}
