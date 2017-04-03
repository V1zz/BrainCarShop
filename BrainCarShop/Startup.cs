using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security.Cookies;

[assembly: OwinStartup(typeof(BrainCarShop.Startup))]

namespace BrainCarShop
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            
        }

        //public Task ValidateIdentity(CookieValidateIdentityContext context)
        //{
        //    return null;
        //}

        //public void ResponseSignIn(CookieResponseSignInContext context) {}
        //public void ApplyRedirect(CookieApplyRedirectContext context) {}
    }
}
