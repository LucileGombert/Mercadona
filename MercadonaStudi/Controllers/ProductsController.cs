using MercadonaStudi.Context;
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

        public async Task<IActionResult> Index()
        {
            var data = await _context.Products.ToListAsync();
            return View(data);
        }
    }
}
