using Hospital.Web.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Web.Models;

namespace Hospital.Web.Repositories
{
   public class ApplicationDbContext:IdentityDbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>opt):base(opt)
        {

        }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
    }
}
