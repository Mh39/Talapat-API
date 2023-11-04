using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TalabatG02.Core.Entities.Identity;

namespace TalabatG02.APIs.Extentions
{
    public static class UserManagerExtention
    {
        public static async Task<AppUser?> FindUserWithAdressByEmailAsync(this UserManager<AppUser> userManager, ClaimsPrincipal currentuser)
        {
            var email = currentuser.FindFirstValue(ClaimTypes.Email);
            var user = await userManager.Users.Include(u => u.Address).FirstOrDefaultAsync(u => u.Email == email);
            return user;
        }
    }
}
