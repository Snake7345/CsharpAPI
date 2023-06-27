using System.ComponentModel.DataAnnotations;

namespace CsharpAPI.Class
{
    public class Localites
    {
        [Key]
        public int IdLocalite { get; set; }
        public string Nom { get; set; }
        public ICollection<Personnes> Personnes { get; set; }
    }
}
