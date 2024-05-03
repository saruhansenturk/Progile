namespace Progile.Application.Abstraction.Token;

public interface IRateLimiterConfig
{
    public int PermitLimit { get; set; }
    public int Window { get; set; }
    public int QueueLimit { get; set; }
    public string QueueProcessingOrder { get; set; }
}