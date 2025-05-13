using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mini_Theatre.Interfaces; // Đảm bảo bạn đã thêm namespace này

namespace Mini_Theatre.Pages.Authentication
{
    public class VerifyEmailModel : PageModel
    {
        private readonly IUserRepository _userRepository; // Thêm IUserRepository

        public VerifyEmailModel(IUserRepository userRepository)
        {
            _userRepository = userRepository; // Khởi tạo trong constructor
        }

        [BindProperty]
        public string Email { get; set; } = string.Empty; // Khởi tạo giá trị mặc định

        [BindProperty]
        public string VerificationCode { get; set; } = string.Empty;

        public void OnGet(string email)
        {
            Email = email;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (await _userRepository.VerifyEmailAsync(Email, VerificationCode))
            {
                TempData["VerificationSuccess"] = "Xác thực email thành công. Bạn đã có thể đăng nhập.";
                return RedirectToPage("/Authentication/Login");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Mã xác thực không đúng hoặc đã hết hạn.");
                return Page();
            }
        }
    }
}
