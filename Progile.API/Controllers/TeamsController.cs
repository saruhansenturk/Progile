using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Progile.Application.Dtos;
using Progile.Application.Features.Commands.TeamCommands.CreateTeamCommand;
using Progile.Application.Features.Queries.TeamQueries.GetTeamByIdQuery;
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
        
        [HttpGet]
        //TODO: Might change something other than [FromQuery]
        public async Task<CommonResponse<TeamDetailsDto>> GetTeam([FromQuery]GetTeamByIdQueryRequest request)
        {
            CommonResponse<TeamDetailsDto> response = await _mediator.Send(request);
            return response;
        }
    }
}
