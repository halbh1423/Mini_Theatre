using System.Diagnostics.CodeAnalysis;

namespace Mini_Theatre.Models
{
    public class BaseModel
    {
        [AllowNull]
        public bool? IsActive { get; set; }

        [AllowNull]
        public DateTime? CreateTime { get; set; }
        
        [AllowNull]
        public DateTime? UpdateTime { get; set; }
        
        [AllowNull]
        public DateTime? DeleteTime { get; set; }
    }
}
