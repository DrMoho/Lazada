using System.ComponentModel.DataAnnotations;

namespace LazadaApi.Models.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public double? Price {get ; set;}
        public double? OrPrice { get; set; }
       
    }
}
