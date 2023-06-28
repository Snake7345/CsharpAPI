using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CsharpAPI.Class
{
    public class Personnes
    {
        [Key]
        public int IdPersonne { get; set; }
        public string Nom { get; set; }
        public int LocaliteId { get; set; }
        public virtual Localites Localite { get; set; }
    }
}
