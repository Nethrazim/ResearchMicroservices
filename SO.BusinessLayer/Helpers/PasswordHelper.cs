using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace SO.BusinessLayer.Helpers
{
    public static class PasswordHelper
    {
        public static string GeneratePassword(string password, string salt)
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            byte[] saltBytes = Encoding.UTF8.GetBytes(salt);

            HashAlgorithm algorithm = new SHA256Managed();
            byte[] passwordAndSaltBytes = new byte[passwordBytes.Length + saltBytes.Length];
            for (int i = 0; i < passwordBytes.Length; i++)
            {
                passwordAndSaltBytes[i] = passwordBytes[i];
            }
            for (int i = 0; i < saltBytes.Length; i++)
            {
                passwordAndSaltBytes[passwordBytes.Length + i] = saltBytes[i];
            }

            return System.Text.Encoding.UTF8.GetString(algorithm.ComputeHash(passwordAndSaltBytes));
        }

        public static string GenerateSalt()
        {
            Random random = new Random();
            StringBuilder saltBuilder = new StringBuilder();
            char[] allowedChars = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz0123456789!@$?_-".ToCharArray();
            for (int i = 0; i < 12; i++)
            {
                saltBuilder.Append(allowedChars[random.Next(56)]);
            }
            return saltBuilder.ToString();
        }
    }
}
