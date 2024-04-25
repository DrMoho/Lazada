using Microsoft.EntityFrameworkCore;

namespace Lazada.Models.Entities
{
    public class LazadaDbContext : DbContext
    {

        public LazadaDbContext (DbContextOptions<LazadaDbContext> options)
           : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Ví dụ: Thiết lập khóa chính (Primary Key) cho Product
            modelBuilder.Entity<Product>()
                .HasKey(p => p.ProductId);

            // Ví dụ: Thiết lập các thuộc tính cho Product
            modelBuilder.Entity<Product>()
                .Property(p => p.ProductName)
                .IsRequired();
        }
          public DbSet<Product> Products => Set<Product>();

    }
}
