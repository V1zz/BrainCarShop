using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;


namespace BrainCarShop.Models.Identity
{
    public class ApplicationRoleManager  : RoleManager<IdentityRole>
    {
        public ApplicationRoleManager(IRoleStore<IdentityRole, string> store) : base(store) { }

        public static ApplicationRoleManager Create(IdentityFactoryOptions<ApplicationRoleManager> options,
                                                    IOwinContext owinContext)
        {
            var manager = new ApplicationRoleManager(
                new RoleStore<IdentityRole>(
                    owinContext.Get<AppDbContext>()));
            return manager;
        }
    }
}