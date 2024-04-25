using Progile.Application.Dtos.Token;

namespace Progile.Application.Abstraction.Token
{
    public interface ITokenHandler
    {
        LoginToken CreateAccessToken(int second);
    }
}
