using Microsoft.AspNetCore.Identity;

namespace LazadaApi.Models.Entities
{
    public class User: IdentityUser
    {
        public string? FullName { get; set; } = null!;
        public string? AvatarUrl { get; set;} = null!;
        public string? Address { get; set; } = null!;
        
    }

}
