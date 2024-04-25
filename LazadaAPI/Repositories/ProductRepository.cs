using LazadaApi.Models.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace LazadaApi.IRepositories
{
    public class ProductRepository : IRepository
    {
        private readonly LazadaApiDbContext _context; // Sử dụng context để truy vấn cơ sở dữ liệu

        public ProductRepository(LazadaApiDbContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetAllProducts()
        {
            // Thực hiện truy vấn để lấy danh sách tất cả sản phẩm từ cơ sở dữ liệu
            var products = await _context.Products.ToListAsync();
            return products;
        }


        public async Task<Product> GetProductById(int Id)
        {

            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == Id);
            if (product == null)
            {
                throw new Exception("Product not found");
            }
            return product;

        }

      



    }

}