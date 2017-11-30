using Microsoft.EntityFrameworkCore;

namespace DataAccess.Schema
{
    public class TalasUrlDbContext : DbContext
    {
        /// <summary>建構式</summary>
        /// <param name="options">設定 TalasUrlDbContext 的選項</param>
        public TalasUrlDbContext(DbContextOptions<TalasUrlDbContext> options)
            : base(options)
        {
        }

        public DbSet<ShortUrlSet> ShortUrl { get; set; }
    }
}
