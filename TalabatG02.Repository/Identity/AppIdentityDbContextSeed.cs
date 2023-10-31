
using Microsoft.AspNetCore.Identity;

namespace TalabatG02.Core.Entities.Identity
{
    public static class AppIdentityDbContextSeed
    {
        public static async Task SeeedUsersAsync(UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var User = new AppUser()
                {
                    DisplayName = "Mohamed Hassan",
                    Email = "mh0056592@gmail.com",
                    UserName = "Mohamed.Hassan",
                    PhoneNumber = "01065729511"
                };
                await userManager.CreateAsync(User, "P@ssw0rd");
            }
        }
    }
}
