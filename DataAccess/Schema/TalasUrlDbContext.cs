using Microsoft.EntityFrameworkCore;

namespace DataAccess.Schema
{
    public class TalasUrlDbContext : DbContext
    {
        private readonly string _connectionString;

        public TalasUrlDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(_connectionString);
        }

        public DbSet<ShortUrlSet> ShortUrl { get; set; }
    }
}
