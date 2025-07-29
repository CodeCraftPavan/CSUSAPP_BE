using System.Security.Cryptography;
using System.Text;

namespace CSUSAPP.Common.Helpers
{
    /// <summary>
    /// Represents a service for hashing passwords using SHA-256 with a salt.
    /// </summary>
    public class PasswordHashingService
    {
        /// <summary>
        /// Hashes the password using SHA-256 algorithm with a salt.
        /// </summary>
        /// <param name="password">password.</param>
        /// <param name="salt">salt.</param>
        /// <returns>It returns string.</returns>
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

        /// <summary>
        /// Verifies the entered password against the stored hash and salt.
        /// </summary>
        /// <param name="enteredPassword">enteredPassword.</param>
        /// <param name="storedHash">storedHash.</param>
        /// <param name="salt">salt.</param>
        /// <returns>It verifies password.</returns>
        public bool VerifyPassword(string enteredPassword, string storedHash, string salt)
        {
            // Hash the entered password with the same salt
            string enteredPasswordHash = this.HashPassword(enteredPassword, salt);

            // Compare the hashed password with the stored hash
            return enteredPasswordHash == storedHash;
        }

        /// <summary>
        /// Generates a random salt for password hashing.
        /// </summary>
        /// <returns>It returns Salt.</returns>
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
