using MercadonaStudi.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MercadonaStudi.Controllers
{
    public class OffersController : Controller
    {
        private readonly AppDbContext _context;

        // Constructeur
        public OffersController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var data = _context.Offers.ToList();
            return View();
        }

        // Equivalent Index() en async
        public async Task<IActionResult> IndexAsync()
        {
            var data = await _context.Offers.ToListAsync();
            return View();
        }
    }
}
