using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Mini_Theatre.Data;
using Mini_Theatre.Models;
using Mini_Theatre.Interfaces;
using Microsoft.AspNetCore.Identity;
using MimeKit;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Mini_Theatre.Utils;
using System.ComponentModel.DataAnnotations;

namespace Mini_Theatre.Pages.Users
{
    public class RegisterModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public RegisterModel(ApplicationDbContext context, IUserRepository userRepository, IConfiguration configuration)
        {
            _context = context;
            _userRepository = userRepository;
            _configuration = configuration;
        }

        [BindProperty, Required]
        public string FullName { get; set; } = default!;

        [BindProperty, Required, EmailAddress]
        public string Email { get; set; } = default!;

        [BindProperty, Required]
        public string Username { get; set; } = default!;

        [BindProperty, Required, DataType(DataType.Password)]
        public string Password { get; set; } = default!;

        [BindProperty, Required, DataType(DataType.Password)]
        public string RepeatPassword { get; set; } = default!;

        [BindProperty, Required]
        public string PhoneNumber { get; set; } = String.Empty;

        [BindProperty]
        public string? ReturnUrl { get; set; } = default!;

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                foreach (var modelStateEntry in ModelState.Values)
                {
                    foreach (var error in modelStateEntry.Errors)
                    {
                        Console.WriteLine(error.ErrorMessage);
                    }
                }
                return Page();
            }

            if (await _userRepository.GetByEmailAsync(Email) != null)
            {
                ModelState.AddModelError("Email", "Email đã tồn tại.");
                return Page();
            }
            else if (await _userRepository.GetByPhoneNumberAsync(PhoneNumber) != null)
            {
                ModelState.AddModelError("PhoneNumber", "Số điện thoại đã tồn tại.");
                return Page();
            }
            else if (Password != RepeatPassword)
            {
                ModelState.AddModelError("Password", "Mật khẩu không giống nhau");
                return Page();
            }
            else
            {
                try
                {
                    string salt = PasswordHasher.GenerateSalt();

                    var user = new User
                    {
                        FullName = FullName,
                        Email = Email,
                        PhoneNumber = PhoneNumber,
                        Username = Username,
                        PasswordSalt = salt,
                        HashedPassword = PasswordHasher.HashPassword(Password, salt),
                        HasUsername = true,
                        IsEmailVerified = false,
                        RoleId = 4,
                        CreateTime = DateTime.Now,
                    };

                    await _userRepository.AddAsync(user);
                    await _userRepository.SaveChangesAsync();

                    string verificationCode = GenerateVerificationCode();
                    await _userRepository.SaveVerificationCodeAsync(Email, verificationCode);
                    await SendVerificationEmailAsync(Email, verificationCode);

                    TempData["VerificationCode"] = verificationCode;
                    TempData["RegisterSuccess"] = "Vui lòng kiểm tra email để xác thực tài khoản.";
                    return RedirectToPage("/Authentication/VerifyEmail", new { email = Email });
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, $"Đã xảy ra lỗi trong quá trình đăng ký: {ex.Message}");
                    return Page();
                }
            }
        }

        private string GenerateVerificationCode()
        {
            return Guid.NewGuid().ToString().Substring(0, 6);
        }

        private async Task SendVerificationEmailAsync(string email, string verificationCode)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Mini Theatre", _configuration["Authentication:Email:EmailAddress"]));
            message.To.Add(new MailboxAddress("", email));
            message.Subject = "Xác thực email Mini Theatre";
            message.Body = new TextPart("plain")
            {
                Text = $"Mã xác thực của bạn là: {verificationCode}"
            };

            try
            {
                using (var client = new MailKit.Net.Smtp.SmtpClient())
                {
                    await client.ConnectAsync(_configuration["Authentication:Email:SmtpServer"], int.Parse(_configuration["Authentication:Email:SmtpPort"]), MailKit.Security.SecureSocketOptions.StartTls);
                    await client.AuthenticateAsync(_configuration["Authentication:Email:EmailAddress"], _configuration["Authentication:Email:AppPassword"]);
                    await client.SendAsync(message);
                    await client.DisconnectAsync(true);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while sending mail: " + ex.Message);
                throw;
            }
        }
    }
}
