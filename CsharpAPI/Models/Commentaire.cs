using System.ComponentModel.DataAnnotations;

namespace CsharpAPI.Models
{
    public class Commentaire
    {
        [Required]
        public Guid IdCommentaire { get; set; }
        [Required]
        public Guid UtilisateurId { get; set; }
        public virtual Utilisateur Utilisateur { get; set; }
        public Guid LikeId { get; set; }
        public virtual Like Like { get; set; }
        [Required]
        public Guid PublicationId { get; set; }
        public virtual Publication Publication { get; set; }
    }
}
