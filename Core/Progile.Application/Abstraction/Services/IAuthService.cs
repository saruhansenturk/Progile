using Progile.Application.Dtos.Token;
using Progile.Application.Response;

namespace Progile.Application.Abstraction.Services
{
    public interface IAuthService
    {
        //todo string yerine token tipi don
        Task<CommonResponse<LoginToken>> LoginAsync(string userNameOrEmail, string password, int accesstokenLifeTime);
    }
}
