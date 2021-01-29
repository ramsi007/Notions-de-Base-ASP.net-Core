using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FistProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace FistProject.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext db;

        // On crée le Constructeur du Controlleur Product 
        // ce Controlleur controlle la Classe Product
        public ProductsController(ApplicationDbContext _db)
        {
            this.db = _db;
        }

        public IActionResult Index()
        {
            //Page home
            return View(db.Products.ToList());
        }

        public IActionResult Details(int id)
        {
            return View(db.Products.Find(id));
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View ();

        }

        [HttpGet]

        public ActionResult Delete(int id)
        {
            return View(db.Products.Find(id));
        }

        [HttpPost]

        public ActionResult Delete(Product product)
        {
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]

        public ActionResult Edit(int id)
        {
            return View(db.Products.Find(id));
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if(ModelState.IsValid)
            {
                db.Products.Update(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();

        }


    }
}
