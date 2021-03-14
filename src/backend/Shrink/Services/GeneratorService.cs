using System;
using System.Linq;
using Shrink.Interfaces;
using Shrink.Models;

namespace Shrink.Services
{
    public class GeneratorService : IGeneratorService
    {
        private const string AllowedChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890";
        private readonly IMongoService _mongoService;
        private readonly Random _random;

        public GeneratorService(MongoService mongoService)
        {
            _mongoService = mongoService;
            _random = new Random();
        }
        
        public bool CheckIfExists(Short register)
        {
            var result = _mongoService.GetByUrl(register.Url);
            if (result == null)
            {
                return false;
            }

            return true;
        }

        private bool IsCodeExistsInDb(string code)
        {
            var result = _mongoService.GetByCode(code);
            if (result == null)
            {
                return false;
            }

            return true;
        }

        public string GenerateCode()
        {
            string code;
            while (true)
            {
                code = new string(Enumerable.Repeat(AllowedChars, 10).Select(s => s[_random.Next(s.Length)])
                    .ToArray());
                if (!IsCodeExistsInDb(code))
                {
                    break;
                }
            }

            return code;
        }
    }
}