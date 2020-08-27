using System;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace Helper
{
    public static class Validation
    {
        public static bool IsEmail(string email)
        {
            string expresion = @"^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$";
            Regex automata = new Regex(expresion);
            return automata.IsMatch(email);
        }
        
        public static string GenerateHash(string password)
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100000);
            byte[] hash = pbkdf2.GetBytes(20);
            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);
            return Convert.ToBase64String(hashBytes);
        }

        public static bool VerifyPassword(string password_hash, string password)
        {
            try
            {
                byte[] hashBytes = Convert.FromBase64String(password_hash);
                byte[] salt = new byte[16];
                Array.Copy(hashBytes, 0, salt, 0, 16);
                var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100000);
                byte[] hash = pbkdf2.GetBytes(20);
                for (int i = 0; i < 20; i++)
                    if (hashBytes[i + 16] != hash[i])
                        return false;
                return true;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return false;
            }

        }
    }
}
