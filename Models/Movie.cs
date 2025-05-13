using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Mini_Theatre.Models
{
    public class Movie : BaseModel
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string Title { get; set; } = string.Empty;

        [StringLength(1000)]
        public string Description { get; set; } = string.Empty;

        [Required, Range(0, int.MaxValue)]
        public int Duration { get; set; }

        [AllowNull]
        public double? Rating { get; set; }

        [Url]
        public string PosterUrl { get; set; } = string.Empty;

        [Url]
        public string TrailerUrl { get; set; } = string.Empty;

        [AllowNull]
        public DateTime? ReleaseDate { get; set; }

        public virtual ICollection<Schedule>? Schedules { get; set; }
        public virtual ICollection<Actor>? Actors { get; set; }
        public virtual ICollection<Director>? Directors { get; set; }
        public virtual ICollection<Genre>? Genres { get; set; }
    }
}
