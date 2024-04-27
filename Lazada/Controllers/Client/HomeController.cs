using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Lazada.Models.Entities;
using Newtonsoft.Json;

namespace Lazada.Controllers;

public class HomeController : Controller
{

    private readonly ILogger<HomeController> _logger;
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly HttpClient _httpClient;
    public HomeController(ILogger<HomeController> logger, IHttpClientFactory httpClientFactory, HttpClient httpClient)
    {
        _logger = logger;
        _httpClientFactory = httpClientFactory;
        _httpClient = httpClient;
    }

    public async Task<IActionResult> Index()
    {
        try
        {

            var response = await _httpClient.GetAsync("http://localhost:5280/api/Home/GetAllProducts");
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                var responseJson = JsonConvert.DeserializeObject<List<Product>>(responseString);
                return PartialView("~/Views/Client/Home/Index.cshtml", responseJson);
            }
            else
            {
                return BadRequest("Error calling the API.");
            }
        }
        catch (Exception ex)
        {
            return BadRequest(ex);

        }

    }


    public async Task<IActionResult> ProductDetails(int Id)
    {
        try
        {
            var response1 = await _httpClient.GetAsync($"http://localhost:5280/api/Home/GetProductById/{Id}");
            if (response1.IsSuccessStatusCode)
            {
                var response1String = await response1.Content.ReadAsStringAsync();
                var response1Json = JsonConvert.DeserializeObject<Product>(response1String);
                return PartialView("~/Views/Client/Home/ProductDetails.cshtml", response1Json);
            }
            else
            {
                return BadRequest("Error calling the API.");
            }
        }
        catch (Exception ex)
        {
            return BadRequest(ex);

        }

    }

    public IActionResult Login()
    {
        // Trả về trang đăng ký
        return View("~/Areas/Pages/Account/Register.cshtml");
    }


}
