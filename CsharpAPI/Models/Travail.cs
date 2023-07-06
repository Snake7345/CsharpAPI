using System.ComponentModel.DataAnnotations;

namespace CsharpAPI.Models
{
#nullable disable
    public class Travail
    {
        [Key]
        [Required]
        public Guid IdTravail { get; set; }
        [Required]
        [MaxLength(100)]
        public string Denomination { get; set; }
    }
}
