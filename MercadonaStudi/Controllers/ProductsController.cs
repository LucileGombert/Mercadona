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

            return View(data);
        }


        // GET: Products/Create
        public IActionResult Create()
        {
            var selectionData = new SelectedItemsViewModel()
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
                var selectionData = new SelectedItemsViewModel()
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

            if (data == null)
            {
                return View("NotFound");
            }

            var selectionData = new SelectedItemsViewModel()
            {
                Categories = _context.Categories.OrderBy(n => n.Label).ToList(),
                Offers = _context.Offers.OrderBy(n => n.Percentage).ToList()
            };

            ViewBag.Categories = new SelectList(selectionData.Categories, "Id", "Label");
            ViewBag.Offers = new SelectList(selectionData.Offers, "Id", "Percentage");

            return View(data);
        }

        // POST: Products/Edit/2
        [HttpPost]
        public IActionResult Edit([Bind("Id, Title, CategoryId, Description, Image, Price, DiscountedPrice, OfferId")] Product product)
        {
            if (!ModelState.IsValid)
            {
                var selectionData = new SelectedItemsViewModel()
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

            _context.Products.Update(productUpdated);
            _context.SaveChanges();
            return RedirectToAction("Index");
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
