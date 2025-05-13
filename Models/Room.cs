using System.ComponentModel.DataAnnotations;

namespace Mini_Theatre.Models
{
    public class Room : BaseModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int CinemaId { get; set; }

        [Required, StringLength(50)]
        public string Name { get; set; } = string.Empty;

        [Required, Range(5, 20)]
        public int Row { get; set; }

        [Required, Range(5, 20)]
        public int Col { get; set; }

        public int Capacity => Row * Col;

        [Required, StringLength(50)]
        public string ScreenType { get; set; } = string.Empty;

        public virtual Cinema? Cinema { get; set; }
        public virtual ICollection<Seat>? Seats { get; set; }
    }
}
