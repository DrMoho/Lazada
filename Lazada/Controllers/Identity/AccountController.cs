using Microsoft.AspNetCore.Mvc;
using Lazada.Models.Entities;
using Newtonsoft.Json;
using System.Text;

namespace Lazada.Controllers;

public class AccountController : Controller
{

    private readonly ILogger<HomeController> _logger;
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly HttpClient _httpClient;
    public AccountController(ILogger<HomeController> logger, IHttpClientFactory httpClientFactory, HttpClient httpClient)
    {
        _logger = logger;
        _httpClientFactory = httpClientFactory;
        _httpClient = httpClient;
    }


    public IActionResult Register()
    {
        // Trả về trang đăng ký
        return View("~/Views/Account/Register.cshtml");
    }

    public async Task<IActionResult> RegisterRequest([FromForm] SignUp signUp)
    {
        try
        {
            // Convert the SignUp object to JSON string
            var json = JsonConvert.SerializeObject(signUp);

            // Create HttpContent from the JSON string
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // Send POST request with the content
            var response = await _httpClient.PostAsync("http://localhost:5280/api/Account/SignUp/SignUp", content);

            // Check if the response is successful
            if (response.IsSuccessStatusCode)
            {
                // Registration successful, redirect to a success page or do something else
                TempData["SuccessMessage"] = "Đăng ký thành công!";
                return View("~/Views/Account/Register.cshtml");
            }
            else
            {
                // Registration failed, handle the error
                var errorMessage = await response.Content.ReadAsStringAsync();
                TempData["ErrorMessage"] = errorMessage;
                return View("~/Views/Account/Register.cshtml");
            }
        }
        catch (Exception ex)
        {
            // Exception occurred, handle it
            return BadRequest(ex);
        }

    }

    public IActionResult Login()
    {
        return View("~/Views/Account/Login.cshtml");

    }

    public async Task<IActionResult> LoginRequest([FromForm] SignIn signIn)
    {
        try
        {

            var json = JsonConvert.SerializeObject(signIn);

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("http://localhost:5280/api/Account/SignIn/SignIn", content);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
        
                TempData["SuccessMessage"] = "Đăng nhập thành công!";
                // Lưu trữ JWT vào local storage
            
                return View("~/Views/Account/Login.cshtml");
            }
            else
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                TempData["ErrorMessage"] = errorMessage;
                return View("~/Views/Account/Login.cshtml");
            }
        }
        catch (Exception ex)
        {
            // Exception occurred, handle it
            return BadRequest(ex);
        }
    }




}
