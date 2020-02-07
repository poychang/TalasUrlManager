using System;
using DataAccess.Common;
using DataAccess.Database;
using DataAccess.Database.Schema;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TalasUrlManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RedirectionController : ControllerBase
    {
        private readonly IRepository<ShortUrlSet> _repo;

        /// <summary>建構式</summary>
        /// <param name="dbManager">資料庫管理者</param>
        public RedirectionController(IDbManager dbManager)
        {
            _repo = dbManager.Repository<ShortUrlSet>();
        }

        // GET api/Redirection/5
        /// <summary>轉址至原網址</summary>
        /// <param name="cUrl">來源網址</param>
        /// <returns></returns>
        [HttpGet("{cUrl}")]
        public IActionResult Get([FromRoute]string cUrl)
        {
            return RedirectToOriginalUrl(cUrl);
        }

        // POST api/Redirection
        /// <summary>轉址至原網址</summary>
        /// <param name="cUrl">來源網址</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody]string cUrl)
        {
            return RedirectToOriginalUrl(cUrl);
        }

        /// <summary>轉址至原網址</summary>
        /// <param name="cUrl">來源網址</param>
        /// <returns></returns>
        private IActionResult RedirectToOriginalUrl(string cUrl)
        {
            var entity = _repo.Read(p => p.ShortUrl == cUrl || p.CustomizeUrl == cUrl);
            if (!entity.IsActive || DateTime.Now > entity.ExpireDate) return NotFound("資源已失效");

            entity.Clicks += 1;
            _repo.SaveChanges();

            var isValidUri = Uri.TryCreate(entity.OriginalUrl, UriKind.Absolute, out var uriResult)
                             && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
            return isValidUri ? new RedirectResult(uriResult.AbsoluteUri) : new RedirectResult($"http://{entity.OriginalUrl}");
        }
    }
}
