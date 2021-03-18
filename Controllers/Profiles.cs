using InstaMel.Areas.Identity.Data;
using InstaMel.Classes;
using InstaMel.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstaMel.Controllers
{
    public class Profiles : Controller
    {
        private readonly IWebHostEnvironment host;
        private readonly UserManager<InstaMelUser> manager;
        private readonly InstaMelContext db;
        CBase cb; 
        public Profiles(IWebHostEnvironment _Host, UserManager<InstaMelUser> _Manager, InstaMelContext _Db)
        {
            host = _Host;
            manager = _Manager;
            db = _Db;
            cb = new CBase(host, manager, db);
        }


        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult CreateProfile()
        {
            return View();
        }   

        [HttpPost]
        public IActionResult CreateProfile(string Name, string Bio, IFormFile Photo )
        {
            cb.SaveImage(Photo);
            var u = cb.GetCurrentUser(User);
            u.Bio = Bio;
            u.Name = Name;
            u.Photo = Photo.FileName;
            cb.SaveUser(u);
            return View();
        }

        [Authorize]
        public IActionResult Myprofile()
        {
            return View(cb.GetCurrentUser(User));
        }

        [HttpPost]
        public IActionResult EditProfile(string Name, string Bio)
        {
            var u = cb.GetCurrentUser(User);
            u.Bio = Bio;
            u.Name = Name;
            cb.SaveUser(u);

            return RedirectToAction("MyProfile");
        }

        [HttpPost]
        public async Task<bool> chPass(string oldPass, string newPass)
        {
            var u = cb.GetCurrentUser(User);
            var result = await manager.ChangePasswordAsync(u, oldPass, newPass);


            return result.Succeeded;
        }
    }
}
