﻿using MercadonaStudi.Context;
using MercadonaStudi.Models;
using MercadonaStudi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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


        //// GET: Products/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Products/Create
        //[HttpPost]
        //public IActionResult Create([Bind("Title, Description, Image, Price")] Product product)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(product);
        //    }
        //    _context.Products.Add(product);
        //    _context.SaveChanges();
        //    return RedirectToAction("Index");
        //}



        // GET: Products/Create
        public IActionResult Create()
        {
            var selectionData = new NewProductSelectionsViewModel()
            {
                Categories = _context.Categories.OrderBy(n => n.Label).ToList(),
                Offers = _context.Offers.OrderBy(n => n.Percentage).ToList()
            };
           
            ViewBag.Categories = new SelectList(selectionData.Categories, "Id", "Label");
            ViewBag.Offers = new SelectList(selectionData.Offers, "Id", "Percentage");

            return View();
        }

        // POST: Products/Create
        [HttpPost]
        public IActionResult Create([Bind("Title, CategoryId, Description, Image, Price, OfferId")] Product product)
        {
            if (!ModelState.IsValid)
            {
                var selectionData = new NewProductSelectionsViewModel()
                {
                    Categories = _context.Categories.OrderBy(n => n.Label).ToList(),
                    Offers = _context.Offers.OrderBy(n => n.Percentage).ToList()
                };

                ViewBag.Categories = new SelectList(selectionData.Categories, "Id", "Label");
                ViewBag.Offers = new SelectList(selectionData.Offers, "Id", "Percentage");

                return View(product);
            }

            _context.Products.Add(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        // GET: Products/Edit/2
        public IActionResult Edit(int id)
        {
            var data = _context.Products.Find(id);

            if (data == null)
            {
                return View("NotFound");
            }

            var selectionData = new NewProductSelectionsViewModel()
            {
                Categories = _context.Categories.OrderBy(n => n.Label).ToList(),
                Offers = _context.Offers.OrderBy(n => n.Percentage).ToList()
            };

            ViewBag.Categories = new SelectList(selectionData.Categories, "Id", "Label");
            ViewBag.Offers = new SelectList(selectionData.Offers, "Id", "Percentage");

            return View(data);
        }

        // POST: Products/Edit/2
        [HttpPost]
        public IActionResult Edit([Bind("Id, Title, CategoryId, Description, Image, Price, OfferId")] Product product)
        {
            if (!ModelState.IsValid)
            {
                var selectionData = new NewProductSelectionsViewModel()
                {
                    Categories = _context.Categories.OrderBy(n => n.Label).ToList(),
                    Offers = _context.Offers.OrderBy(n => n.Percentage).ToList()
                };

                ViewBag.Categories = new SelectList(selectionData.Categories, "Id", "Label");
                ViewBag.Offers = new SelectList(selectionData.Offers, "Id", "Percentage");

                return View(product);
            }

            _context.Products.Update(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
