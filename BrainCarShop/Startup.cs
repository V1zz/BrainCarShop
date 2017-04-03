using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(BrainCarShop.Startup))]

namespace BrainCarShop
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
