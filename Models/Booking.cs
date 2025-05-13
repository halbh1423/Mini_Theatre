using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Mini_Theatre.Models
{
    public class Booking : BaseModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int OrderId { get; set; }

        [Required]
        public int ScheduleId { get; set; }

        [Required]
        public int SeatId { get; set; }

        [Required, Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        [AllowNull, Range(0, 100)]
        public decimal? DiscountPercentage { get; set; } = 0;

        public virtual Order? Order { get; set; }
        public virtual Schedule? Schedule { get; set; }
        public virtual Seat? Seat { get; set; }
    }
}
