using System;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Utility;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>設定工具服務的擴展方法</summary>
    public static class UtilityServiceCollectionExtension
    {
        /// <summary>注入工具服務至指定的 IServiceCollection</summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to add services to.</param>
        /// <param name="setupAction">The middleware configuration options.</param>
        /// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained.</returns>
        public static IServiceCollection AddUtility(this IServiceCollection services, Action<UtilityOptions> setupAction)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (setupAction != null)
            {
                services.Configure(setupAction);
            }

            services.TryAddSingleton<IUtilityService, UtilityService>();

            return services;
        }

        /// <summary>注入工具服務至指定的 IServiceCollection</summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to add services to.</param>
        /// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained.</returns>
        public static IServiceCollection AddUtility(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            return services.AddUtility(setupAction: null);
        }
    }
}
