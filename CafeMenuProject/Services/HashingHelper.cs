using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace CafeMenuProject.Services
{
    public static class HashingHelper
    {
        public static string GenerateSalt()
        {
            var bytes = new byte[24];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(bytes);
            }
            return Convert.ToBase64String(bytes);
        }

        public static string HashPassword(string password, string salt)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password + salt));
                var builder = new StringBuilder();
                foreach (var b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public static void UpdatePasswordWithSalt(User entity)
        {
            if (entity != null)
            {
                entity.SaltPassword = GenerateSalt();
                entity.HashPassword = HashPassword(entity.HashPassword, entity.SaltPassword);
            }
        }
    }
}