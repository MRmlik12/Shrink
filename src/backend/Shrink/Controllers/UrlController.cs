using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Shrink.Interfaces;
using Shrink.Models;
using Shrink.Services;

namespace Shrink.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UrlController : Controller
    {
        private readonly IMemoryCache _cache;
        private readonly IShortService _shortService;

        public UrlController(IMemoryCache cache, ShortService shortService)
        {
            _cache = cache;
            _shortService = shortService;
        }

        [HttpGet("{code}")]
        public Task<Short> Get(string code)
        {
            if (!_cache.TryGetValue(code, out Short shortUrl))
            {
                shortUrl = _shortService.Get(shortUrl, code.Trim());
                if (shortUrl.Error == null)
                {
                    var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(30));
                    _cache.Set(shortUrl.Code, shortUrl, cacheEntryOptions);
                }
            }
            
            return Task.FromResult(shortUrl);
        }
        
        [HttpPost]
        [Consumes("application/json")]
        public Task<Short> Create([FromBody]Short shortUrl)
        {
            if (!RegexChecker.IsUrlValid(shortUrl.Url))
            {
                shortUrl.Error = "This URL isn't matched with Regex!";
                return Task.FromResult(shortUrl);
            }

            shortUrl = _shortService.Create(shortUrl);

            return Task.FromResult(shortUrl);
        }
    }
}