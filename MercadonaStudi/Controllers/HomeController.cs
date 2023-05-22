using MercadonaStudi.Context;
using MercadonaStudi.Models;
using MercadonaStudi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics;

namespace MercadonaStudi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;
        private SelectListViewModel productList;


        // Constructeur
        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }



        // GET: Products
        public IActionResult Index()
        {
            var productList = new SelectListViewModel()
            {
                Categories = _context.Categories.OrderBy(n => n.Label).ToList(),
                Offers = _context.Offers.OrderBy(n => n.Percentage).ToList(),
                Products = _context.Products.Include(p => p.Category).Include(p => p.Offer).ToList()
            };

            ViewBag.Categories = new SelectList(productList.Categories, "Id", "Label");
            ViewBag.Offers = new SelectList(productList.Offers, "Id", "Percentage");

            return View(productList);
        }

        // POST: Products
        [HttpPost]
        public IActionResult Index(SelectListViewModel homeViewModel)
        {
            var selectedCategory = homeViewModel.Category.Id;

            if(selectedCategory == 0)
            {
                productList = new SelectListViewModel()
                {
                    Categories = _context.Categories.OrderBy(n => n.Label).ToList(),
                    Offers = _context.Offers.OrderBy(n => n.Percentage).ToList(),
                    Products = _context.Products.Include(p => p.Category).Include(p => p.Offer).ToList()
                };
            } 
            else
            {
                productList = new SelectListViewModel()
                {
                    Categories = _context.Categories.OrderBy(n => n.Label).ToList(),
                    Offers = _context.Offers.OrderBy(n => n.Percentage).ToList(),
                    Products = _context.Products.Include(p => p.Category).Include(p => p.Offer).Where(x => x.CategoryId == selectedCategory).ToList()
                };
            }

            ViewBag.Categories = new SelectList(productList.Categories, "Id", "Label");
            ViewBag.Offers = new SelectList(productList.Offers, "Id", "Percentage");
            Console.WriteLine(productList);
            return View(productList);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}