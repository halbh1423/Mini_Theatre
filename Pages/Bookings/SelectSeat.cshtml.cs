using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Mini_Theatre.Data;
using Mini_Theatre.Models;

namespace Mini_Theatre.Pages.Bookings
{
    [Authorize]
    public class SelectSeatModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public SelectSeatModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public Schedule Schedule { get; set; }
        public Room Room { get; set; }
        public Movie Movie { get; set; }
        public List<Seat> Seats { get; set; }
        public List<SeatType> SeatTypes { get; set; }
        public List<Booking> Bookings { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Schedule = await _context.Schedules
                .Include(s => s.Room).ThenInclude(r => r.Cinema)
                .Include(s => s.Movie).ThenInclude(m => m.Genres)
                .Include(s => s.Movie).ThenInclude(m => m.Actors)
                .Include(s => s.Movie).ThenInclude(m => m.Directors)
                .Include(s => s.Bookings).ThenInclude(b => b.Seat)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (Schedule == null)
            {
                return NotFound();
            }

            Movie = Schedule.Movie;
            Room = Schedule.Room;

            Seats = await _context.Seats
                .Include(s => s.SeatType)
                .Where(seat => seat.RoomId == Room.Id)
                .ToListAsync();

            SeatTypes = await _context.SeatTypes
                .ToListAsync();

            Bookings = Schedule.Bookings.ToList();

            return Page();
        }
    }
}
