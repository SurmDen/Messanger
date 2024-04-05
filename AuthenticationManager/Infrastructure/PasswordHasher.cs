using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace AuthenticationManager.Infrastructure
{
    public class PasswordHasher
    {
        public static string GenerateHash(string password)
        {
            SHA256 algoritm = SHA256.Create();

            byte[] bytes = algoritm.ComputeHash(Encoding.UTF8.GetBytes(password));

            StringBuilder builder = new StringBuilder();

            foreach (byte b in bytes)
            {
                builder.Append(b.ToString("X2"));
            }

            return builder.ToString();
        }
    }
}
