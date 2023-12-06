using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Progile.Application.Abstraction.Token;
using Progile.Infrastructure.Config;

namespace Progile.Infrastructure.Services
{
    public class TokenHandler : ITokenHandler
    {
        private readonly ITokenConfig _tokenConfig;

        public TokenHandler(ITokenConfig tokenConfig)
        {
            _tokenConfig = tokenConfig;
        }

        /// <summary>
        /// Create Token for the AuthService Login method.
        /// </summary>
        /// <param name="second"></param>
        /// <returns></returns>
        public string CreateAccessToken(int second)
        {
            return "";
        }
    }
}
