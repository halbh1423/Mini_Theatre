using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Mini_Theatre.Data;
using Mini_Theatre.Models;

namespace Mini_Theatre.Pages.Bookings
{
    [Authorize]
    public class BookingListModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public BookingListModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public string? ReturnUrl { get; set; }

        public Order Order { get; set; }
        public List<Booking> Tickets { get; set; }

        public IActionResult OnGet(int id, string? returnUrl)
        {
            if(!string.IsNullOrEmpty(returnUrl))
            {
                ReturnUrl = returnUrl;
            }
            else
            {
                ReturnUrl = "/Index";
            }

            Order = _context.Orders
                .Include(o => o.User)
                .Include(o => o.Bookings).ThenInclude(b => b.Schedule).ThenInclude(s => s.Movie).ThenInclude(m => m.Directors)
                .Include(o => o.Bookings).ThenInclude(b => b.Schedule).ThenInclude(s => s.Movie).ThenInclude(m => m.Genres)
                .Include(o => o.Bookings).ThenInclude(b => b.Schedule).ThenInclude(s => s.Room).ThenInclude(r => r.Cinema)
                .Include(o => o.Bookings).ThenInclude(b => b.Seat).ThenInclude(s => s.SeatType)
                .FirstOrDefault(o => o.Id == id);

            Tickets = Order.Bookings.ToList();

            return Page();
        }
    }
}
