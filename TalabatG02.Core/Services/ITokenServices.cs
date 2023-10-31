using Microsoft.AspNetCore.Identity;
using TalabatG02.Core.Entities.Identity;

namespace TalabatG02.Core.Services
{
    public interface ITokenServices
    {
        Task<string> CreateTokenAsync(AppUser user, UserManager<AppUser> userManager);
    }
}
