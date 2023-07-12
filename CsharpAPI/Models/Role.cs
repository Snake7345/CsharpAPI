using System.ComponentModel.DataAnnotations;

namespace CsharpAPI.Models
{
    public class Role
    {
        [Key]
        [Required]
        public int IdRole { get; set; }
        [Required]
        public string Denomination { get; set; }

    }
}
