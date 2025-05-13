using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Mini_Theatre.Data;
using Mini_Theatre.Models;
using System.Security.Claims;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using Mini_Theatre.Utils;
using System.Text.RegularExpressions;

namespace Mini_Theatre.Pages.Users
{
    [Authorize]
    public class ProfileModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public ProfileModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public User User { get; set; } = default!;

        [BindProperty, AllowNull, DisplayName("Bạn chưa có tài khoản, hãy tạo mới ở đây")]
        public string? UserUsername { get; set; } = "";

        [BindProperty, AllowNull, DisplayName("Mật khẩu mới")]
        public string? UserPassword { get; set; } = default!;

        public List<Order> Orders { get; set; } = new List<Order>();

        public async Task<IActionResult> OnGetAsync()
        {
            var userId = int.Parse(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));

            User = await _context.Users
                .Include(u => u.Orders)
                .FirstOrDefaultAsync(u => u.Id == userId);

            Orders = _context.Orders
                .Include(o => o.Bookings)
                .Where(o => o.UserId == User.Id)
                .ToList();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            // cập nhật tài khoản 
            if (!string.IsNullOrEmpty(UserUsername))
            {
                if (Regex.IsMatch(UserUsername, @"[!@#$%^&*(),.?\\"":{}|<>]"))
                {
                    ModelState.AddModelError($"UserUsername", "Tên đăng nhập không được chứa ký tự đặc biệt.");
                }
                else
                {
                    User.Username = UserUsername;
                    User.HasUsername = true;
                }
            }

            // đổi mật khẩu
            if (!string.IsNullOrEmpty(UserPassword))
            {
                User.HashedPassword = PasswordHasher.HashPassword(UserPassword, User.PasswordSalt);
            }

            // đổi số điện thoại
            if (!string.IsNullOrEmpty(User.PhoneNumber))
            {
                ModelState.AddModelError($"PhoneNumber", "Vui lòng nhập số điện thoại");
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            User.UpdateTime = DateTime.Now;

            _context.Attach(User).State = EntityState.Modified;

            await _context.SaveChangesAsync();
            return RedirectToPage();
        }
    }
}
