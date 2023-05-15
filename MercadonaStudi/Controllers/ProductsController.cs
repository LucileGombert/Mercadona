using MercadonaStudi.Context;
using MercadonaStudi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MercadonaStudi.Controllers
{
    public class ProductsController : Controller
    {
        private readonly AppDbContext _context;

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
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        public IActionResult Create([Bind("Title, Description, Image, Price")] Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            _context.Products.Add(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
