using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication9.Models;

namespace WebApplication9.Data
{
    public class WebApplication9Context : DbContext
    {
        public WebApplication9Context (DbContextOptions<WebApplication9Context> options)
            : base(options)
        {
        }

        public DbSet<WebApplication9.Models.Student> Student { get; set; }

        public DbSet<WebApplication9.Models.course> course { get; set; }

        public DbSet<WebApplication9.Models.user> user { get; set; }

        public DbSet<WebApplication9.Models.batch> batch { get; set; }

        public DbSet<WebApplication9.Models.registration> registration { get; set; }
    }
}
