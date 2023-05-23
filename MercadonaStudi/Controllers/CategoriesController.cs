using MercadonaStudi.Context;
using MercadonaStudi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MercadonaStudi.Controllers
{
    [Authorize]
    public class CategoriesController : Controller
    {
        private readonly AppDbContext _context;

        

        // Constructeur
        public CategoriesController(AppDbContext context)
        {
            _context = context;
        }

        public List<Category> GetAllCategories()
        {
            var categories = _context.Categories.ToList();

            return categories;
        }

        // GET: Categories
        public IActionResult Index()
        {
            var categoryList = GetAllCategories();

            return View(categoryList);
        }



        // GET: Categories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        [HttpPost]
        public IActionResult Create([Bind("Label")] Category categoryToCreate)
        {
            if (!ModelState.IsValid)
            {
                return View(categoryToCreate);
            }

            _context.Categories.Add(categoryToCreate);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }



        // GET: Categories/Edit/2
        public IActionResult Edit(int id)
        {
            var categoryToUpdate = _context.Categories.Find(id);

            if (categoryToUpdate == null)
            {
                return View("NotFound");
            }

            return View(categoryToUpdate);
        }

        // POST: Categories/Edit/2
        [HttpPost]
        public IActionResult Edit([Bind("Id, Label")] Category categoryToUpdate)
        {
            if (!ModelState.IsValid)
            {
                return View(categoryToUpdate);
            }

            _context.Categories.Update(categoryToUpdate);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }



        // GET: Categories/Delete/2
        public IActionResult Delete(int id)
        {
            var categoryToDelete = _context.Categories.Find(id);

            if (categoryToDelete == null)
            {
                return View("NotFound");
            }

            return View(categoryToDelete);
        }

        // POST: Categories/Delete/2
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var categoryToDelete = _context.Categories.Find(id);

            if (categoryToDelete == null)
            {
                return View("NotFound");
            }

            _context.Categories.Remove(categoryToDelete);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
