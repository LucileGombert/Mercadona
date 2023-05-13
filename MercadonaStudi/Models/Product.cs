using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MercadonaStudi.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Titre requis")]
        [StringLength(50)]
        [Display(Name = "Titre")]
        public string? Title { get; set; }

        [Required(ErrorMessage = "Description requise")]
        [StringLength(200)]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Image requise")]
        public string? Image { get; set; }

        [NotMapped]
        public IFormFile? ImageFile { get; set; }

        [Required(ErrorMessage = "Prix requis")]
        [Display(Name = "Prix")]
        [Column(TypeName = "decimal(4,2)")]
        [DataType(DataType.Currency)]
        public decimal? Price { get; set; } = decimal.One;

        // Relations
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]

        public Category? Category { get; set; }

        
        public int OfferId { get; set; }
        [ForeignKey("OfferId")]

        public Offer? Offer { get; set; }
    }
}