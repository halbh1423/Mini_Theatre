using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Mini_Theatre.Data;
using Mini_Theatre.Models;

namespace Mini_Theatre.Pages.Manage
{
    public class ScheduleModel : PageModel
    {
        private ApplicationDbContext _context;

        public ScheduleModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Schedule> Schedules { get; set; }

        public void OnGet()
        {
            Schedules = _context.Schedules
                .Include(s => s.Bookings)
                .Include(s => s.Movie)
                .Include(s => s.Room).ThenInclude(r => r.Cinema)
                .ToList();
        }

        public IActionResult OnGetDelete(int id)
        {
            var schedule = _context.Schedules
                .Include(s => s.Bookings)
                .FirstOrDefault(s => s.Id == id);

            if (schedule == null)
            {
                return NotFound();
            }

            schedule.Bookings.Clear();

            _context.Schedules.Remove(schedule);
            _context.SaveChanges();

            return RedirectToPage("/Manage/ManageSchedule");
        }
    }
}
