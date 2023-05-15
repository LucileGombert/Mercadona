using MercadonaStudi.Context;
using MercadonaStudi.Models;
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

        // Equivalent Index() en async
        //public async Task<IActionResult> IndexAsync()
        //{
        //    var data = await _context.Offers.ToListAsync();
        //    return View();
        //}

        
        // GET: Offers
        public IActionResult Index()
        {
            var data = _context.Offers.ToList();

            return View(data);
        }


        // GET: Offers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Offers/Create
        [HttpPost]
        public IActionResult Create([Bind("StartDate, EndDate, Percentage")] Offer offer)
        {
            if (!ModelState.IsValid)
            {
                return View(offer);
            }
            _context.Offers.Add(offer);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        // GET: Offers/Edit/2
        public IActionResult Edit(int id)
        {
            var data = _context.Offers.Find(id);

            if(data == null)
            {
                return View("NotFound");
            }

            return View(data);
        }

        // POST: Offers/Edit/2
        [HttpPost]
        public IActionResult Edit(int id, [Bind("Id, StartDate, EndDate, Percentage")] Offer offer)
        {
            if (!ModelState.IsValid)
            {
                return View(offer);
            }

            _context.Offers.Update(offer);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        // GET: Offers/Delete/2
        public IActionResult Delete(int id)
        {
            var data = _context.Offers.Find(id);

            if (data == null)
            {
                return View("NotFound");
            }

            return View(data);
        }

        // POST: Offers/Delete/2
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var data = _context.Offers.Find(id);

            if (data == null)
            {
                return View("NotFound");
            }

            _context.Offers.Remove(data);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
