using DataAccess.Database.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace DataAccess.Database
{
    /// <summary>InMemoryDb 資料庫管理者</summary>
    public class InMemoryDbManager : DbManager
    {
        /// <summary>建構式</summary>
        /// <param name="optionsAccessor"></param>
        public InMemoryDbManager(IOptions<DbManagerOptions> optionsAccessor) : base(optionsAccessor) { }

        /// <summary>使用 InMemoryDb 資料庫</summary>
        protected override void UseDbContext()
        {
            var contextOptions = new DbContextOptionsBuilder<ProjectDbContext>()
                .UseInMemoryDatabase(databaseName: "MyDatabase")
                .Options;
            Context = new ProjectDbContext(contextOptions);
        }
    }
}
