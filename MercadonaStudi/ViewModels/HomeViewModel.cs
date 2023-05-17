using MercadonaStudi.Controllers;
using MercadonaStudi.Models;

namespace MercadonaStudi.ViewModels
{
    public class HomeViewModel
    {
        //public IEnumerable<Product> Products { get; set; }

        //public IEnumerable<Category> Categories { get; set; }
        //public Product Product { get; set; }

        public HomeViewModel()
        {
            Categories = new List<Category>();
            Offers = new List<Offer>();
            Products = new List<Product>();
            Product = new Product();
            Category = new Category();
        }

        public List<Category> Categories { get; set; }
        public List<Offer> Offers { get; set; }
        public List<Product> Products { get; set; }
        public Product Product { get; set; }
        public Category Category { get; set; }
    }
}
