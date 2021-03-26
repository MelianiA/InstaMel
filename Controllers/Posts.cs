using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstaMel.Controllers
{
    public class Posts : Controller
    {
        [HttpPost]
        public void UploadPost(IFormFile[] f, string desc)
        {

        }
    }
}
