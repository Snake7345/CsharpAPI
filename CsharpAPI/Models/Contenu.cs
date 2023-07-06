using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CsharpAPI.Models
{
#nullable disable
    public class Contenu
    {
        [Required]
        public Guid IdContenu { get; set; }
        [Required]
        [Column(TypeName = "text")]
        [MaxLength(2000)]
        public string Texte { get; set; }
        [Required]
        public DateTime DateCreation { get; set; }
        public Guid? CommentaireId { get; set; }
        public virtual Commentaire Commentaire { get; set; }
        public Guid? PublicationId { get; set; }
        public virtual Publication Publication { get; set; }
        public Guid? PVId { get; set; }
        public virtual PV PV { get; set; }

        public Contenu()
        {
            CommentaireId = null;
            PublicationId = null;
            PVId = null;
        }
    }
}
