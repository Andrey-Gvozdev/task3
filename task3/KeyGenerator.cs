using System;
using System.Security.Cryptography;

namespace task3
{
    class KeyGenerator
    {
        public char[] keyLoc = new char[64];

        public KeyGenerator()
        {
            keyLoc = KeyGenerating();
        }

        private char[] KeyGenerating()
        {
            char[] key = new char[64]; 
            int a;
            
            for (int i = 0; i < key.Length; i++)
            {
                a = RNGCryptoServiceProvider.GetInt32(48, 91);
                if (a > 56 & a < 65)
                    a += RNGCryptoServiceProvider.GetInt32(8, 27);
                key[i] = Convert.ToChar(a);
            }

            return key;
        }

        public void PrintingKey(char[] key)
        {
            Console.Write("HMAC key: ");
            for (int i = 0; i < key.Length; i++)
                Console.Write(key[i]);
            Console.WriteLine();
        }

    }
}
