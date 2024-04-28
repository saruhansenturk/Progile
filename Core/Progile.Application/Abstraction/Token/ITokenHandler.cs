using Progile.Application.Dtos.Token;
using Progile.Domain.Entities;

namespace Progile.Application.Abstraction.Token
{
    public interface ITokenHandler
    {
        LoginToken CreateAccessToken(int second, User user);
    }
}
