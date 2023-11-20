﻿using System.Security.Cryptography;

namespace API.Utilities
{
    public class PasswordHasher
    {
        public static void CreatePasswordHash(string password, out byte[] hash, out byte[] salt)
        {
            using (var hmac = new HMACSHA512())
            {

                salt = hmac.Key;
                hash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public static bool VerifyPasswordHash(string password, byte[] hash, byte[] salt)
        {
            using (var hmac = new HMACSHA512(salt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

                return computedHash.SequenceEqual(hash);
            }
        }
    }
}
