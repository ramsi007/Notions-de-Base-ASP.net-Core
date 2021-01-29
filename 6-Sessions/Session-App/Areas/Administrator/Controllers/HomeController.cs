using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Session_App.Areas.Administrator.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("Administrator/Index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
