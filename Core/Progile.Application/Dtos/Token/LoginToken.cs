namespace Progile.Application.Dtos.Token
{
    public class LoginToken
    {
        public string AccessToken { get; set; }
        public DateTime Expiration { get; set; }
    }
}
