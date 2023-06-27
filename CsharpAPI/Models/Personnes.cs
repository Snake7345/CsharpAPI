using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CsharpAPI.Class
{
    public class Personnes
    {
        [Key]
        public int IdPersonnes { get; set; }
        public string Nom { get; set; }

        [ForeignKey("Localite")]
        public int IdLocalite { get; set; }
        public Localites Localite { get; set; }
    }
}
