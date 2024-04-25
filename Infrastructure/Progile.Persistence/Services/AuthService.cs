using Microsoft.AspNetCore.Identity;
using Progile.Application.Abstraction.Services;
using Progile.Application.Abstraction.Token;
using Progile.Application.Dtos.Token;
using Progile.Application.Response;
using Progile.Domain.Entities;

namespace Progile.Persistence.Services
{
    public class AuthService : IAuthService
    {
        private readonly ITokenHandler _tokenHandler;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AuthService(ITokenHandler tokenHandler, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _tokenHandler = tokenHandler;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<CommonResponse<LoginToken>> LoginAsync(string userNameOrEmail, string password,
            int accesstokenLifeTime)
        {
            User? user = await _userManager.FindByNameAsync(userNameOrEmail) ??
                        await _userManager.FindByEmailAsync(userNameOrEmail);

            if (user == null)
                return new CommonResponse<LoginToken>
                {
                    Data = null,
                    ResponseStatus = ResponseStatus.Fail,
                    Message = "User not found!"
                };

            SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, password, false);

            if (!result.Succeeded)
                return new CommonResponse<LoginToken>
                {
                    Data = null,
                    ResponseStatus = ResponseStatus.Info,
                    Message = "User not logined! Please try again!"
                };

            LoginToken token = _tokenHandler.CreateAccessToken(accesstokenLifeTime);
            return new CommonResponse<LoginToken>
            {
                Data = token,
                ResponseStatus = ResponseStatus.Success
            };

        }
    }
}
