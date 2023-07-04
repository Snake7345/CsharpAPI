using System.ComponentModel.DataAnnotations;

namespace CsharpAPI.Models
{
    public class PV
    {
        [Required]
        public Guid IdPV { get; set; }
        [Required]
        public Guid DestinataireUtilisateurId { get; set; }
        public virtual Utilisateur Destinataire { get; set; }
        [Required]
        public Guid DestinateurUtilisateurId { get; set; }
        public virtual Utilisateur Destinateur { get; set; }
    }
}
