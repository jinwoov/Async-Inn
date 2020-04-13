using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AsyncInnWebApp.Controllers
{
    public class HomeController : Controller
    {
        // rendering home index page
        public IActionResult Index()
        {
            return View();
        }
    }
}