using System.ComponentModel.DataAnnotations;

namespace BoutiqueFleurs.Models
{
   public class Fleur
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Le nom est requis")]
        [StringLength(50)]
        public string NomF { get; set; } = string.Empty;

        [Required(ErrorMessage = "Les couleurs sont requises")]
        [StringLength(100)]
        public string Couleurs { get; set; } = string.Empty;

        [Required(ErrorMessage = "Le prix est requis")]
        [Range(0.01, 999.99, ErrorMessage = "Le prix doit être entre 0.01 et 999.99")]
        public decimal PrixF { get; set; }
    }
}