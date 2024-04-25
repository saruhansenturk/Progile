using MediatR;
using Microsoft.AspNetCore.Mvc;
using Progile.Application.Dtos.Token;
using Progile.Application.Features.Commands.UserCommands.CreateUserCommands;
using Progile.Application.Features.Commands.UserCommands.LoginUserCommands;
using Progile.Application.Response;

namespace Progile.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("[action]")]
        public async Task<CommonResponse<bool>> CreateUser(CreateUserCommandRequest request)
        {
            CommonResponse<bool> response = await _mediator.Send(request);
            return response;
        }

        [HttpPost("[action]")]
        public async Task<CommonResponse<LoginToken>> LoginUser(LoginUserCommandRequest request)
        {
            CommonResponse<LoginToken> response = await _mediator.Send(request);
            return response;
        }

        //[HttpPost("[action]")]
        //public async Task<CommonResponse<bool>> Delete(DeleteRoleCommandRequest request)
        //{
        //    CommonResponse<bool> response = await _mediator.Send(request);
        //    return response;
        //}

        //[HttpGet("[action]")]
        //public async Task<CommonResponse<List<RoleGetAllByTeamDto>>> ByTeamId(RoleGetAllByTeamQueryRequest request)
        //{
        //    CommonResponse<List<RoleGetAllByTeamDto>> response = await _mediator.Send(request);
        //    return response;
        //}



    }
}
