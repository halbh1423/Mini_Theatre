using Mini_Theatre.Models;

namespace Mini_Theatre.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User?> GetByUsernameAsync(string username);
        Task<User?> GetByEmailAsync(string email);
        Task<User> FindByUsernameAsync(string username);
        Task<User?> GetByPhoneNumberAsync(string phoneNumber);
        Task SaveVerificationCodeAsync(string email, string verificationCode);
        Task<bool> VerifyEmailAsync(string email, string verificationCode);
    }
}
