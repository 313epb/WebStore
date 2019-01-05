using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Checkout()
        {
            return View();
        }

        public IActionResult Blogpost()
        {
            return View();
        }

        public IActionResult BlogSingle()
        {
            return View();
        }

        

        public IActionResult ContactUS()
        {
            return View();
        }

        

        public IActionResult NotFound()
        {
            return View();
        }
    }
}