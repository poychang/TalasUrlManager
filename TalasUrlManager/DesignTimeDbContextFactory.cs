using System.IO;
using DataAccess.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace TalasUrlManager
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ProjectDbContext>
    {
        public ProjectDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var options = new DbContextOptionsBuilder<ProjectDbContext>()
                .UseSqlite(configuration["DbManagerOptions:ConnectionString"], b => b.MigrationsAssembly("TalasUrlManager"))
                .Options;

            return new ProjectDbContext(options);
        }
    }
}
