using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LazadaApi.Models.Entities;
using LazadaApi.IRepositories;

namespace LazadaApi.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private readonly IRepository _productRepository;

    public HomeController(ILogger<HomeController> logger, IRepository productRepository)
    {
        _logger = logger;
        _productRepository = productRepository;
    }

    [HttpGet]
    public async Task<ActionResult<List<Product>>> GetAllProducts()
    {
        return await _productRepository.GetAllProducts();
    }

    [HttpGet("{Id}")]
    public async Task<ActionResult<Product>> GetProductById(int Id)
    {
        try
        {
            var product = await _productRepository.GetProductById(Id);           
            return product;
        }
        catch (Exception ex)
        {
            return BadRequest("Error exception :"+ ex ); 
        }
    }




}
