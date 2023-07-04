using System.ComponentModel.DataAnnotations;

namespace CsharpAPI.Class
{
    public class Localite
    {
        [Key]
        [Required]
        public Guid IdLocalite { get; set; }

        [Required]
        public int CP { get; set; }

        [Required]
        public string Ville { get; set; }

        public double Longitude { get; set; }

        public double Latitude { get; set; }
    }
}
