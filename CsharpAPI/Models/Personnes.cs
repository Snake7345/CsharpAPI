using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CsharpAPI.Class
{
    public class Personnes
    {
        [Key]
        public Guid IdPersonne { get; set; }
        public string Nom { get; set; }
        public Guid LocaliteId { get; set; }
        public virtual Localites Localite { get; set; }
    }
}
