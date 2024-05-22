using System.ComponentModel.DataAnnotations;

namespace Lazada.Models.Entities
{
    public class SignIn
    {
        [Required, EmailAddress]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }


    }
}
