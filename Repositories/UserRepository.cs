using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Mini_Theatre.Data;
using Mini_Theatre.Interfaces;
using Mini_Theatre.Models;

namespace Mini_Theatre.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<User?> GetByUsernameAsync(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
        public async Task<User> FindByUsernameAsync(string username)
        {
           return await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
        }

        public async Task<User?> GetByPhoneNumberAsync(string phoneNumber)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.PhoneNumber == phoneNumber);
        }

        public async Task SaveVerificationCodeAsync(string email, string verificationCode)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (user == null) return; 

            user.VerificationCode = verificationCode;
            user.VerificationCodeExpiration = DateTime.UtcNow.AddMinutes(5); 

            await _context.SaveChangesAsync();
        }

        public async Task<bool> VerifyEmailAsync(string email, string verificationCode)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (user == null) return false; // Không tìm thấy người dùng

            if (user.VerificationCode == verificationCode && user.VerificationCodeExpiration > DateTime.UtcNow)
            {
                user.IsEmailVerified = true;
                user.VerificationCode = null;
                user.VerificationCodeExpiration = null;

                await _context.SaveChangesAsync();
                return true; 
            }

            return false; 
        }
    }
}
