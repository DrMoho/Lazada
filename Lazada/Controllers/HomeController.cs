using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Lazada.Models;

namespace Lazada.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private readonly LazadaDbContext _context ;

    public HomeController(ILogger<HomeController> logger , LazadaDbContext context )
    {
        _logger = logger;
        _context = context; 
    }

    public IActionResult Index()
    {
         var products = _context.Products?.ToList();
         // Kiểm tra xem dữ liệu có tồn tại và không null hay không
        if (products != null)
        {
            // In log danh sách sản phẩm
            foreach (var product in products)
            {
                Console.WriteLine($"Product ID: {product.ProductId}, Product Name: {product.ProductName}, Price: {product.Price}, Original Price: {product.OrPrice}");
            }

            return PartialView("~/Views/Home/Index.cshtml", products);
        }
        else
        {
            // Xử lý trường hợp không có dữ liệu hoặc dữ liệu là null
            return PartialView("~/Views/Home/Index.cshtml", new List<Products>());
        }
        
    }

    

    // public IActionResult Products()
    // {
    //     var products = _context.Products?.ToList();

    //     // Kiểm tra xem dữ liệu có tồn tại và không null hay không
    //     if (products != null)
    //     {
    //         // In log danh sách sản phẩm
    //         foreach (var product in products)
    //         {
    //             Console.WriteLine($"Product ID: {product.ProductId}, Product Name: {product.ProductName}, Price: {product.Price}, Original Price: {product.OrPrice}");
    //         }

    //         return PartialView("~/Views/Shared/Components/Products.cshtml", products);
    //     }
    //     else
    //     {
    //         // Xử lý trường hợp không có dữ liệu hoặc dữ liệu là null
    //         return PartialView("~/Views/Shared/Components/Products.cshtml", new List<Products>());
    //     }
    // }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
