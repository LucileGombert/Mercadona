using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

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
      

        [Required(ErrorMessage = "Prix requis")]
        [Display(Name = "Prix")]
        [Column(TypeName = "decimal(4,2)")]
        [DataType(DataType.Currency)]
        public decimal? Price { get; set; } = decimal.One;

        [Display(Name = "Prix remisé")]
        [Column(TypeName = "decimal(4,2)")]
        [DataType(DataType.Currency)]
        public decimal? DiscountedPrice { get; set; } = 0;


        // Relations
        [ForeignKey("CategoryId")]
        [Required(ErrorMessage = "Veuillez sélectionner une catégorie")]
        [Display(Name = "Catégorie")]
        public int CategoryId { get; set; }

        public Category? Category { get; set; }

        [ForeignKey("OfferId")]
        [Display(Name = "Promotion")]
        public int OfferId { get; set; }

        public Offer? Offer { get; set; }
    }
}