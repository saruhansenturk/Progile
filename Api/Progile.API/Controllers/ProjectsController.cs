using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Progile.Application.Dtos.Project;
using Progile.Application.Features.Commands.ProjectCommands.CreateProjectCommand;
using Progile.Application.Features.Commands.ProjectCommands.DeleteProjectCommand;
using Progile.Application.Features.Commands.ProjectCommands.UpdateProjectCommand;
using Progile.Application.Features.Queries.ProjectQueries.GetAllByTeamProjectQuery;
using Progile.Application.Features.Queries.ProjectQueries.GetAllProjectQuery;
using Progile.Application.Features.Queries.ProjectQueries.GetByIdProjectQuery;
using Progile.Application.Paging;
using Progile.Application.Response;

namespace Progile.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProjectsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<CommonResponse<CreateProjectDto>> CreateProject(CreateProjectCommandRequest request)
        {
            CommonResponse<CreateProjectDto> response = await _mediator.Send(request);
            return response;
        }

        [HttpPost("[action]")]
        public async Task<CommonResponse<Pagination<ProjectGetAllByTeamDto>>> GetAllProjectByTeam(
            ProjectGetAllByTeamQueryRequest request)
        {
            CommonResponse<Pagination<ProjectGetAllByTeamDto>> response = await _mediator.Send(request);
            return response;
        }

        [HttpPost("[action]")]
        public async Task<CommonResponse<bool>> UpdateProject([FromBody] UpdateProjectCommandRequest request)
        {
            CommonResponse<bool> response = await _mediator.Send(request);
            return response;
        }


        [HttpPost("[action]")]
        [Authorize]
        public async Task<CommonResponse<Pagination<GetAllProjectDto>>> GetAllProject([FromBody] GetAllProjectQueryRequest request)
        {
            CommonResponse<Pagination<GetAllProjectDto>> response = await _mediator.Send(request);
            return response;
        }


        [HttpGet("[action]")]
        public async Task<CommonResponse<GetByIdProjectDto>> GetProject([FromQuery] GetByIdProjectQueryRequest request)
        {
            CommonResponse<GetByIdProjectDto> response = await _mediator.Send(request);
            return response;
        }



        [HttpPost("[action]")]
        public async Task<CommonResponse<bool>> Delete([FromQuery] DeleteProjectCommandRequest request)
        {
            CommonResponse<bool> response = await _mediator.Send(request);
            return response;
        }

    }
}
