using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Mini_Theatre.Data;
using Mini_Theatre.Models;
using System.Security.Claims;

namespace Mini_Theatre.Pages.Bookings
{
    [Authorize]
    public class BookSeatModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public BookSeatModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int scheduleId, string seatIds, string? paymentMethod, string? paymentStatus)
        {
            // create order, return orderId
            decimal totalPrice = 0;
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            Order order = new Order
            {
                UserId = userId,
                PaymentMethod = paymentMethod??"Paypal",
                PaymentStatus = paymentStatus??"Paid",
                TotalPrice = 0,
                OrderTime = DateTime.Now,
                CreateTime = DateTime.Now,
            };

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            // create booking with orderId
            List<Booking> bookings = new List<Booking>();

            foreach(var item in seatIds.Trim().Split(' '))
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
            await _context.SaveChangesAsync();

            return RedirectToPage("/ThankYou");
        }
    }
}
