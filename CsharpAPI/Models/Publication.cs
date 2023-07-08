using System.ComponentModel.DataAnnotations;

namespace CsharpAPI.Models
{
#nullable disable
    public class Publication
    {
        [Key]
        [Required]
        public Guid IdPublication { get; set; }
        public Guid? LikeId { get; set; }
        public virtual Like Like { get; set; }
        public Publication()
        {
            LikeId = null;
        }
    }
}
