using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace LazadaApi.Models.Entities
{
    public class LazadaApiDbContext : IdentityDbContext
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


            modelBuilder.Entity<ApplicationUser>(b =>
                {
                    // Each User can have many UserClaims
                    b.HasMany(e => e.Claims)
                        .WithOne()
                        .HasForeignKey(uc => uc.UserId)
                        .IsRequired();

                    // Each User can have many UserLogins
                    b.HasMany(e => e.Logins)
                        .WithOne()
                        .HasForeignKey(ul => ul.UserId)
                        .IsRequired();

                    // Each User can have many UserTokens
                    b.HasMany(e => e.Tokens)
                        .WithOne()
                        .HasForeignKey(ut => ut.UserId)
                        .IsRequired();
                    // Each User can have many entries in the UserRole join table
                    b.HasMany(e => e.UserRoles)
                        .WithOne()
                        .HasForeignKey(ur => ur.UserId)
                        .IsRequired();
                });


            modelBuilder.Entity<ApplicationRole>()
                        .HasMany(r => r.RoleClaims)
                        .WithOne()
                        .HasForeignKey(rc => rc.RoleId)
                        .IsRequired();

            modelBuilder.Entity<ApplicationRole>()
                        .HasMany(r => r.UserRoles)
                        .WithOne()
                        .HasForeignKey(rc => rc.RoleId)
                        .IsRequired();


            // Ví dụ: Thiết lập khóa chính (Primary Key) cho Product
            modelBuilder.Entity<Product>()
                .HasKey(p => p.Id);

            // Ví dụ: Thiết lập các thuộc tính cho Product
            modelBuilder.Entity<Product>()
                .Property(p => p.Name)
                .IsRequired();
            modelBuilder.Entity<Cart>()
            .HasKey(ct => ct.Id);

            modelBuilder.Entity<CartItem>()
            .HasKey(sc => sc.Id);



        }
        public DbSet<Product> Products => Set<Product>();
        public DbSet<CartItem> CartItems => Set<CartItem>();
        public DbSet<Cart> Carts => Set<Cart>();


    }
}
