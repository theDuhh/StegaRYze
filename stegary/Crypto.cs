using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace stegary
{
    class Crypto
    {
        private byte[] IV = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
        private int BlockSize = 128;


        public byte[] EncryptAes(byte[] message,string password)
        {
           // string encryptedMessage = null;
            byte[] bytes = message ;
            //Encrypt
            SymmetricAlgorithm crypt = Aes.Create();
            HashAlgorithm hash = MD5.Create();
            crypt.BlockSize = BlockSize;
            crypt.Key = hash.ComputeHash(Encoding.Unicode.GetBytes(password));
            crypt.IV = IV;

            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (CryptoStream cryptoStream =
                    new CryptoStream(memoryStream, crypt.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cryptoStream.Write(bytes, 0, bytes.Length);
                }

                byte[] encryptedBytes = memoryStream.ToArray();
                //encryptedMessage = Convert.ToBase64String(memoryStream.ToArray());
                return encryptedBytes;
            }
        }

        public byte[] DecryptAes(byte[] secretBytes,string password)
        {
            //Decrypt
            byte[] bytes = secretBytes;
            SymmetricAlgorithm crypt = Aes.Create();
            HashAlgorithm hash = MD5.Create();
            crypt.Key = hash.ComputeHash(Encoding.Unicode.GetBytes(password));
            crypt.IV = IV;

            using (MemoryStream memoryStream = new MemoryStream(bytes))
            {
                using (CryptoStream cryptoStream =
                    new CryptoStream(memoryStream, crypt.CreateDecryptor(), CryptoStreamMode.Read))
                {
                    byte[] decryptedBytes = new byte[bytes.Length];
                    cryptoStream.Read(decryptedBytes, 0, decryptedBytes.Length);
                    return decryptedBytes;
                }
            }
        }

    }
}
