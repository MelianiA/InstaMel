using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InstaMel.Areas.Identity.Data;
using InstaMel.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InstaMel.Data
{
    public class InstaMelContext : IdentityDbContext<InstaMelUser>
    {
        public InstaMelContext(DbContextOptions<InstaMelContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<Chat> Chat { get; set; }
        public DbSet<Follow> Follow { get; set; }
        public DbSet<Notifications> Notifications { get; set; }
        public DbSet<Seen> Seen { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Story> Stories { get; set; }
    }
}
