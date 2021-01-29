using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UseTemplate.Models
{
    public class SliderViewComponent: ViewComponent
    {
        private readonly ApplicationDbContext db;

        public SliderViewComponent(ApplicationDbContext _db)
        {
            this.db = _db;
        }

        public IViewComponentResult Invoke()
        {
            return View(db.Sliders.ToList());
        }
    }
}
