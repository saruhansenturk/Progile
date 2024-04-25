using MediatR;
using Microsoft.AspNetCore.Mvc;
using Progile.Application.Dtos.Team;
using Progile.Application.Features.Commands.TeamCommands.CreateTeamCommand;
using Progile.Application.Features.Commands.TeamCommands.DeleteTeam;
using Progile.Application.Features.Commands.TeamCommands.UpdateTeamCommand;
using Progile.Application.Features.Queries.TeamQueries.GetAllTeamQuery;
using Progile.Application.Features.Queries.TeamQueries.GetTeamByIdQuery;
using Progile.Application.Paging;
using Progile.Application.Response;

namespace Progile.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TeamsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<CommonResponse<CreateTeamDto>> CreateTeam(CreateTeamCommandRequest request)
        {
            CommonResponse<CreateTeamDto> response = await _mediator.Send(request);
            return response;
        }


        [HttpPost("[action]")]
        public async Task<CommonResponse<Pagination<GetAllTeamDto>>> GetAllTeam([FromBody] GetAllTeamQueryRequest request)
        {
            CommonResponse<Pagination<GetAllTeamDto>> response = await _mediator.Send(request);
            return response;
        }


        [HttpGet]
        public async Task<CommonResponse<TeamDetailsDto>> GetTeam([FromQuery] GetTeamByIdQueryRequest request)
        {
            CommonResponse<TeamDetailsDto> response = await _mediator.Send(request);
            return response;
        }

        [HttpPost("[action]")]
        public async Task<CommonResponse<UpdateTeamDto>> UpdateTeam([FromBody] UpdateTeamCommandRequest request)
        {
            CommonResponse<UpdateTeamDto> response = await _mediator.Send(request);
            return response;
        }
        
        [HttpPost("[action]")]
        public async Task<CommonResponse<bool>> Delete([FromQuery] DeleteTeamCommandRequest request)
        {
            CommonResponse<bool> response = await _mediator.Send(request);
            return response;
        }

    }
}
