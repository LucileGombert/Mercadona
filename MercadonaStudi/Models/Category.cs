using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MercadonaStudi.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Libellé requis")]
        [Display(Name = "Libellé")]
        public string? Label { get; set; }

        // Relations
        public List<Product>? Products { get; set; }
    }
}