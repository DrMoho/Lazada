using System.ComponentModel.DataAnnotations;

namespace Lazada.Models.Entities
{
    public class SignUp
    {
        [Required, EmailAddress]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        public string? ConfirmPassword { get; set; }


    }
}
