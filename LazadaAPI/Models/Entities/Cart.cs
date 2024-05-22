using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LazadaApi.Models.Entities
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }


        public ApplicationUser ApplicationUsers { get; set; } = null!;
        
        [ForeignKey("ApplicationUser")]
        public int UserId { get; set; }


    }
}
