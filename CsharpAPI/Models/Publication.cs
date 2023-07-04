using System.ComponentModel.DataAnnotations;

namespace CsharpAPI.Models
{
    public class Publication
    {
        [Required]
        public Guid IdPublication { get; set; }
        public Guid LikeId { get; set; }
        public virtual Like Like { get; set; }

    }
}
