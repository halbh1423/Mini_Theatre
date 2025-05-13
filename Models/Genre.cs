using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mini_Theatre.Models
{
    public class Genre : BaseModel
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string Name { get; set; } = string.Empty;

        public virtual ICollection<Movie>? Movies { get; set; }
    }
}
