using System.ComponentModel.DataAnnotations;

namespace CsharpAPI.Class
{
    public class Localites
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public ICollection<Personnes> Personnes { get; set; }
    }
}
