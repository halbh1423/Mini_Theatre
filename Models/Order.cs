using System.ComponentModel.DataAnnotations;

namespace Mini_Theatre.Models
{
    public class Order : BaseModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required, Range(0, double.MaxValue)]
        public decimal TotalPrice { get; set; }

        [Required, StringLength(50)]
        public string PaymentMethod { get; set; } = string.Empty;

        [Required, StringLength(50)]
        public string PaymentStatus { get; set; } = string.Empty;

        [Required]
        public DateTime OrderTime { get; set; }

        public virtual User? User { get; set; }
        public virtual ICollection<Booking>? Bookings { get; set; }
    }
}
