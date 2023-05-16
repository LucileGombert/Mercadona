using MercadonaStudi.Context;
using MercadonaStudi.Models;
using MercadonaStudi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;

namespace MercadonaStudi.Controllers
{
    public class ProductsController : Controller
    {
        private readonly AppDbContext _context;
        private Product productUpdated;

        // Constructeur
        public ProductsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Products
        public IActionResult Index()
        {
            var data = _context.Products.Include(p => p.Category).Include(p => p.Offer).ToList();

            //foreach(var item in data)
            //{
            //    if(item.OfferId != 1)
            //    {
            //        item.DiscountedPrice = item.Price - (item.Price * (item.Offer.Percentage / 100));
            //    }
            //}

            return View(data);
        }

        //public decimal NewPrice()
        //{
        //    var offer = _context.Offers.Find(_productId.OfferId);
        //    //var offerPercentage = offer.Percentage;
        //    decimal discountedPrice = _context.Products.Where(p.ProductId == _productId).Sum(s => s.Price)
        //        return discountedPrice;
        //}

        //ApplyPromo(price : number, promo:number)
        //{
        //    return price - ((price * promo) / 100);
        //}
        //<span>{{ApplyPromo(p.prix, p.promotion.remise)}} $</ span >




        //// GET: Products/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

//// POST: Products/Create
//[HttpPost]
//public IActionResult Create([Bind("Title, Description, Image, Price")] Product product)
//{
//    if (!ModelState.IsValid)
//    {
//        return View(product);
//    }
//    _context.Products.Add(product);
//    _context.SaveChanges();
//    return RedirectToAction("Index");
//}



// GET: Products/Create
        public IActionResult Create()
        {
            var selectionData = new NewProductSelectionsViewModel()
            {
                Categories = _context.Categories.OrderBy(n => n.Label).ToList(),
                Offers = _context.Offers.OrderBy(n => n.Percentage).ToList()
            };

            ViewBag.Categories = new SelectList(selectionData.Categories, "Id", "Label");
            ViewBag.Offers = new SelectList(selectionData.Offers, "Id", "Percentage");

            return View();
        }

        // POST: Products/Create
        [HttpPost]
        public IActionResult Create([Bind("Title, CategoryId, Description, Image, Price, OfferId")] Product product)
        {
            if (!ModelState.IsValid)
            {
                var selectionData = new NewProductSelectionsViewModel()
                {
                    Categories = _context.Categories.OrderBy(n => n.Label).ToList(),
                    Offers = _context.Offers.OrderBy(n => n.Percentage).ToList()
                };

                ViewBag.Categories = new SelectList(selectionData.Categories, "Id", "Label");
                ViewBag.Offers = new SelectList(selectionData.Offers, "Id", "Percentage");

                return View(product);
            }

            _context.Products.Add(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        // GET: Products/Edit/2
        public IActionResult Edit(int id)
        {
            var data = _context.Products.Find(id);
            //var data = _context.Products.Include(c => c.Category).Include(o => o.Offer).FirstOrDefault(p => p.Id == id);

            if (data == null)
            {
                return View("NotFound");
            }

            //var response = new ProductViewModel()
            //{
            //    Id = data.Id,
            //    Title = data.Title,
            //    CategoryId = data.CategoryId,
            //    Description = data.Description,
            //    Image = data.Image,
            //    Price = data.Price,
            //    NewPrice = data.Price * (data.Offer.Percentage / 100),
            //    OfferId = data.OfferId,
            //};

            var selectionData = new NewProductSelectionsViewModel()
            {
                Categories = _context.Categories.OrderBy(n => n.Label).ToList(),
                Offers = _context.Offers.OrderBy(n => n.Percentage).ToList()
            };

            ViewBag.Categories = new SelectList(selectionData.Categories, "Id", "Label");
            ViewBag.Offers = new SelectList(selectionData.Offers, "Id", "Percentage");

            return View(data);
            //return View(response);
        }

        // POST: Products/Edit/2
        [HttpPost]
        public IActionResult Edit([Bind("Id, Title, CategoryId, Description, Image, Price, DiscountedPrice, OfferId")] Product product)
        //public IActionResult Edit(int id, Product product)
        {
            //if (id != productUpdated.Id) return View("NotFound");
            //var percentage = _context.Offers.FirstOrDefault(p => p.Id == id);
            if (!ModelState.IsValid)
            {
                var selectionData = new NewProductSelectionsViewModel()
                {
                    Categories = _context.Categories.OrderBy(n => n.Label).ToList(),
                    Offers = _context.Offers.OrderBy(n => n.Percentage).ToList()
                };

                ViewBag.Categories = new SelectList(selectionData.Categories, "Id", "Label");
                ViewBag.Offers = new SelectList(selectionData.Offers, "Id", "Percentage");

                return View(product);
            }
            var data = _context.Offers.Find(product.OfferId);

            if (product.OfferId != 1)
            {
                productUpdated = new Product()
                {
                    Id = product.Id,
                    Title = product.Title,
                    CategoryId = product.CategoryId,
                    Description = product.Description,
                    Image = product.Image,
                    Price = product.Price,
                    DiscountedPrice = product.Price - (product.Price * (data.Percentage / 100)),
                    OfferId = product.OfferId,
                };
            }
            else
            {
                productUpdated = new Product()
                {
                    Id = product.Id,
                    Title = product.Title,
                    CategoryId = product.CategoryId,
                    Description = product.Description,
                    Image = product.Image,
                    Price = product.Price,
                    DiscountedPrice = product.Price,
                    OfferId = product.OfferId,
                };
            }

            //product.DiscountedPrice = product.Price - (product.Price * (product.Offer.Percentage / 100));
            _context.Products.Update(productUpdated);
            _context.SaveChanges();
            return RedirectToAction("Index");


            //var dbMovie = _context.Products.FirstOrDefault(n => n.Id == productUpdated.Id);

            //if (dbMovie != null)
            //{
            //    dbMovie.Title = productUpdated.Title;
            //    dbMovie.CategoryId = productUpdated.CategoryId;
            //    dbMovie.Description = productUpdated.Description;
            //    dbMovie.Image = productUpdated.Image;
            //    dbMovie.Price = productUpdated.Price;
            //    //dbMovie.NewPrice = productUpdated.Price * (productUpdated.Offer.Percentage / 100);
            //    dbMovie.OfferId = productUpdated.OfferId;
            //    //_context.Products.Update(dbMovie);
            //    _context.SaveChanges();
            //    return RedirectToAction("Index");
            //}

            //var offer = _context.Offers.Find(product.OfferId);
            //var offerPercentage = offer.Percentage;

            //ProductViewModel productViewModel = new ProductViewModel();
            //productViewModel.NewPrice = product.Price * (product.Offer.Percentage / 100);




        }

        // GET: Products/Delete/2
        public IActionResult Delete(int id)
        {
            var data = _context.Products.Find(id);

            if (data == null)
            {
                return View("NotFound");
            }

            return View(data);
        }

        // POST: Products/Delete/2
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var data = _context.Products.Find(id);

            if (data == null)
            {
                return View("NotFound");
            }

            _context.Products.Remove(data);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
