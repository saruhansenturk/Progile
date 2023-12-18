using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
