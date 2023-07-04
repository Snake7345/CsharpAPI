using System.ComponentModel.DataAnnotations;

namespace CsharpAPI.Models
{
    public class Travail
    {
        [Key]
        [Required]
        public Guid IdTravail { get; set; }
        [Required]
        public string Denomination { get; set; }
    }
}
