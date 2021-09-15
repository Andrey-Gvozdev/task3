using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace task3
{
    static class HMACGenerator
    {
        public static string HMACGenerating(char[] key, string pcMove)
        {
            byte[] bkey = Encoding.Default.GetBytes(key);

            using (var hmac = new HMACSHA256(bkey))
            {
                byte[] bstr = Encoding.Default.GetBytes(pcMove);
                return Convert.ToBase64String(hmac.ComputeHash(bstr));
            }
        }
    }
}
