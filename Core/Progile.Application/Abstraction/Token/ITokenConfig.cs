namespace Progile.Application.Abstraction.Token;

public interface ITokenConfig
{
    public string Audience { get; set; }
    public string Issuer { get; set; }
    public string SecretKey { get; set; }
    public int Expiration { get; set; }
}