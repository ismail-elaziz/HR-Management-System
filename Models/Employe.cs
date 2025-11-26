using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace Projet_DotNet.Models
{
    [Table("Employes", Schema = "HR")]
    public class Employe
    {
        [Key]
        [Display(Name = "ID Employé")]
        public int EmployeId { get; set; }

        [Display(Name = "Nom Employé")]
        [Column(TypeName = "varchar(200)")]
        public string NomEmploye { get; set; } = string.Empty;

        [Display(Name = "Prénom Employé")]
        [Column(TypeName = "varchar(200)")]
        public string PrenomEmploye { get; set; } = string.Empty;

        [Display(Name = "Image de l'utilisateur")]
        [Column(TypeName = "varchar(206)")]
        public string? UserImage { get; set; }  // Pour stocker le nom de fichier de l'image dans la base de données

        [NotMapped] // Cette propriété ne sera pas mappée à la base de données
        [Display(Name = "Image")]
        public IFormFile? ImageFile { get; set; } // Cette propriété est utilisée pour le téléchargement d'image

        [Display(Name = "Date de Naissance")]
        [DataType(DataType.Date)]
        public DateTime DateNaissance { get; set; }

        [Display(Name = "Salaire")]
        [Column(TypeName = "decimal(12,2)")]
        public decimal Salaire { get; set; }

        [Display(Name = "Date d'Embauche")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime DateEmbauche { get; set; }

        [Required]
        [Display(Name = "ID National")]
        [MaxLength(5)]
        [MinLength(5)]
        [Column(TypeName = "varchar(5)")]
        public string NationalId { get; set; } = string.Empty;  // S'assurer qu'une valeur est toujours assignée

        public int DepartementId { get; set; }
        public Departement? Departement { get; set; }
    }
}
