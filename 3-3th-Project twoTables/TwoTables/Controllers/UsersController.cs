using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TwoTables.Models;
using TwoTables.Models.Repository.IRepository;

namespace TwoTables.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserRepository<User> userRepository;
        private readonly IUserTypeRepository<UserType> userTypeRepository;

        public UsersController(IUserRepository<User> _userRepository, IUserTypeRepository<UserType> _userTypeRepository)
        {
            this.userRepository = _userRepository;
            this.userTypeRepository = _userTypeRepository;
        }

        public IActionResult Index()
        {
            return View(userRepository.List());
        }

        [HttpPost]
        public IActionResult Index(string term)
        {
            if (term == null)
                return View(userRepository.List());
            else
                return View(userRepository.Search(term));
        }

        public IActionResult Details(int id)
        {
            return View(userRepository.Find(id));
        }

        [HttpGet]
        public IActionResult Create ()
        {
            SelectList selectLists = new SelectList(userTypeRepository.List(), "UserTypeId", "TypeDesc"); //ce deux ligne
            ViewBag.items = selectLists; // correspondent aux selected items
            return View();
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                userRepository.Add(user);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            SelectList selectLists = new SelectList(userTypeRepository.List(), "UserTypeId", "TypeDesc"); //ce deux ligne
            ViewBag.items = selectLists; // correspondent aux selected items
            return View(userRepository.Find(id));
        }

        [HttpPost]
        public IActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                userRepository.Edit(user);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(userRepository.Find(id));
        }

        [HttpPost]
        public IActionResult Delete (User user)
        {
            userRepository.Delete(user);
            return RedirectToAction("Index");
        }

        [HttpGet]
        
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Login(User model)
        {
            var myUser = userRepository.Login(model);
            if(myUser == null)
            {
                ViewBag.Err = "Login ou mot de passe incorrecte";
                return View();
            }
            return RedirectToAction("Index");
        }


    }
}
