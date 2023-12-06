using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progile.Application.Abstraction.Services
{
    public interface IAuthService
    {
        //todo string yerine token tipi don
        Task<string> LoginAsync(string userNameOrEmail, string password, int accesstokenLifeTime);
    }
}
