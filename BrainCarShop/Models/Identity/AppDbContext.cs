using System.Data.Entity;
using BrainCarShop.IdentityModels;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BrainCarShop.Models.Identity
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext() : base("CarShopContext", throwIfV1Schema: false) { }

        static AppDbContext()
        {
            Database.SetInitializer<AppDbContext>(new AppDbInitializer());
        }

        public static AppDbContext Create()
        {
            return new AppDbContext();
        }
    }
}
