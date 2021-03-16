using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InstaMel.Models;
using Microsoft.AspNetCore.Identity;

namespace InstaMel.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the InstaMelUser class
    public class InstaMelUser : IdentityUser
    {
        public string Name { get; set; }
        public string Photo { get; set; }
        public string Bio { get; set; }

        public virtual ICollection<Post> Posts{ get; set; }
        public virtual ICollection<Story> Stories{ get; set; }
    }
}
