using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Mini_Theatre.Models
{
    public class User : BaseModel
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string FullName { get; set; } = String.Empty;

        [Required, EmailAddress]
        public string Email { get; set; } = String.Empty;
        
        [Required, StringLength(50)]
        public string Username { get; set; } = String.Empty;

        [Required]
        [MaxLength(int.MaxValue)]
        public string HashedPassword { get; set; } = String.Empty;

        [Required]
        [MaxLength(32)]
        public string PasswordSalt { get; set; } = String.Empty;

        [AllowNull]
        public string? PhoneNumber { get; set; } = String.Empty;

        [Required]
        public int RoleId { get; set; }

        [Required]
        public bool HasUsername { get; set; } = false;

        [AllowNull]
        public bool IsEmailVerified { get; set; } = false;

        [AllowNull]
        public string? VerificationCode { get; set; }

        [AllowNull]
        public DateTime? VerificationCodeExpiration { get; set; }

        public virtual Role? Role { get; set; }
        public virtual ICollection<Booking>? Bookings { get; set; }
        public virtual ICollection<Order>? Orders { get; set; }
    }
}
