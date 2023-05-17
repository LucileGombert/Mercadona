using Microsoft.AspNetCore.Mvc;
using MercadonaStudi.Context;
using MercadonaStudi.Models;

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


        
        // GET: Offers
        public IActionResult Index()
        {
            var offerList = _context.Offers.ToList();

            return View(offerList);
        }



        // GET: Offers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Offers/Create
        [HttpPost]
        public IActionResult Create([Bind("StartDate, EndDate, Percentage")] Offer offerToCreate)
        {
            if (!ModelState.IsValid)
            {
                return View(offerToCreate);
            }

            _context.Offers.Add(offerToCreate);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }



        // GET: Offers/Edit/2
        public IActionResult Edit(int id)
        {
            var offerToUpdate = _context.Offers.Find(id);

            if(offerToUpdate == null)
            {
                return View("NotFound");
            }

            return View(offerToUpdate);
        }

        // POST: Offers/Edit/2
        [HttpPost]
        public IActionResult Edit([Bind("Id, StartDate, EndDate, Percentage")] Offer offerToUpdate)
        {
            if (!ModelState.IsValid)
            {
                return View(offerToUpdate);
            }

            _context.Offers.Update(offerToUpdate);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }



        // GET: Offers/Delete/2
        public IActionResult Delete(int id)
        {
            var offerToDelete = _context.Offers.Find(id);

            if (offerToDelete == null)
            {
                return View("NotFound");
            }

            return View(offerToDelete);
        }

        // POST: Offers/Delete/2
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var offerToDelete = _context.Offers.Find(id);

            if (offerToDelete == null)
            {
                return View("NotFound");
            }

            _context.Offers.Remove(offerToDelete);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
