﻿using CsharpAPI.Class;
using System.ComponentModel.DataAnnotations;

namespace CsharpAPI.Models
{
    public class Utilisateur
    {
        [Key]
        [Required]
        public Guid IdUtilisateur { get; set; }
        [Required]
        public string Nom { get; set; }
        [Required]
        public string Prenom { get; set; }
        [Required]
        public string Mail { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Photo { get; set; }
        [Required]
        public DateTime DateInscription { get; set; }
        [Required]
        public bool Actif { get; set; }
        [Required]
        public Guid TravailId { get; set; }
        public virtual Travail Travail { get; set; }
        [Required]
        public Guid LocaliteId { get; set; }
        public virtual Localite Localite { get; set; }
    }
}
