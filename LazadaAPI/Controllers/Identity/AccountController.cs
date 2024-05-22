using Microsoft.AspNetCore.Mvc;
using LazadaApi.Models.Entities;
using LazadaApi.IRepositories;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;
using LazadaApi.Models.DTOs;

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
            if (result.Message == "Đăng nhập thành công")
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes("YourSecretKeyHere123456789@demo!");

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, signIn.Email!)
                };

                // Thêm các vai trò của người dùng vào danh sách các claim
                if (result.Roles != null)
                {
                    // Access roles from the SignInRepositoryDTO object
                    var roles = result.Roles.Name;

                    // Split roles into an array
                    var roleArray = roles!.Split(", ");

                    // Add each role as a claim
                    foreach (var role in roleArray)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, role));
                    }
                }

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new ClaimsIdentity(claims)),
                    Expires = DateTime.UtcNow.AddHours(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                var tokenString = tokenHandler.WriteToken(token);


                return Ok(tokenString);
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
