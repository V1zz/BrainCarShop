using System;
using System.Web.Hosting;
using BrainCarShop.IdentityModels;
using BrainCarShop.Models.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

namespace BrainCarShop
{
    public partial class Startup
    {
        public void ConfigurationAuth(IAppBuilder app, Func<ApplicationUser> ApplicationUser)
        {
            app.CreatePerOwinContext(AppDbContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            app.CreatePerOwinContext<ApplicationRoleManager>(ApplicationRoleManager.Create);

        }
    }
}