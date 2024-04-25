using MediatR;
using Progile.Application.Abstraction.Services;
using Progile.Application.Dtos.User;
using Progile.Application.Response;

namespace Progile.Application.Features.Commands.UserCommands.CreateUserCommands
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CommonResponse<bool>>
    {
        private readonly IUserService<bool> _userService;

        public CreateUserCommandHandler(IUserService<bool> userService)
        {
            _userService = userService;
        }

        public async Task<CommonResponse<bool>> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            var response = await _userService.CreateAsync(new CreateUserDto
            {
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Password = request.Password,
                UserName = request.UserName,
                PasswordConfirm = request.PasswordConfirm
            });

            return response;
        }
    }

    public class CreateUserCommandRequest : IRequest<CommonResponse<bool>>
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
    }
}
