using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Mini_Theatre.Data;
using Mini_Theatre.Models;
using System.Security.Claims;

namespace Mini_Theatre.Pages.Bookings
{
    [Authorize]
    public class CheckoutModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CheckoutModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public Movie Movie { get; set; }
        public Room Room { get; set; }
        public Schedule Schedule { get; set; }
        public List<Seat> Seats { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal TotalPriceUSD { get; set; }

        public async Task<IActionResult> OnGetAsync(int scheduleId, string seatIds)
        {
            ViewData["scheduleId"] = scheduleId;
            ViewData["seatIds"] = seatIds;

            Schedule = await _context.Schedules
                .Include(s => s.Movie)
                .Include(s => s.Room).ThenInclude(r => r.Cinema)
                .FirstOrDefaultAsync(s => s.Id == scheduleId);

            var seatIdList = seatIds.Split(' ').Select(int.Parse).ToList();
            Seats = await _context.Seats
                .Include(s => s.SeatType)
                .Where(s => seatIdList.Contains(s.Id))
                .ToListAsync();

            TotalPrice = Seats.Sum(s => s.SeatType.Price);
            TotalPriceUSD = Math.Round(TotalPrice / 23000, 2);

            return Page();
        }

        public IActionResult OnGetCompleteCheckout(int scheduleId, string seatIds, string? paymentMethod, string? paymentStatus)
        {
            ViewData["scheduleId"] = scheduleId;
            ViewData["seatIds"] = seatIds;

            // create order, return orderId
            decimal totalPrice = 0;
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            Order order = new Order
            {
                UserId = userId,
                PaymentMethod = paymentMethod ?? "Paypal",
                PaymentStatus = paymentStatus ?? "Unpaid",
                TotalPrice = 0,
                OrderTime = DateTime.Now,
                CreateTime = DateTime.Now,
            };

            _context.Orders.Add(order);
            _context.SaveChanges();

            // create booking with orderId
            List<Booking> bookings = new List<Booking>();

            foreach (var item in seatIds.Trim().Split(' '))
            {
                int seatId = int.Parse(item);
                var price = _context.Seats
                        .Include(s => s.SeatType)
                        .FirstOrDefault(s => s.Id == seatId)
                        .SeatType.Price;

                // update order total price
                order.TotalPrice += price;

                _context.Bookings.Add(new Booking
                {
                    OrderId = order.Id,
                    ScheduleId = scheduleId,
                    SeatId = seatId,
                    Price = price,
                    DiscountPercentage = 0,
                    CreateTime = DateTime.Now,
                });
            }

            // update order new price
            _context.Orders.Update(order);
            _context.SaveChanges();

            return RedirectToPage("/Index");
        }
    }
}
