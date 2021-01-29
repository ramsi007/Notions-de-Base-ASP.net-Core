using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Identity_WebApp.Models;
using Identity_WebApp.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Identity_WebApp.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager; // User Manager qui s'coccupe des opérations CRUD du User
        private readonly SignInManager<ApplicationUser> signInManager; // s'occupe de Login et logout du Userprivate readonly SignInManager<ApplicationUser> signInManager; // s'occupe de Login et logout du User
        private readonly RoleManager<IdentityRole> roleManager; // s'occupe de Login et logout du Userprivate readonly SignInManager<ApplicationUser> signInManager; // s'occupe de Login et logout du User

        public AccountController(UserManager<ApplicationUser> userManager,
                                SignInManager<ApplicationUser> signInManager,
                                RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    Age = model.Age,
                    City = model.City
                };

                var result = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded) // Si tous ça passe bien => Login
                {
                    await signInManager.SignInAsync(user, false);  // false : pour le session Cookies : false 
                    return RedirectToAction("Index", "Home");
                }
                foreach (var error in result.Errors) // sinon Affiche moi la liste des erreurs 
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(model.Email, model.Password
                    , model.RememberMe, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError(string.Empty, "Email ou Password Incorrecte");
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        ///             /////---------------   les Roles  ---------------------------///
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var role = new IdentityRole
                {
                    Name = model.RoleName
                };

                var result = await roleManager.CreateAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                foreach (var err in result.Errors)
                    ModelState.AddModelError(string.Empty, err.Description);
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult RolesList()
        {
            return View(roleManager.Roles.ToList());
        }

        [HttpGet]
        [Authorize(Roles ="Admin, User")]
        public async Task<IActionResult> EditRole(string id)
        {
            var role = await roleManager.FindByIdAsync(id);

            var model = new EditRoleViewModel
            {
                RoleId = role.Id,
                RoleName = role.Name
            };

            foreach (var user in userManager.Users)
            {
                if (await userManager.IsInRoleAsync(user, role.Name))
                {
                    model.Users.Add(user.UserName);
                }
            }
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> EditRole(EditRoleViewModel model)
        {
            var role = await roleManager.FindByIdAsync(model.RoleId);
            role.Name = model.RoleName;
            var result = await roleManager.UpdateAsync(role);

            if (result.Succeeded)
            {
                return RedirectToAction("RolesList");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return View();
        }


        // 
        [HttpGet]
        public async Task<IActionResult> EditUsersInRole(string id)
        {
            var role = await roleManager.FindByIdAsync(id);

            if (role == null)
            {

            }

            ViewBag.id = id;
            var UsersList = new List<UserRoleViewModel>();
            foreach (var user in userManager.Users)
            {
                var userRoleVM = new UserRoleViewModel
                {
                    UserId = user.Id,
                    UserName = user.UserName
                };

                if (await userManager.IsInRoleAsync(user, role.Name))
                { userRoleVM.IsSelected = true; }
                else
                { userRoleVM.IsSelected = false; }

                UsersList.Add(userRoleVM);
            }

            return View(UsersList);

        }

        [HttpPost]
        public async Task<IActionResult> EditUsersInRole(List<UserRoleViewModel> usersList, string id)
        {
            var role = await roleManager.FindByIdAsync(id);

            for (int i=0; i<usersList.Count(); i++)
            {
                var userRoleVM = usersList[i];
                var user = await userManager.FindByIdAsync(userRoleVM.UserId);

                if(userRoleVM.IsSelected && !(await userManager.IsInRoleAsync(user, role.Name)))
                {
                    await userManager.AddToRoleAsync(user, role.Name);
                }
                else if(! userRoleVM.IsSelected && await userManager.IsInRoleAsync(user, role.Name))
                {
                    await userManager.RemoveFromRoleAsync(user, role.Name);
                }
            }
            return RedirectToAction("EditRole", new { id = id });
        }

        [HttpGet]

        public async Task<IActionResult> DeleteRole(string id)
        {
            var role = await roleManager.FindByIdAsync(id);

            return View(role);
        }

        [HttpPost]
        [ActionName("DeleteRole")]
        public async Task<IActionResult> DeleteRole_Confirm(string id)
        {
            var role = await roleManager.FindByIdAsync(id);
            var result = await roleManager.DeleteAsync(role);
            if(result.Succeeded)
            {
                return RedirectToAction("RolesList");
            }

            foreach (var err in result.Errors)
            {
                ModelState.AddModelError(string.Empty, err.Description);
            }

            return View(role);
        }

    }
}
