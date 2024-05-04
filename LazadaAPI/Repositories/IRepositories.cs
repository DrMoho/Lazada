using LazadaApi.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace LazadaApi.IRepositories
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllProducts();
        Task<Product> GetProductById(int Id);


    }
    public interface IAccountRepository
    {
        public Task<IdentityResult> SignUpAsync(SignUp signUp);
        public Task<string> SignInAsync(SignIn signIn);


    }

    


}