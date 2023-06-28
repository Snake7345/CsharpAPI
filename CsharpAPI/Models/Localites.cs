using System.ComponentModel.DataAnnotations;

namespace CsharpAPI.Class
{
    public class Localites
    {
        [Key]
        public Guid IdLocalite { get; set; }
        public string Nom { get; set; }
    }
}
