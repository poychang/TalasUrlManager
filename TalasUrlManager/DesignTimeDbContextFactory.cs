using System.IO;
using DataAccess.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace TalasUrlManager
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<TalasUrlDbContext>
    {
        public TalasUrlDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var options = new DbContextOptionsBuilder<TalasUrlDbContext>()
                .UseSqlite(configuration["DbManagerOptions:ConnectionString"], b => b.MigrationsAssembly("TalasUrlManager"))
                .Options;

            return new TalasUrlDbContext(options);
        }
    }
}
