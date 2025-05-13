using System;
using System.Text;
using System.Security.Cryptography;

namespace Mini_Theatre.Utils
{
    public class PasswordHasher
    {
        public static string GenerateSalt()
        {
            byte[] saltBytes = new byte[16];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(saltBytes);
            }
            return Convert.ToBase64String(saltBytes);
        }

        public static string HashPassword(string password, string salt)
        {
            using (var sha256 = SHA256.Create())
            {
                var saltedPassword = salt + password;
                byte[] saltedPasswordBytes = Encoding.UTF8.GetBytes(saltedPassword);
                byte[] hashBytes = sha256.ComputeHash(saltedPasswordBytes);
                return Convert.ToBase64String(hashBytes);
            }
        }

        public static bool VerifyPassword(string password, string salt, string hash)
        {
            var hashOfInput = HashPassword(password, salt);
            Console.WriteLine(hashOfInput);
            Console.WriteLine(hash);

            return hash == hashOfInput;
        }
    }
}
