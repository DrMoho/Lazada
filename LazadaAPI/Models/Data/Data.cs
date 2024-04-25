using Microsoft.AspNetCore.Identity; // Nếu bạn đang sử dụng ApplicationDbContext từ Identity
using Microsoft.EntityFrameworkCore; // Đảm bảo thêm namespace này

namespace LazadaApi.Models.Entities
{
    public class Data
    {
        public static async Task CreateData(IApplicationBuilder app)
        {
            LazadaApiDbContext context = app.ApplicationServices
                .CreateScope().ServiceProvider
                .GetRequiredService<LazadaApiDbContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                await context.Database.MigrateAsync();
            }
            if (!context.Products.Any())
            {
                context.Products.AddRange
                (
                    new Product
                    {
                        Name = "Laptop Dell XPS 13",
                        Price = 1500.0,
                        OrPrice = 1800.0,
                    },
                    new Product
                    {
                        Name = "Smartphone iPhone 13",
                        Price = 1000.0,
                        OrPrice = 1900.0,
                    },
                    new Product
                    {
                        Name = "TV Samsung QLED 4K",
                        Price = 2000.0,
                        OrPrice = 2600.0,
                    },
                     new Product
                     {
                         Name = "Headphone Predator 15X",
                         Price = 2000.0,
                         OrPrice = 2600.0,
                     }
                );
                await context.SaveChangesAsync();
            }
        }
    }
}
