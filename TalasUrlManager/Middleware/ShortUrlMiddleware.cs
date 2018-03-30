using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace TalasUrlManager.Middleware
{
    /// <summary>短網址中介程序</summary>
    public class ShortUrlMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;

        /// <summary>建構式</summary>
        public ShortUrlMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _configuration = configuration;
        }

        /// <summary>任務呼叫</summary>
        /// <remarks>使用特殊路徑來導向短網址資源</remarks>
        public async Task Invoke(HttpContext context)
        {
            await _next.Invoke(context);

            var prefix = string.IsNullOrEmpty(_configuration["ShortUrlPrefix"]) ? "@" : _configuration["ShortUrlPrefix"];
            var shortUrlId = context.Request.Path.Value.Split(prefix).Last();

            if (context.Request.Path.Value.StartsWith($"/{prefix}"))       // 網址是 /@ 開頭
            {
                context.Request.Path = $"/api/Redirection/{shortUrlId}";    // 將網址改成 API 的轉址功能
                context.Response.StatusCode = 307;                          // 並將 HTTP 狀態碼修改為 307 暫時重新導向

                await _next.Invoke(context);
            }
        }
    }

    /// <summary>短網址中介程序的擴充方法</summary>
    public static class ShortUrlExtensions
    {
        /// <summary>使用短網址的特殊路徑</summary>
        public static IApplicationBuilder UseShortUrlRoute(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ShortUrlMiddleware>();
        }
    }
}
