using System.ComponentModel.DataAnnotations;

namespace CsharpAPI.Models
{
    public class Contenu
    {
        [Required]
        public Guid IdContenu { get; set; }
        [Required]
        public string Texte { get; set; }
        [Required]
        public DateTime DateCreation { get; set; }
        public Guid CommentaireId { get; set; }
        public virtual Commentaire Commentaire { get; set; }
        public Guid PublicationId { get; set; }
        public virtual Publication Publication { get; set; }
        public Guid PVId { get; set; }
        public virtual PV PV { get; set; }
    }
}
