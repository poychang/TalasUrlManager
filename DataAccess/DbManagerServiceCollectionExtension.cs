using DataAccess;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>設定 DbManager 服務的擴展方法</summary>
    public static class DbManagerServiceCollectionExtension
    {
        /// <summary>注入 InMemoryDbManager 服務至指定的 IServiceCollection</summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to add services to.</param>
        /// <param name="setupAction">The middleware configuration options.</param>
        /// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained.</returns>
        public static IServiceCollection AddInMemoryDbManager(this IServiceCollection services, Action<DbManagerOptions> setupAction = null)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (setupAction != null)
            {
                services.Configure(setupAction);
            }

            services.TryAddSingleton<IDbManager, InMemoryDbManager>();

            return services;
        }

        /// <summary>注入 SqliteManager 服務至指定的 IServiceCollection</summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to add services to.</param>
        /// <param name="setupAction">The middleware configuration options.</param>
        /// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained.</returns>
        public static IServiceCollection AddSqliteManager(this IServiceCollection services, Action<DbManagerOptions> setupAction)
        {
            if (services == null || setupAction == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.Configure(setupAction);
            services.TryAddSingleton<IDbManager, SqliteManager>();

            return services;
        }
    }
}
