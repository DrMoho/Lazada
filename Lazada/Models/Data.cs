using Microsoft.AspNetCore.Identity; // Nếu bạn đang sử dụng ApplicationDbContext từ Identity
using Microsoft.EntityFrameworkCore; // Đảm bảo thêm namespace này

namespace Lazada.Models
{
    public class Data
    {
        public static async Task CreateData(IApplicationBuilder app)
        {
             LazadaDbContext context = app.ApplicationServices
                 .CreateScope().ServiceProvider
                 .GetRequiredService<LazadaDbContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                await context.Database.MigrateAsync();
            }
            if (!context.Products.Any())
            {
                context.Products.AddRange
                (
                    new Products
                    {
                        ProductName = "Laptop Dell XPS 13",
                        Price = 1500.0,
                        OrPrice = 1800.0,
                    },
                    new Products
                    {
                        ProductName = "Smartphone iPhone 13",
                        Price = 1000.0,
                        OrPrice = 1900.0,
                    },
                    new Products
                    {
                        ProductName = "TV Samsung QLED 4K",
                        Price = 2000.0,
                        OrPrice = 2600.0,
                    }
                );
                await context.SaveChangesAsync();
            }
        }
    }
}
