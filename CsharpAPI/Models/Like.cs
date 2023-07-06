using System.ComponentModel.DataAnnotations;

namespace CsharpAPI.Models
{
#nullable disable
    public class Like
    {
        [Required]
        public Guid IdLike { get; set; }
    }
}
