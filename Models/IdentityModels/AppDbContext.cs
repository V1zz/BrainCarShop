using Microsoft.AspNet.Identity.EntityFramework;

namespace Models.IdentityModels
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext() : base("CarShopContext", throwIfV1Schema: false)
        {
            
        }

        public static AppDbContext Create()
        {
            return new AppDbContext();
        }
    }
}
