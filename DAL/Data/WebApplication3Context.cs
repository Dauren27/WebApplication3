using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Common.Models;

namespace DAL.Data
{
    public class WebApplication3Context : DbContext
    {

        public WebApplication3Context (DbContextOptions<WebApplication3Context> options)
            : base(options)
        {
        }

        public DbSet<Common.Models.Employee> Employee { get; set; } = default!;

        public DbSet<Project> Project { get; set; } = default!;
    }
}
