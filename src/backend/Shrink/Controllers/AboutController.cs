using System.Globalization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shrink.Models;

namespace Shrink.Controllers
{
    [ApiController]
    [Route("/")]
    public class AboutController : Controller
    {
        private readonly About _about;
        
        public AboutController()
        {
            _about = new About
            {
                Version = "v1.0"
            };
        }
        
        [HttpGet]
        public Task<About> Get()
        {
            return Task.FromResult(_about);
        }
    }
}