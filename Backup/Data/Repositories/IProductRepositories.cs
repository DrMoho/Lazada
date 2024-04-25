using Lazada.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Lazada.IProductRepositories
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllProductsAsync();

    }

    public class ProductRepository : IProductRepository
    {
        private readonly LazadaDbContext _context; // Sử dụng context để truy vấn cơ sở dữ liệu

        public ProductRepository(LazadaDbContext context)
        {
            _context = context;
        }
        
        public async Task<List<Product>> GetAllProductsAsync()
        {
            // Thực hiện truy vấn để lấy danh sách tất cả sản phẩm từ cơ sở dữ liệu
            var products = await _context.Products.ToListAsync();
            return products;
        }


    }
}