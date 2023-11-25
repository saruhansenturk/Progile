using MediatR;
using Progile.Application.Dtos;
using Progile.Application.Extensions;
using Progile.Application.Repositories;
using Progile.Application.Response;

namespace Progile.Application.Features.Queries.TeamQueries.GetTeamByIdQuery;

public class GetTeamByIdQueryHandler : IRequestHandler<GetTeamByIdQueryRequest, CommonResponse<TeamDetailsDto>>
{
    private readonly ITeamReadRepository _teamReadRepository;

    public GetTeamByIdQueryHandler(ITeamReadRepository teamReadRepository)
    {
        _teamReadRepository = teamReadRepository;
    }


    public async Task<CommonResponse<TeamDetailsDto>> Handle(GetTeamByIdQueryRequest request, CancellationToken cancellationToken)
    {
        var chosenTeam = await _teamReadRepository.GetByIdAsync(request.Id.ToString());

        if (chosenTeam == null)
        {
            return new CommonResponse<TeamDetailsDto>
            {
                ResponseStatus = ResponseStatus.NoData,
                Message = "There is no team recorded to this ID.",
                Data = null,
                Errors = null,
            };
        } 
        return new CommonResponse<TeamDetailsDto>
        {
            ResponseStatus = ResponseStatus.Success,
            Message = "Team query successful.",
            Data = new TeamDetailsDto
            {
                Name = chosenTeam.Name,
                Description = chosenTeam.Description
            }
        };
    }
}

public class GetTeamByIdQueryRequest: IRequest<CommonResponse<TeamDetailsDto>>
{
    public Guid Id { get; set; }
}