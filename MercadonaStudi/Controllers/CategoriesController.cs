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

        // GET: Categories
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


        // GET: Categories/Edit/2
        public IActionResult Edit(int id)
        {
            var data = _context.Categories.Find(id);

            if (data == null)
            {
                return View("NotFound");
            }

            return View(data);
        }

        // POST: Categories/Edit/2
        [HttpPost]
        public IActionResult Edit(int id, [Bind("Id, Label")] Category category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }

            _context.Categories.Update(category);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
