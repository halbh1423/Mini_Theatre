using System.ComponentModel.DataAnnotations;

namespace Mini_Theatre.Models
{
    public class Schedule : BaseModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int MovieId { get; set; }

        [Required]
        public int RoomId { get; set; }

        [Required]
        public DateTime ShowDate { get; set; }

        [Required]
        public DateTime ShowTime { get; set; }

        [Required]
        public DateTime EndTime { get; set; }

        public virtual Room? Room { get; set; }
        public virtual Movie? Movie { get; set; }
        public virtual ICollection<Booking>? Bookings { get; set; }
    }
}
