using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UseTemplate.Models;

namespace UseTemplate.ViewComponents
{
    public class MenuViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext db;

        public MenuViewComponent(ApplicationDbContext _db)
        {
            this.db = _db;
        }

        public IViewComponentResult Invoke()
        {
            return View(db.Menus.ToList());
        }
    }
}
