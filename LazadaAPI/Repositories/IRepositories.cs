using LazadaApi.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace LazadaApi.IRepositories
{
    public interface IRepository
    {
        Task<List<Product>> GetAllProducts();
        Task<Product> GetProductById(int Id);
        

    }

    
}