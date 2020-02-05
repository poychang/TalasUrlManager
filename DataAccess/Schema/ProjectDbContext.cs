using Microsoft.EntityFrameworkCore;

namespace DataAccess.Schema
{
    public class ProjectDbContext : DbContext
    {
        /// <summary>建構式</summary>
        /// <param name="options">設定 TalasUrlDbContext 的選項</param>
        public ProjectDbContext(DbContextOptions<ProjectDbContext> options)
            : base(options)
        {
        }

        /// <summary>ShortUrl 資料集</summary>
        public DbSet<ShortUrlSet> ShortUrl { get; set; }
    }
}
