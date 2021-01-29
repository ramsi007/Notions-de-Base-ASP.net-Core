using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Session_App.Controllers
{
    [Route("Items")]

    public class ItemsController : Controller
    {
        [Route("MyName")]
        public IActionResult Index()
        {
            ViewBag.name = HttpContext.Session.GetString("Name");
            return View();
        }
    }
}
