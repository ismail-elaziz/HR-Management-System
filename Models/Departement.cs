using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projet_DotNet.Models
{
    [Table("Departements", Schema = "HR")]
    public class Departement
    {
        [Key]
        [Display(Name = "ID Département")]
        public int DepartementId { get; set; }

        [Display(Name = "Nom du Département")]
        [Column(TypeName = "varchar(200)")]
        public string NomDepartement { get; set; } = string.Empty;
    }
}
