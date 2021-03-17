using InstaMel.Areas.Identity.Data;
using InstaMel.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace InstaMel.Classes
{
    public class CBase
    {
        private readonly IWebHostEnvironment host;
        private readonly UserManager<InstaMelUser> manager;
        private readonly InstaMelContext db;
        public CBase(IWebHostEnvironment _Host , UserManager<InstaMelUser> _Manager , InstaMelContext _Db)
        {
            host = _Host;
            manager = _Manager;
            db = _Db;
        }

        public void SaveImage(IFormFile File)
        {
            if( File != null)
            {
                if(
                    File.FileName.IndexOf(".jpg") > 0 || 
                    File.FileName.IndexOf(".png") > 0 ||
                    File.FileName.IndexOf(".jpeg") > 0
                    )
                {
                    string path = System.IO.Path.Combine(host.WebRootPath, "Uploads", File.FileName);
                    File.CopyTo(new FileStream(path, FileMode.Create));

                }
            }
        }

        public InstaMelUser GetCurrentUser( ClaimsPrincipal User)
        {
            return db.Users.Find(manager.GetUserId(User));
        }

        public void SaveUser( InstaMelUser u)
        {
            db.Users.Update(u);
            db.SaveChanges();
        }
    }
}
