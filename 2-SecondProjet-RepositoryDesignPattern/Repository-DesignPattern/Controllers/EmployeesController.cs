using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Repository_DesignPattern.Models;
using Repository_DesignPattern.Models.Repository.IRepository;

namespace Repository_DesignPattern.Controllers
{
    public class EmployeesController : Controller
    {

        private readonly IServiceRepository<Employee> EmployeeRepository;
        public EmployeesController(IServiceRepository<Employee> _employeeRepository)
        {
            this.EmployeeRepository = _employeeRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(EmployeeRepository.GetAll());
        }

        [HttpPost]
        // Ici on doit donner le même parametre que celui de View Index
        public IActionResult Index(string term)
        {
            if (term != null)
                return View(EmployeeRepository.Search(term));
            //else  // on peut mettre le else ou bien non
            return View(EmployeeRepository.GetAll());
        }


        public IActionResult Details(int id)
        {
            return View(EmployeeRepository.FindById(id));
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
                EmployeeRepository.Add(employee);
                return RedirectToAction("Index");
            }

            return View();
        } 

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(EmployeeRepository.FindById(id));
        }


        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            if(ModelState.IsValid)
            {
                EmployeeRepository.Update(employee);
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(EmployeeRepository.FindById(id));
        }


        [HttpPost]
        [ActionName("Delete")]
        public IActionResult Delete_Post(int id)
        {
                EmployeeRepository.Delete(id);
                return RedirectToAction("Index");
          
        }
    }
}
