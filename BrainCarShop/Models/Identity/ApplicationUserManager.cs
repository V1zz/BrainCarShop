using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BrainCarShop.IdentityModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace BrainCarShop.Models.Identity
{
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store) : base(store) { }

        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options,
                                                    IOwinContext owinContext)
        {
            var manager = new ApplicationUserManager(new UserStore<ApplicationUser> (owinContext.Get<AppDbContext>()));

            // Configure validation logic for usernames
            manager.UserValidator = new UserValidator<ApplicationUser>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            // Configure validation logic for passwords
            manager.PasswordValidator = new PasswordValidator()
            {
                RequireDigit = true,
                RequiredLength = 6,
                RequireLowercase = true,
                RequireNonLetterOrDigit = true,
                RequireUppercase = true
            };

            // Configure user lockout defaults
            manager.UserLockoutEnabledByDefault = true;
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            manager.MaxFailedAccessAttemptsBeforeLockout = 5;

            // Register two factor authentication providers
            manager.RegisterTwoFactorProvider("PhoneCode",  new PhoneNumberTokenProvider<ApplicationUser>
            {
                MessageFormat = "Personal code is {0}"
            });

            manager.RegisterTwoFactorProvider("EmailCode", new EmailTokenProvider<ApplicationUser>
            {
                Subject = "Security code",
                BodyFormat = "Personal code is {0}"
            });

            manager.EmailService = new EmailService();
            manager.SmsService = new SmsService();

            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider = 
                    new DataProtectorTokenProvider<ApplicationUser>(
                        dataProtectionProvider.Create("ASP.NET Identity"));
            }

            return manager;
        }

        public virtual async Task<IdentityResult> AddUserToRolesTask(
            string userId, IList<string> roles)
        {
            var userRoleStore = (IUserRoleStore<ApplicationUser, string>) Store;
            var user = await FindByIdAsync(userId).ConfigureAwait(false);

            if (user == null)
                throw new InvalidOperationException("Invalid user Id");

            var userRoles = await userRoleStore
                .GetRolesAsync(user)
                .ConfigureAwait(false);

            // Add user to each role using UserRoleStore
            foreach (var role in roles.Where(role => !userRoles.Contains(role)))
            {
                await userRoleStore.AddToRoleAsync(user, role)
                                   .ConfigureAwait(false);
            }

            return await UpdateAsync(user).ConfigureAwait(false);
        }

        //public virtual async Task<IdentityResult> RemoveUserFromRoleTask(string userId, IList<string> roles)
        //{
            
        //}
    }
}