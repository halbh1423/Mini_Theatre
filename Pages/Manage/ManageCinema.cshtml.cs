using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mini_Theatre.Data;
using Mini_Theatre.Models;

namespace Mini_Theatre.Pages.Manage
{
    public class ManageCinemaModel : PageModel
    {
        private ApplicationDbContext _context;

        public ManageCinemaModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Cinema> Cinemas { get; set; }

        public void OnGet()
        {
            Cinemas = _context.Cinemas
                .ToList();
        }

        public IActionResult OnGetDelete(int id)
        {
            var cinema = _context.Cinemas.Find(id);
            if (cinema == null)
            {
                return NotFound();
            }

            cinema.DeleteTime = DateTime.Now;
            _context.SaveChanges();

            return RedirectToPage("/Manage/ManageCinema");
        }
    }
}
