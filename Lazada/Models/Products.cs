using System.ComponentModel.DataAnnotations;

namespace Lazada.Models
{
    public class Products
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        public string? ProductName { get; set; }
        public double? Price {get ; set;}
        public double? OrPrice { get; set; }
       
    }
}
