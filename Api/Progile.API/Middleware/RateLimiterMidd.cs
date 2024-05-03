using System.Threading.RateLimiting;
using Microsoft.AspNetCore.RateLimiting;
using Progile.Application.Abstraction.Token;

namespace Progile.API.Middleware
{
    public static class RateLimiterMidd
    {

        public static void AddRateLimitMidd(this IServiceCollection services, IConfiguration configuration)
        {
            using ServiceProvider serviceProvider = services.BuildServiceProvider();

            var rateLimiterConfig = serviceProvider.GetService<IRateLimiterConfig>();

            services.AddRateLimiter(options =>
            {
                options.AddFixedWindowLimiter(policyName: "FixedRateLimit", opt =>
                {
                    opt.PermitLimit = rateLimiterConfig.PermitLimit;
                    opt.Window = TimeSpan.FromMinutes(rateLimiterConfig.Window);
                    opt.QueueProcessingOrder = Enum.Parse<QueueProcessingOrder>(rateLimiterConfig.QueueProcessingOrder);
                    opt.QueueLimit = rateLimiterConfig.QueueLimit;
                });

                options.OnRejected = async (context, token) =>
                {
                    context.HttpContext.Response.StatusCode = StatusCodes.Status429TooManyRequests;
                    if (context.Lease.TryGetMetadata(MetadataName.RetryAfter, out var retryAfter))
                    {
                        await context.HttpContext.Response.WriteAsync(
                            $"Too many requests. Please try again after {retryAfter.TotalMinutes} minute(s).", cancellationToken: token);
                    }
                    else
                    {

                        await context.HttpContext.Response.WriteAsync(
                            $"Too many requests. Please try again later." +
                            $"Read more about our rate limits at https://example.org/docs/ratelimiting.", cancellationToken: token);
                    }
                };
            });

        }
    }
}
