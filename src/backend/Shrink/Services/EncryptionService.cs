using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Shrink.Interfaces;
using Shrink.Models;

namespace Shrink.Services
{
    public class EncryptionService : IEncryptionService
    {
        private readonly byte[] _aesKey;

        public EncryptionService()
        {
            _aesKey = Convert.FromBase64String(Environment.GetEnvironmentVariable("aes_key") ?? throw new InvalidOperationException());
        }
        
        public Short EncryptUrl(Short shortUrl)
        {
            using var aes = Aes.Create();
            aes.Key = _aesKey;
            aes.Mode = CipherMode.ECB;
            var cryptoTransform = aes.CreateEncryptor(aes.Key, aes.IV);
            using var memoryStream = new MemoryStream();
            using var cryptoStream = new CryptoStream(memoryStream, cryptoTransform, CryptoStreamMode.Write);
            using (var streamWriter = new StreamWriter(cryptoStream))
            {
                streamWriter.Write(shortUrl.Url);
            }

            var encrypted = memoryStream.ToArray();
            shortUrl.Url = Convert.ToBase64String(encrypted);
            return shortUrl;
        }

        public Short DecryptUrl(Short shortUrl)
        {
            using var aes = Aes.Create();
            aes.Key = _aesKey;
            aes.Mode = CipherMode.ECB;
            var cryptoTransform = aes.CreateDecryptor(aes.Key, aes.IV);
            using var memoryStream = new MemoryStream(Convert.FromBase64String(shortUrl.Url));
            using var cryptoStream = new CryptoStream(memoryStream, cryptoTransform, CryptoStreamMode.Read);
            using var streamReader = new StreamReader(cryptoStream);
            
            shortUrl.Url = streamReader.ReadToEnd();
            return shortUrl;
        }
    }
}