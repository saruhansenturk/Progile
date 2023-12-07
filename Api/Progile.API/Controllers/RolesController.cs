using MediatR;
using Microsoft.AspNetCore.Mvc;
using Progile.Application.Dtos.Project;
using Progile.Application.Dtos.Role;
using Progile.Application.Features.Commands.ProjectCommands.CreateProjectCommand;
using Progile.Application.Features.Commands.RoleCommands.CreateRoleCommand;
using Progile.Application.Features.Commands.RoleCommands.DeleteRoleCommand;
using Progile.Application.Features.Queries.ProjectQueries.GetAllByTeamProjectQuery;
using Progile.Application.Paging;
using Progile.Application.Response;

namespace Progile.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RolesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<CommonResponse<CreateRoleDto>> CreateProject(CreateRoleCommandRequest request)
        {
            CommonResponse<CreateRoleDto> response = await _mediator.Send(request);
            return response;
        }
        
        [HttpPost("[action]")]
        public async Task<CommonResponse<bool>> Delete(DeleteRoleCommandRequest request)
        {
            CommonResponse<bool> response = await _mediator.Send(request);
            return response;
        }

    

    }
}
