using System.ComponentModel.DataAnnotations;

namespace CsharpAPI.Models
{
    public class Amitie
    {
        [Key]
        [Required]
        public Guid IdAmitie { get; set; }
        [Required]
        public bool Accepte { get; set; }
        [Required]
        public bool Refuse { get; set; }
        [Required]
        public bool Attente { get; set; }
        [Required]
        public Guid DestinataireUtilisateurId { get; set; }
        public virtual Utilisateur Destinataire { get; set; }
        [Required]
        public Guid DestinateurUtilisateurId { get; set; }
        public virtual Utilisateur Destinateur { get; set; }
    }
}
