using MercadonaStudi.Context;
using MercadonaStudi.Models;
using Microsoft.AspNetCore.Mvc;

namespace MercadonaStudi.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly AppDbContext _context;

        // Constructeur
        public CategoriesController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var data = _context.Categories.ToList();
            return View(data);
        }

        // GET: Categories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        [HttpPost]
        public IActionResult Create([Bind("Label")] Category category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }
            _context.Categories.Add(category);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
