using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MercadonaStudi.Models
{
    public class Offer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Date de début requise")]
        [Display(Name = "Date de début")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date, ErrorMessage = "Date de début requise au formaat JJ/MM/AAAA")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Date de fin requise")]
        [Display(Name = "Date de fin")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date, ErrorMessage = "Date de fin requise au formaat JJ/MM/AAAA")]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "Pourcentage de remise requis")]
        [Display(Name = "Promotion")]
        [Range(0, 100)]
        [Column(TypeName = "decimal(3,0)")]
        public decimal? Percentage { get; set; } = 0;


        // Relations
        public List<Product>? Products { get; set; }
    }
}
