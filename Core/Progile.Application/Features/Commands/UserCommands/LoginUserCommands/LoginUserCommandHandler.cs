using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Progile.Application.Abstraction.Services;
using Progile.Application.Dtos.Token;
using Progile.Application.Response;

namespace Progile.Application.Features.Commands.UserCommands.LoginUserCommands
{
    public class LoginUserCommandHandler: IRequestHandler<LoginUserCommandRequest, CommonResponse<LoginToken>>
    {
        private readonly IAuthService _authService;

        public LoginUserCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<CommonResponse<LoginToken>> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {
            var token = await _authService.LoginAsync(request.UsernameOrEmail, request.Password, 900);

            return token;
        }
    }

    public class LoginUserCommandRequest : IRequest<CommonResponse<LoginToken>>
    {
        public string UsernameOrEmail { get; set; }
        public string Password { get; set; }
    }
}
