using Hospital.Web.Models;
using Hospital.Web.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Hospital.Web.Utilities.DAL.Concrate
{
    public class DbInitializer : IDbInitializer
    {
        private UserManager<IdentityUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        private ApplicationDbContext _cnn;

        public DbInitializer(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext cnn)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _cnn = cnn;
        }

        public void Initialize()
        {
            try
            {
                if (_cnn.Database.GetPendingMigrations().Count() > 0)
                {
                    _cnn.Database.Migrate();
                }
            }
            catch (Exception)
            {
                throw;
            }

            if (!_roleManager.RoleExistsAsync(WebSiteRoles.WebSite_Admin).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole(WebSiteRoles.WebSite_Admin)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(WebSiteRoles.WebSite_Patient)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(WebSiteRoles.WebSite_Doctor)).GetAwaiter().GetResult();

                _userManager.CreateAsync(new IdentityUser
                {
                    UserName = "Hızır",
                    Email = "hfurkanyasar@gmail.com"
                }, "Hızır@123").GetAwaiter().GetResult();

                var appUser = _userManager.FindByEmailAsync("hfurkanyasar@gmail.com").GetAwaiter().GetResult();
                if (appUser != null)
                {
                    _userManager.AddToRoleAsync(appUser, WebSiteRoles.WebSite_Admin).GetAwaiter().GetResult();
                }
            }
        }
    }
}








