using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CSUSAPP.Common.Helpers
{
    public class PasswordHashingService
    {
        public string HashPassword(string password, string salt)
        {
            // Combine the password and salt
            string passwordWithSalt = password + salt;

            // Create a SHA-256 hash from the combined password and salt
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(passwordWithSalt));

                // Convert the byte array to a hexadecimal string
                StringBuilder builder = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public bool VerifyPassword(string enteredPassword, string storedHash, string salt)
        {
            // Hash the entered password with the same salt
            string enteredPasswordHash = HashPassword(enteredPassword, salt);

            // Compare the hashed password with the stored hash
            return enteredPasswordHash == storedHash;
        }

        public string GenerateSalt()
        {
            // Generate a random salt
            byte[] saltBytes = new byte[16];
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(saltBytes);
            }
            return Convert.ToBase64String(saltBytes);
        }
    }
}
