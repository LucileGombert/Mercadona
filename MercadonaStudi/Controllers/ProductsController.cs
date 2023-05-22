using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MercadonaStudi.Context;
using MercadonaStudi.Models;
using MercadonaStudi.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace MercadonaStudi.Controllers
{
    [Authorize]
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
            var productList = _context.Products.Include(p => p.Category).Include(p => p.Offer).ToList();

            return View(productList);
        }



        // GET: Products/Create
        public IActionResult Create()
        {
            var selectList = new SelectListViewModel()
            {
                Categories = _context.Categories.OrderBy(n => n.Label).ToList(),
                Offers = _context.Offers.OrderBy(n => n.Percentage).ToList()
            };

            ViewBag.Categories = new SelectList(selectList.Categories, "Id", "Label");
            ViewBag.Offers = new SelectList(selectList.Offers, "Id", "Percentage");

            return View();
        }

        // POST: Products/Create
        [HttpPost]
        public IActionResult Create([Bind("Title, CategoryId, Description, Image, Price, OfferId")] Product productToCreate)
        {
            if (!ModelState.IsValid)
            {
                var selectList = new SelectListViewModel()
                {
                    Categories = _context.Categories.OrderBy(n => n.Label).ToList(),
                    Offers = _context.Offers.OrderBy(n => n.Percentage).ToList()
                };

                ViewBag.Categories = new SelectList(selectList.Categories, "Id", "Label");
                ViewBag.Offers = new SelectList(selectList.Offers, "Id", "Percentage");

                return View(productToCreate);
            }

            _context.Products.Add(productToCreate);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }



        // GET: Products/Edit/2
        public IActionResult Edit(int id)
        {
            var productToUpdate = _context.Products.Find(id);

            if (productToUpdate == null)
            {
                return View("NotFound");
            }

            var selectList = new SelectListViewModel()
            {
                Categories = _context.Categories.OrderBy(n => n.Label).ToList(),
                Offers = _context.Offers.OrderBy(n => n.Percentage).ToList()
            };

            ViewBag.Categories = new SelectList(selectList.Categories, "Id", "Label");
            ViewBag.Offers = new SelectList(selectList.Offers, "Id", "Percentage");

            return View(productToUpdate);
        }

        // POST: Products/Edit/2
        [HttpPost]
        public IActionResult Edit([Bind("Id, Title, CategoryId, Description, Image, Price, DiscountedPrice, OfferId")] Product productToUpdate)
        {
            if (!ModelState.IsValid)
            {
                var selectList = new SelectListViewModel()
                {
                    Categories = _context.Categories.OrderBy(n => n.Label).ToList(),
                    Offers = _context.Offers.OrderBy(n => n.Percentage).ToList()
                };

                ViewBag.Categories = new SelectList(selectList.Categories, "Id", "Label");
                ViewBag.Offers = new SelectList(selectList.Offers, "Id", "Percentage");

                return View(productToUpdate);
            }

            var offer = _context.Offers.Find(productToUpdate.OfferId);

            if (productToUpdate.OfferId != 1)
            {
                productUpdated = new Product()
                {
                    Id = productToUpdate.Id,
                    Title = productToUpdate.Title,
                    CategoryId = productToUpdate.CategoryId,
                    Description = productToUpdate.Description,
                    Image = productToUpdate.Image,
                    Price = productToUpdate.Price,
                    DiscountedPrice = productToUpdate.Price - (productToUpdate.Price * (offer.Percentage / 100)),
                    OfferId = productToUpdate.OfferId,
                };
            }
            else
            {
                productUpdated = new Product()
                {
                    Id = productToUpdate.Id,
                    Title = productToUpdate.Title,
                    CategoryId = productToUpdate.CategoryId,
                    Description = productToUpdate.Description,
                    Image = productToUpdate.Image,
                    Price = productToUpdate.Price,
                    DiscountedPrice = productToUpdate.Price,
                    OfferId = productToUpdate.OfferId,
                };
            }

            _context.Products.Update(productUpdated);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }



        // GET: Products/Delete/2
        public IActionResult Delete(int id)
        {
            var productToDelete = _context.Products.Find(id);

            if (productToDelete == null)
            {
                return View("NotFound");
            }

            var selectList = new SelectListViewModel()
            {
                Categories = _context.Categories.OrderBy(n => n.Label).ToList(),
                Offers = _context.Offers.OrderBy(n => n.Percentage).ToList()
            };

            ViewBag.Categories = new SelectList(selectList.Categories, "Id", "Label");
            ViewBag.Offers = new SelectList(selectList.Offers, "Id", "Percentage");

            return View(productToDelete);
        }

        // POST: Products/Delete/2
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var productToDelete = _context.Products.Find(id);

            if (productToDelete == null)
            {
                return View("NotFound");
            }

            _context.Products.Remove(productToDelete);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
