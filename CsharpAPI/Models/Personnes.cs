using System.ComponentModel.DataAnnotations;

namespace CsharpAPI.Class
{
    public class Personnes
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public int LocaliteId { get; set; }
        public Localites Localite { get; set; }
    }
}
