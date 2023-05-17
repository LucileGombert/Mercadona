using System.ComponentModel.DataAnnotations;

namespace MercadonaStudi.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Libellé requis")]
        [Display(Name = "Catégorie")]
        public string? Label { get; set; }


        // Relations
        public List<Product>? Products { get; set; }
    }
}