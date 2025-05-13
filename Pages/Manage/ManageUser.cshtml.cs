using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Mini_Theatre.Data;
using Mini_Theatre.Models;

namespace Mini_Theatre.Pages.Manage
{
    public class ManageUserModel : PageModel
    {
        private ApplicationDbContext _context;

        public ManageUserModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<User> Users { get; set; }

        public void OnGet()
        {
            Users = _context.Users
                .Include(u => u.Role)
                .ToList();
        }

        public IActionResult OnGetDelete(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            user.DeleteTime = DateTime.Now;
            _context.SaveChanges();

            return RedirectToPage("/Manage/ManageUser");
        }
    }
}
