using MercadonaStudi.Models;

namespace MercadonaStudi.ViewModels
{
    public class NewProductSelectionsViewModel
    {
        public NewProductSelectionsViewModel()
        {
            Categories = new List<Category>();
            Offers = new List<Offer>();
        }

        public List<Category> Categories { get; set; }
        public List<Offer> Offers { get; set; }
    }
}
