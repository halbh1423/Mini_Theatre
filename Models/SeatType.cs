using System.ComponentModel.DataAnnotations;

namespace Mini_Theatre.Models
{
    public class SeatType
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string Name { get; set; } = string.Empty;

        [Required, Range(0, double.MaxValue)]
        public decimal Price { get; set; }
    }
}
