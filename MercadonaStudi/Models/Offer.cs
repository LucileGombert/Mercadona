using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MercadonaStudi.Models
{
    public class Offer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Date de début requise")]
        [Display(Name = "Date de début")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Date de fin requise")]
        [Display(Name = "Date de fin")]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "Pourcentage de remise requis")]
        [Display(Name = "Pourcentage de remise")]
        [Range(0, 100)]
        [Column(TypeName = "decimal(3,0)")]
        public decimal? Percentage { get; set; } = 0;

        // Relations
        public List<Product>? Products { get; set; }
    }

    
}
