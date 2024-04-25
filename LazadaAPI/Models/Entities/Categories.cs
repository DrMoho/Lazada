using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LazadaApi.Models.Entities
{
    public class Categories
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }

        public Product? Product { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }

    }
}
