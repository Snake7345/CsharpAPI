using System.ComponentModel.DataAnnotations;

namespace CsharpAPI.Models
{
    public class Like
    {
        [Required]
        public Guid IdLike { get; set; }
    }
}
