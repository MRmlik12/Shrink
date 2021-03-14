using Shrink.Interfaces;
using Shrink.Models;

namespace Shrink.Services
{
    public class ShortService : IShortService
    {
        private readonly IGeneratorService _generatorService;
        private readonly IMongoService _mongoService;
        private readonly IEncryptionService _encryptionService;
        
        public ShortService(GeneratorService generatorService, MongoService mongoService, EncryptionService encryptionService)
        {
            _generatorService = generatorService;
            _mongoService = mongoService;
            _encryptionService = encryptionService;
        }
        
        public Short Create(Short shortUrl)
        {
            var result = _generatorService.CheckIfExists(_encryptionService.EncryptUrl(shortUrl));
            if (!result)
            {
                shortUrl.Code = _generatorService.GenerateCode();
                _mongoService.Create(shortUrl);
                return shortUrl;
            }
            shortUrl = _mongoService.GetByUrl(shortUrl.Url);
            shortUrl.Url = null;
            return shortUrl;

        }

        public Short Get(Short shortUrl, string code)
        {
            shortUrl = _mongoService.GetByCode(code);
            if (shortUrl == null)
            {
                return new Short
                {
                    Error = "Couldn't get url with this code"
                };
            }

            shortUrl = _encryptionService.DecryptUrl(shortUrl);
            return shortUrl;
        }
    }
}