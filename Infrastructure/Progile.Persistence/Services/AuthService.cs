using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Progile.Application.Abstraction.Services;
using Progile.Application.Abstraction.Token;

namespace Progile.Persistence.Services
{
    public class AuthService : IAuthService
    {
        private readonly ITokenHandler _tokenHandler;

        public AuthService(ITokenHandler tokenHandler)
        {
            _tokenHandler = tokenHandler;
        }

        public Task<string> LoginAsync(string userNameOrEmail, string password, int accesstokenLifeTime)
        {
            // todo this content will change. Below codes for only test
            var ss = _tokenHandler.CreateAccessToken(12);
            throw new NotImplementedException();
        }
    }
}
