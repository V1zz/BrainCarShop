using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace BrainCarShop.Models.Identity
{
    public class EmailService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            return Task.FromResult(0);
        }
    }
}