using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace LazadaApi.Models.Entities
{
    public class LazadaApiDbContext : IdentityDbContext<User>
    {

        public LazadaApiDbContext(DbContextOptions<LazadaApiDbContext> options)
           : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder
                .Entity<IdentityUserLogin<string>>()
                .HasKey(l => new { l.LoginProvider, l.ProviderKey });

            // Configure IdentityUserRole as keyless
            modelBuilder.Entity<IdentityUserRole<string>>()
                .HasKey(l => new { l.UserId, l.RoleId });
            modelBuilder.Entity<IdentityUserToken<string>>()
                .HasKey(l => new { l.UserId, l.LoginProvider, l.Name });

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
