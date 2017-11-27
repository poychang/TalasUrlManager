using System;

namespace TalasUrlManager.Models
{
    public class ShortUrlDto
    {
        /// <summary>識別碼</summary>
        public int Id { get; set; }

        /// <summary>短網址</summary>
        public string ShortUrl { get; set; }

        /// <summary>客製名稱</summary>
        public string CustomizeUrl { get; set; }

        /// <summary>原始網址</summary>
        public string OriginalUrl { get; set; }

        /// <summary>建立日期</summary>
        public DateTime CreateDate { get; set; }

        /// <summary>有效日期</summary>
        public DateTime ExpireDate { get; set; }

        /// <summary>點擊次數</summary>
        public int Clicks { get; set; }

        /// <summary>是否啟用</summary>
        public bool IsActive { get; set; }
    }
}
