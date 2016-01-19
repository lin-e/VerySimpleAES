using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
namespace VerySimpleAES
{
    public class SimpleAES
    {
        string encryptionKey;
        public SimpleAES(string inputKey)
        {
            encryptionKey = inputKey;
        }
        public string Encrypt(string inputString)
        {
            byte[] clearBytes = Encoding.Unicode.GetBytes(inputString);
            using (Aes aesEncryptor = Aes.Create())
            {
                Rfc2898DeriveBytes keyDerivation = new
                    Rfc2898DeriveBytes(encryptionKey, new byte[]
                    { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                aesEncryptor.Key = keyDerivation.GetBytes(32);
                aesEncryptor.IV = keyDerivation.GetBytes(16);
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, aesEncryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(clearBytes, 0, clearBytes.Length);
                        cryptoStream.Close();
                    }
                    inputString = Convert.ToBase64String(memoryStream.ToArray());
                }
            }
            return inputString;
        }
        public string Decrypt(string inputString)
        {
            byte[] cipherBytes = Convert.FromBase64String(inputString);
            using (Aes aesEncryptor = Aes.Create())
            {
                Rfc2898DeriveBytes keyDerivation = new
                    Rfc2898DeriveBytes(encryptionKey, new byte[]
                    { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                aesEncryptor.Key = keyDerivation.GetBytes(32);
                aesEncryptor.IV = keyDerivation.GetBytes(16);
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, aesEncryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(cipherBytes, 0, cipherBytes.Length);
                        cryptoStream.Close();
                    }
                    inputString = Encoding.Unicode.GetString(memoryStream.ToArray());
                }
            }
            return inputString;
        }
    }
}
