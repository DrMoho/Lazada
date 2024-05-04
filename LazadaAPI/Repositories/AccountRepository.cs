using LazadaApi.Models.Entities;
using Microsoft.AspNetCore.Identity;


namespace LazadaApi.IRepositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IConfiguration configuration;
        public AccountRepository(UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.configuration = configuration;

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

            return result;
        }

        public async Task<string> SignInAsync(SignIn signIn)
        {
            if (signIn == null || string.IsNullOrEmpty(signIn.Password) || string.IsNullOrEmpty(signIn.Email))
            {
                // Xử lý trường hợp SignIn null hoặc các thuộc tính Email hoặc Password null hoặc trống
                return "Email và Password không được để trống";
            }

            // Thực hiện đăng nhập sử dụng SignInManager
            var result = await signInManager.PasswordSignInAsync(signIn.Email, signIn.Password, false, lockoutOnFailure: false);

            // Kiểm tra kết quả của quá trình đăng nhập
            if (result.Succeeded)
            {
                return "Đăng nhập thành công";
            }
            if (result.RequiresTwoFactor)
            {
                return "Yêu cầu xác thực hai yếu tố";
            }
            if (result.IsLockedOut)
            {
                return "Tài khoản đã bị khóa";
            }
            else
            {
                return "Đăng nhập không thành công";
            }
        }


    }


}