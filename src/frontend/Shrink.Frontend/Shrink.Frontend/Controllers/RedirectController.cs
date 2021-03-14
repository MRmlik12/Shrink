using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Shrink.Frontend.Api;

namespace Shrink.Frontend.Controllers
{
    [ApiController]
    [Route("/")]
    public class RedirectController : Controller
    {
        private readonly string _apiUrl;
        private readonly IConfiguration _configuration;

        public RedirectController(IConfiguration configuration)
        {
            _apiUrl = Environment.GetEnvironmentVariable("API_URL");
            _configuration = configuration;
        }
        
        [HttpGet("{code}")]
        public async Task<ActionResult> Get(string code)
        {
            var response = await GetUrl.GetUrlByCode(_apiUrl, code);

            if (response.Error == null)
            {
                return Redirect(response.Url);
            }

            return Redirect("/");
        }
    }
}