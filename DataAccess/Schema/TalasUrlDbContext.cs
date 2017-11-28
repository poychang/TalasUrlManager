using Microsoft.EntityFrameworkCore;

namespace DataAccess.Schema
{
    public class TalasUrlDbContext : DbContext
    {
        /// <summary>資料庫連線字串</summary>
        private readonly string _connectionString;

        /// <summary>建構式</summary>
        public TalasUrlDbContext()
        {
            // 執行 EF Core Migrations 時所需要的連線字串，預設使用 SQLite
            _connectionString = "Data Source=Database\\TalasUrl.db;";
        }

        /// <summary>建構式</summary>
        /// <param name="connectionString">資料庫連線字串</param>
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
