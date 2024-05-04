using Microsoft.AspNetCore.Mvc;
using LazadaApi.Models.Entities;
using LazadaApi.IRepositories;
using Microsoft.AspNetCore.Identity;

namespace LazadaApi.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class AccountController : Controller
{
    private readonly IAccountRepository accountRepository;
    public AccountController(IAccountRepository accountRepository)
    {
        this.accountRepository = accountRepository;
    }

    [HttpPost("SignUp")]
    public async Task<IActionResult> SignUpAsync(SignUp signUp)
    {
        try
        {
            var result = await accountRepository.SignUpAsync(signUp);
            if (result.Succeeded)
            {
                return Ok(result.Succeeded);
            }
            else
            {
                var errors = string.Join("; ", result.Errors.Select(e => e.Description));
                return BadRequest($"Đăng ký không thành công: {errors}");
            }
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Đã xảy ra lỗi: {ex.Message}");
        }
    }
    [HttpPost("SignIn")]
    public async Task<IActionResult> SignInAsync(SignIn signIn)
    {
        try
        {
            var result = await accountRepository.SignInAsync(signIn);
            if (result == "Đăng nhập thành công")
            {
                return Ok("Đăng nhập thành công");
            }
            else
            {
                return BadRequest(result);
            }
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Đã xảy ra lỗi: {ex.Message}");
        }
    }




}
