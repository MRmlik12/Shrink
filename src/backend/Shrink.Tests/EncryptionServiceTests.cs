using System;
using Shrink.Models;
using Shrink.Services;
using Xunit;

namespace Shrink.Tests
{
    public class EncryptionServiceTests
    {
        private const string EncryptedUrl = "/MsHbk3KB2TQynpXKtl2LBQXT4BLTS5gQ/BuFFzAm6E=";
        private const string DecryptedUrl = "https://www.google.com/";

        public EncryptionServiceTests()
        {
            Environment.SetEnvironmentVariable("aes_key", "MTIzMTIzMTIzMTIzMjEzMw==");
        }
        
        [Fact]
        public void IsEncrypyionIsValid()
        {
            var result = new EncryptionService().EncryptUrl(new Short()
            {
                Url = DecryptedUrl
            });
            Assert.Equal(EncryptedUrl, result.Url);
        }

        [Fact]
        public void IsDecryptionValid()
        {
            var result = new EncryptionService().DecryptUrl(new Short()
            {
                Url = EncryptedUrl
            });
            Assert.Equal(DecryptedUrl, result.Url);
        }
    }
}