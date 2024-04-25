using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LazadaApi.Models.Entities
{
    public class CartItem
    {
        [Key]
        public int Id { get; set; }

        public ShoppingCart? ShoppingCart { get; set; }

        [ForeignKey("ShoppingCart")]
        public int ShoppingCartId { get; set; } 
        
        public Product? Product { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }
    }
}
