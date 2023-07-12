using System.ComponentModel.DataAnnotations;

namespace CsharpAPI.Models
{
    public class Permission
    {
        [Key]
        [Required]
        public int IdPermission { get; set; }
        [Required]
        public string Action { get; set; }
        [Required]
        public string Type { get; set; }
    }
}
