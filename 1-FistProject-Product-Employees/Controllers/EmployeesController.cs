using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FistProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace FistProject.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly ApplicationDbContext db;

        public EmployeesController(ApplicationDbContext _db)
        {
            this.db = _db;
        }
        public IActionResult Index()
        {
            return View(db.Employees.ToList()); 
        }

        public IActionResult Details(int id)
        {
            return View(db.Employees.Find(id));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(db.Employees.Find(id));
        }

        [HttpPost]
        [ActionName("Edit")]
        public IActionResult Edit_Post( Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Update(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(db.Employees.Find(id));
        }

        [HttpPost]
        public IActionResult Delete(Employee employee)
        {
                db.Employees.Remove(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
        }
    }
}
