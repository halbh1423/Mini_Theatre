using System.ComponentModel.DataAnnotations;

namespace Mini_Theatre.Models
{
    public class Cinema : BaseModel
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string Name { get; set; } = string.Empty;

        [Required, StringLength(200)]
        public string Address { get; set; } = string.Empty;

        public virtual ICollection<Room>? Rooms { get; set; }
        public virtual ICollection<Schedule>? Schedules { get; set; }
    }
}
