using Microsoft.AspNetCore.Identity;

namespace TalabatG02.Core.Entities.Identity
{
    public class AppUser : IdentityUser
    {
        public string DisplayName { get; set; }
        public Address Address { get; set; }//Navigationl Prop =>1

    }
}
