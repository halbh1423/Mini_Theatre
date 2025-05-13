using System.ComponentModel.DataAnnotations;

namespace Mini_Theatre.Models
{
    public class Seat : BaseModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int RoomId { get; set; }

        [Required, StringLength(50)]
        public string Name { get; set; } = string.Empty;

        [Required]
        public int SeatTypeId { get; set; }

        public virtual SeatType? SeatType { get; set; }
        public virtual Room? Room { get; set; }
        public virtual ICollection<Booking>? Bookings { get; set; }
    }
}
