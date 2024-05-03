using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Progile.Application.Abstraction.Token;
using Progile.Infrastructure.Config;
using Progile.Infrastructure.Extensions;
using Progile.Infrastructure.Services;

namespace Progile.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ITokenHandler, TokenHandler>();
            services.AddScoped<ITokenConfig, TokenConfig>(c =>
            {
                var config = configuration.GetBindFromAppSettings<TokenConfig>();
                return config;
            });

            services.AddScoped<IRateLimiterConfig, RateLimiterConfig>(c =>
            {
                var config = configuration.GetBindFromAppSettings<RateLimiterConfig>();
                return config;
            });
        }
    }
}
