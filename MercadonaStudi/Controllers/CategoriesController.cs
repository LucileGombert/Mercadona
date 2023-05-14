using MercadonaStudi.Context;
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
    }
}
