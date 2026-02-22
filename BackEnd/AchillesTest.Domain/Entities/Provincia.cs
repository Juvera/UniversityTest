using System.ComponentModel.DataAnnotations;

namespace AchillesTest.Domain.Entities
{
    public class Provincia
    {
        [Key]
        public int IdProvincia { get; set; }
        public string? Nomb_pro { get; set; }
        public virtual ICollection<Distrito> Distritos { get; set; } = new List<Distrito>();
    }
}
