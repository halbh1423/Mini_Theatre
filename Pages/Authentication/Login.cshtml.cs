using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Mini_Theatre.Data;
using Mini_Theatre.Interfaces;
using Mini_Theatre.Models;
using Mini_Theatre.Utils;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Security.Claims;

namespace Mini_Theatre.Pages.Authentication
{
    public class LoginModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public LoginModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public string Username { get; set; } = default!;

        [BindProperty, DataType(DataType.Password)]
        public string Password { get; set; } = default!;

        [BindProperty]
        public bool RememberLogin { get; set; }

        [BindProperty]
        public string? ReturnUrl { get; set; } = default!;

        public IActionResult OnGet(string? returnUrl = null)
        {
            ReturnUrl = returnUrl;
            return Page();
        }

        public IActionResult OnGetExternalLogin(string provider)
        {
            var redirectUrl = Url.Page("/Authentication/Login", pageHandler: "ExternalLoginResponse", values: null, protocol: Request.Scheme);
            var properties = new AuthenticationProperties { RedirectUri = redirectUrl };
            return Challenge(properties, provider);
        }

        public async Task<IActionResult> OnGetExternalLoginResponse()
        {
            var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            if (result.Succeeded)
            {
                var emailClaim = result.Principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email);
                var nameClaim = result.Principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name);

                if (emailClaim != null && nameClaim != null)
                {
                    var email = emailClaim.Value;
                    var name = nameClaim.Value;

                    var user = await _context.Users
                        .Include(u => u.Role)
                        .FirstOrDefaultAsync(u => u.Email == email);

                    if (user == null)
                    {
                        string passwordSalt = PasswordHasher.GenerateSalt();
                        string hashedPassword = PasswordHasher.GenerateSalt();

                        user = new User
                        {
                            FullName = name,
                            Email = email,
                            Username = email,
                            HashedPassword = hashedPassword,
                            PasswordSalt = passwordSalt,
                            HasUsername = false,
                            IsEmailVerified = true,
                            RoleId = 4,
                            CreateTime = DateTime.Now,
                        };
                        _context.Users.Add(user);
                        await _context.SaveChangesAsync();
                    }

                    user.Role = _context.Roles.FirstOrDefault(r => r.Id == user.RoleId);

                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                        new Claim(ClaimTypes.Name, user.FullName),
                        new Claim(ClaimTypes.Email, user.Email),
                        new Claim(ClaimTypes.Role, user.Role.Name),
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    var authProperties = new AuthenticationProperties
                    {
                        IsPersistent = true,
                        ExpiresUtc = DateTimeOffset.UtcNow.AddDays(7)
                    };

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

                    if (user.Role.Id == 1) // admin 
                    {
                        return RedirectToPage("/Statistic/Dashboard");
                    }
                    else if (user.Role.Id == 2) // manager
                    {
                        return RedirectToPage("/Manage/ManageSchedule");
                    }
                    else if (user.Role.Id == 3) // staff
                    {
                        return RedirectToPage("/Staff/CheckTicket");
                    }

                    return LocalRedirect(ReturnUrl ?? "/Index");
                }
            }

            return RedirectToPage("/Index");
        }

        public async Task<IActionResult> OnPostAsync(string? returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");

            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _context.Users
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.Username == Username);

            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Tài khoản không tồn tại!");
                return Page();
            }
            else if (!PasswordHasher.VerifyPassword(Password, user.PasswordSalt, user.HashedPassword))
            {
                ModelState.AddModelError(string.Empty, "Mật khẩu không chính xác!");
                return Page();
            }
            else
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.FullName),
                    new Claim(ClaimTypes.Role, user.Role.Name),
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = RememberLogin,
                    ExpiresUtc = RememberLogin ? DateTime.UtcNow.AddDays(7) : DateTime.UtcNow.AddHours(1)
                };

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

                return LocalRedirect(ReturnUrl ?? "/Index");
            }
        }
    }
}
