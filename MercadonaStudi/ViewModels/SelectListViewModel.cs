using MercadonaStudi.Models;

namespace MercadonaStudi.ViewModels
{
    public class SelectListViewModel
    {
        public SelectListViewModel()
        {
            Product = new Product();
            Category = new Category();
            Products = new List<Product>();
            Categories = new List<Category>();
            Offers = new List<Offer>();
        }
        public Product Product { get; set; }
        public Category Category { get; set; }
        public List<Product> Products { get; set; }
        public List<Category> Categories { get; set; }
        public List<Offer> Offers { get; set; }
    }
}
