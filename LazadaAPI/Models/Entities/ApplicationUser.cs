using Microsoft.AspNetCore.Identity;

namespace LazadaApi.Models.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; } = null!;
        public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; } = null!;
        public virtual ICollection<IdentityUserToken<string>> Tokens { get; set; } = null!;
        public virtual ICollection<IdentityUserRole<string>> UserRoles { get; set; } = null!;
      


    }

}
