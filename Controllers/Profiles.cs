using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstaMel.Controllers
{
    public class Profiles : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CreateProfile()
        {
            return View();
        }   

        [HttpPost]
        public IActionResult CreateProfile(string Name, string Bio, IFormFile Photo )
        {
            return View();
        }
    }
}
