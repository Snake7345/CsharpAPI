using System.ComponentModel.DataAnnotations;

namespace CsharpAPI.Models
{
#nullable disable
    public class Like
    {
        [Key]
        [Required]
        public Guid IdLike { get; set; }
    }
}
