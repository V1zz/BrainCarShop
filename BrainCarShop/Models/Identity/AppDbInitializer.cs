using System.Data.Entity;
using System.Web;
using BrainCarShop.IdentityModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace BrainCarShop.Models.Identity
{
    public class AppDbInitializer : DropCreateDatabaseIfModelChanges<AppDbContext>
    {
        protected override void Seed(AppDbContext context)
        {
            InitializeIdentityForEF(context);
            base.Seed(context);
        }

        public static void InitializeIdentityForEF(AppDbContext context)
        {
            var userManager = HttpContext.Current
                                         .GetOwinContext()
                                         .GetUserManager<ApplicationUserManager>();

            var roleManager = HttpContext.Current
                                         .GetOwinContext()
                                         .GetUserManager<ApplicationRoleManager>();

            const string name = "admin@admin.com";
            const string password = "Admin@123456";
            const string roleName = "Admin";

            //Create Role Admin if it does not exist
            var role = roleManager.FindByName(roleName);
            if (role == null)
            {
                role = new IdentityRole(roleName);
                var roleResult = roleManager.Create(role);
            }

            var user = userManager.FindByName(name);
            if (user == null)
            {
                user = new ApplicationUser
                {
                    UserName = name,
                    Email = name
                };
                var userResult = userManager.Create(user, password);
                userResult = userManager.SetLockoutEnabled(user.Id, false);
            }
            
            // Add user admin to Role Admin if not already added
            var rolesForUser = userManager.GetRoles(user.Id);
            if (!rolesForUser.Contains(role.Name))
            {
                var result = userManager.AddToRole(user.Id, role.Name);
            }
        }
    }
}