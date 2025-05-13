using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Mini_Theatre.Data;
using Mini_Theatre.Models;

namespace Mini_Theatre.Pages.Manage
{
    public class ManageRoomModel : PageModel
    {
        private ApplicationDbContext _context;

        public ManageRoomModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Room> Rooms { get; set; }

        public void OnGet()
        {
            Rooms = _context.Rooms
                .Include(r => r.Cinema)
                .ToList();
        }

        public IActionResult OnGetDelete(int id)
        {
            var room = _context.Rooms.Find(id);
            if (room== null)
            {
                return NotFound();
            }

            room.DeleteTime = DateTime.Now;
            _context.SaveChanges();

            return RedirectToPage("/Manage/ManageRoom");
        }
    }
}
