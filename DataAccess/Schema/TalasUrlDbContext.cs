using Microsoft.EntityFrameworkCore;

namespace DataAccess.Schema
{
    public class TalasUrlDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Database\\TalasUrl.db;");
        }

        public DbSet<ShortUrlSet> ShortUrl { get; set; }
    }
}
