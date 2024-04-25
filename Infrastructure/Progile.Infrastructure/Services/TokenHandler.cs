using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Progile.Application.Abstraction.Token;
using Progile.Application.Dtos.Token;

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
        public LoginToken CreateAccessToken(int second)
        {
            LoginToken token = new();

            SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(_tokenConfig.SecretKey));

            SigningCredentials signingCredentials = new(securityKey, SecurityAlgorithms.HmacSha256);

            token.Expiration = DateTime.Now.AddMinutes(second);
            JwtSecurityToken securityToken = new(
                audience: _tokenConfig.Audience,
                issuer: _tokenConfig.Issuer,
                expires: token.Expiration,
                notBefore: DateTime.Now,
                signingCredentials: signingCredentials);

            JwtSecurityTokenHandler tokenHandler = new();
            token.AccessToken = tokenHandler.WriteToken(securityToken);

            return token;
        }
    }
}
