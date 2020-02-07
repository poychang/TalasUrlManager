using System.Linq;
using DataAccess.Common;
using DataAccess.Database;
using DataAccess.Database.Schema;
using Microsoft.AspNetCore.Mvc;
using Utility;

namespace TalasUrlManager.Controllers
{
    /// <summary>二維條碼圖片控制器</summary>
    [ApiController]
    [Route("api/[controller]")]
    public class QrCodeController : ControllerBase
    {
        private readonly IRepository<ShortUrlSet> _repo;
        private readonly IUtilityService _utility;

        public QrCodeController(IDbManager dbManager, IUtilityService utility)
        {
            _repo = dbManager.Repository<ShortUrlSet>();
            _utility = utility;
        }

        // GET: api/QrCode/123
        /// <summary>產生二維條碼圖片</summary>
        /// <param name="id">識別碼</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult Get([FromRoute]int id)
        {
            const int size = 300;
            var entity = _repo.Read().SingleOrDefault(p => p.Id == id);
            var content = $"{Request.Scheme}://{Request.Host}/api/t/{entity.ShortUrl}";
            var byteData = _utility.GenerateQrCode(size, content);
            return new FileContentResult(byteData, System.Net.Mime.MediaTypeNames.Image.Jpeg);
        }

        // GET: api/QrCode?size=300&content=PoyChang
        /// <summary>產生二維條碼圖片</summary>
        /// <param name="size">圖片尺寸</param>
        /// <param name="content">資訊</param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get(int size, string content)
        {
            var byteData = _utility.GenerateQrCode(size, content);
            return new FileContentResult(byteData, System.Net.Mime.MediaTypeNames.Image.Jpeg);
        }
    }
}
