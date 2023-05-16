using MercadonaStudi.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MercadonaStudi.Context;

namespace MercadonaStudi.ViewModels
{
    public class ProductViewModel
    {
        //public int Id { get; set; }

        //[Required(ErrorMessage = "Titre requis")]
        //[Display(Name = "Titre")]
        //public string? Title { get; set; }

        //[Required(ErrorMessage = "Description requise")]
        //public string? Description { get; set; }

        //[Required(ErrorMessage = "Image requise")]
        //public string? Image { get; set; }

        //[Required(ErrorMessage = "Prix requis")]
        //[Display(Name = "Prix")]
        //public decimal? Price { get; set; } = decimal.One;

        //[Display(Name = "Prix remisé")]
        //public decimal? NewPrice { get; set; }

        //// Relations
        //[Required(ErrorMessage = "Veuillez sélectionner une catégorie")]
        //[Display(Name = "Catégorie")]
        //public int CategoryId { get; set; } = default;
        //public Category? Category { get; set; }

        //[Display(Name = "Promotion")]
        //public int OfferId { get; set; }
        //public Offer? Offer { get; set; }


        //private readonly AppDbContext _context;
        //private readonly int _productId;

        //// Constructeur
        //public ProductViewModel(AppDbContext context)
        //{
        //    _context = context;
        //    _productId = _productId;
        //}

        //public decimal NewPrice()
        //{
        //    var offer = _context.Offers.Find(_productId.OfferId);
        //    //var offerPercentage = offer.Percentage;
        //    decimal discountedPrice = _context.Products.Where(p.ProductId == _productId).Sum(s => s.Price)
        //        return discountedPrice;
        //}
    }
}
