using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TalasUrlManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConfigurationController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public ConfigurationController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // GET: api/Configuration
        [HttpGet]
        public IActionResult Get()
        {
            var prefix = string.IsNullOrEmpty(_configuration["ShortUrlPrefix"]) ? "@" : _configuration["ShortUrlPrefix"];
            var config = new
            {
                ShortUrlBase = $"{Request.Host}/{prefix}"
            };
            return new JsonResult(config);
        }
    }
}
