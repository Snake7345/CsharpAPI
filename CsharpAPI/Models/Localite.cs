using System.ComponentModel.DataAnnotations;

namespace CsharpAPI.Class
{
#nullable disable
    public class Localite
    {
        [Key]
        [Required]
        public Guid IdLocalite { get; set; }

        [Required]
        [StringLength(4)]
        public int CP { get; set; }

        [Required]
        [MaxLength(125)]
        public string Ville { get; set; }
        [Required]
        public double Longitude { get; set; }
        [Required]
        public double Latitude { get; set; }
    }
}
