using LazadaApi.Models.Entities;
using Microsoft.AspNetCore.Identity;
using LazadaApi.Models.DTOs;



namespace LazadaApi.IRepositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IConfiguration configuration;
        private readonly LazadaApiDbContext _context; // Sử dụng context để truy vấn cơ sở dữ liệu

        public AccountRepository(UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager, IConfiguration configuration, LazadaApiDbContext context,
        RoleManager<ApplicationRole> roleManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.configuration = configuration;
            _context = context;
            _roleManager = roleManager;

        }

        public async Task<IdentityResult> SignUpAsync(SignUp signUp)
        {
            if (signUp == null || string.IsNullOrEmpty(signUp.Password) || string.IsNullOrEmpty(signUp.Email))
            {
                // Xử lý trường hợp SignUp null hoặc các thuộc tính Email hoặc Password null hoặc trống
                return IdentityResult.Failed(new IdentityError { Description = "Email và Password không được để trống" });
            }
            var user = new ApplicationUser
            {
                UserName = signUp.Email,
                Email = signUp.Email
            };

            // Gọi phương thức CreateUserAsync để tạo người dùng mới
            var result = await userManager.CreateAsync(user, signUp.Password);

            if (result.Succeeded)
            {

                // Kiểm tra và tạo vai trò "User" nếu cần
                if (!await _roleManager.RoleExistsAsync("User"))
                {
                    var roleResult = await _roleManager.CreateAsync(new ApplicationRole { Name = "User" });
                    if (!roleResult.Succeeded)
                    {
                        // Trả về lỗi nếu không thể tạo vai trò
                        return roleResult;
                    }
                }

                // Gán vai trò "User" cho người dùng mới
                var roleAssignResult = await userManager.AddToRoleAsync(user, "User");
                if (!roleAssignResult.Succeeded)
                {
                    // Trả về lỗi nếu không thể gán vai trò
                    return roleAssignResult;
                }
            }

            return result;
        }

        public async Task<(string Message, SignInRepositoryDTO Roles)> SignInAsync(SignIn signIn)
        {
            if (signIn == null || string.IsNullOrEmpty(signIn.Password) || string.IsNullOrEmpty(signIn.Email))
            {
                // Xử lý trường hợp SignIn null hoặc các thuộc tính Email hoặc Password null hoặc trống
                return ("Email và Password không được để trống", null!);
            }

            // Thực hiện đăng nhập sử dụng SignInManager
            var result = await signInManager.PasswordSignInAsync(signIn.Email, signIn.Password, false, lockoutOnFailure: false);

            // Kiểm tra kết quả của quá trình đăng nhập
            if (result.Succeeded)
            {
                var user = await userManager.FindByEmailAsync(signIn.Email);
                var roles = await userManager.GetRolesAsync(user!);
                var rolesDTO = new SignInRepositoryDTO { Name = string.Join(", ", roles) };
                return ("Đăng nhập thành công", rolesDTO);
            }
            else
            {
                // Xử lý trường hợp đăng nhập không thành công (bad request)
                return ("Đăng nhập không thành công", null!);
            }
        }



    }


}