using MercadonaStudi.Context;
using MercadonaStudi.Models;
using MercadonaStudi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace MercadonaStudi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;

        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            //var data = _context.Products.Include(p => p.Category).Include(p => p.Offer).ToList();
            var model = new HomeViewModel()
            {
                Categories = _context.Categories.OrderBy(n => n.Label).ToList(),
                Offers = _context.Offers.OrderBy(n => n.Percentage).ToList(),
                Products = _context.Products.Include(p => p.Category).Include(p => p.Offer).ToList()
            };

            ViewBag.Categories = new SelectList(model.Categories, "Id", "Label");
            ViewBag.Offers = new SelectList(model.Offers, "Id", "Percentage");

            return View(model);
        }

        [HttpPost]
        public IActionResult Index(HomeViewModel model)
        {
            var selectedCategory = model.Category.Id;

            var list = new HomeViewModel()
            {
                Categories = _context.Categories.OrderBy(n => n.Label).ToList(),
                Offers = _context.Offers.OrderBy(n => n.Percentage).ToList(),
                Products = _context.Products.Include(p => p.Category).Include(p => p.Offer).Where(x => x.CategoryId == selectedCategory).ToList()
            };

            ViewBag.Categories = new SelectList(model.Categories, "Id", "Label");
            ViewBag.Offers = new SelectList(model.Offers, "Id", "Percentage");
            //var selectedCategory = model.Category.Id;
            //var filteredProducts = _context.Products.Where(x => x.CategoryId == selectedCategory).ToList();
            //return RedirectToAction("Index", "Home");
            return View(list);
        }


        public IActionResult IndexFilter()
        {
            //var data = _context.Products.Include(p => p.Category).Include(p => p.Offer).ToList();
            var model = new HomeViewModel()
            {
                Categories = _context.Categories.OrderBy(n => n.Label).ToList(),
                Products = _context.Products.Include(p => p.Category).Include(p => p.Offer).ToList()
            };

            ViewBag.Categories = new SelectList(model.Categories, "Id", "Label");
            //return View(data);
            return View(model);
        }

        // GET: Products/Filter/////
        [HttpPost]
        public IActionResult ListFilter(int id)
        {
            var selectedCategory = _context.Categories.Find(id);

            if (selectedCategory == null)
            {
                return View("NotFound");
            }

            var products = _context.Products.Include(p => p.Category).Include(p => p.Offer).ToList();

            var allCategories = _context.Categories.ToList();

            if (selectedCategory != null && products != null)
            {
                //IEnumerable<Product> filteredProducts = products.Where(x => x.Category.Contains(selectedCategory));

                //var model = new HomeViewModel
                //{
                //    Products = filteredProducts,
                //    Categories = allCategories
                //};

                //return View(model);
            }

            return RedirectToAction("Index", "Home");

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}