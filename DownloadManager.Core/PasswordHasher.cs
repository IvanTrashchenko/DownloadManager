using System;
using System.Text;

namespace DownloadManager.Core
{
    public static class PasswordHasher
    {
        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null || string.IsNullOrWhiteSpace(password))
                throw new ArgumentNullException("Password is null or empty");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            if (password == null || string.IsNullOrWhiteSpace(password))
                throw new ArgumentNullException("Password is null or empty");

            if (passwordHash.Length != 64)
                throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");

            if (passwordSalt.Length != 128)
                throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordSalt");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

                if (computedHash.Length != passwordHash.Length)
                    return false;

                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                        return false;
                }
            }

            return true;
        }
	}
}
