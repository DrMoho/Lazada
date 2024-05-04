using Microsoft.AspNetCore.Identity;

namespace LazadaApi.Models.Entities
{
    public class ApplicationRole : IdentityRole
    {
        public virtual ICollection<IdentityRoleClaim<string>> RoleClaims { get; set; } = null!;
        public virtual ICollection<IdentityUserRole<string>> UserRoles { get; set; } = null!;
    }

}
