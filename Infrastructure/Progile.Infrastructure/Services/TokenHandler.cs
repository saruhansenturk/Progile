using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Progile.Application.Abstraction.Token;
using Progile.Application.Dtos.Token;
using Progile.Domain.Entities;

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
        /// <param name="user"></param>
        /// <returns></returns>
        public LoginToken CreateAccessToken(int second, User user)
        {
            LoginToken token = new();

            var key = Base64UrlEncoder.DecodeBytes(_tokenConfig.SecretKey);

            SymmetricSecurityKey securityKey = new(key);

            SigningCredentials signingCredentials = new(securityKey, SecurityAlgorithms.HmacSha256);

            token.Expiration = DateTime.Now.AddMinutes(second);
            JwtSecurityToken securityToken = new(
                audience: _tokenConfig.Audience,
                claims: new List<Claim>
                {
                    new (nameof(user.UserName), user.UserName ?? ""),
                    new (nameof(user.Email),  user.Email ?? ""),
                    new (nameof(user.Id),  user.Id)
                },
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
