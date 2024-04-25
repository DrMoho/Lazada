using Microsoft.EntityFrameworkCore;

namespace LazadaApi.Models.Entities
{
    public class LazadaApiDbContext : DbContext
    {

        public LazadaApiDbContext(DbContextOptions<LazadaApiDbContext> options)
           : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Ví dụ: Thiết lập khóa chính (Primary Key) cho Product
            modelBuilder.Entity<Product>()
                .HasKey(p => p.Id);

            // Ví dụ: Thiết lập các thuộc tính cho Product
            modelBuilder.Entity<Product>()
                .Property(p => p.Name)
                .IsRequired();

            modelBuilder.Entity<ShoppingCart>()
            .HasKey(sc => sc.Id);
            modelBuilder.Entity<CartItem>()
           .HasKey(ct => ct.Id);

        }
        public DbSet<Product> Products => Set<Product>();
        public DbSet<ShoppingCart> ShoppingCarts => Set<ShoppingCart>();
        public DbSet<CartItem> CartItems => Set<CartItem>();

    }
}
