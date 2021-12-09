using CryptLib;
using System;
using System.IO;
using System.Linq;

namespace SimpleCrypt
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = "password";

            var dictionary = args.Select(a => a.Split(new[] { '=' }, 2))
                     .GroupBy(a => a[0], a => a.Length == 2 ? a[1] : null)
                     .ToDictionary(g => g.Key, g => g.FirstOrDefault());

            if (dictionary.ContainsKey("password"))
                password = dictionary["password"];
            else
            {
                Console.Write("NOPASSWORD");
                return;
            }

            if (dictionary.ContainsKey("encrypt"))
            {
                string toEncrypt = dictionary["encrypt"];
                string encryptedText = TwoWayAES.SimpleEncryptWithPassword(toEncrypt, password);
                Console.Write(encryptedText);
            }
            else if (dictionary.ContainsKey("decrypt"))
            {
                string toDecrypt = dictionary["decrypt"];
                string decryptedText = TwoWayAES.SimpleDecryptWithPassword(toDecrypt, password);
                Console.Write(decryptedText);
            }



        }
    }
}
