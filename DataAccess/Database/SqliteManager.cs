using DataAccess.Database.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace DataAccess.Database
{
    /// <summary>SQLite 資料庫管理者</summary>
    /// <remarks>REF: 實現標準 Dispose 模式 ( https://dotblogs.com.tw/larrynung/2011/03/10/21774 )</remarks>
    public class SqliteManager : DbManager
    {
        /// <summary>建構式</summary>
        /// <param name="optionsAccessor"></param>
        public SqliteManager(IOptions<DbManagerOptions> optionsAccessor) : base(optionsAccessor) { }

        /// <summary>使用 SQLite 資料庫</summary>
        protected override void UseDbContext()
        {
            var contextOptions = new DbContextOptionsBuilder<ProjectDbContext>()
                .UseSqlite(OptionsAccessor.Value.ConnectionString)
                .Options;
            Context = new ProjectDbContext(contextOptions);
        }
    }
}
