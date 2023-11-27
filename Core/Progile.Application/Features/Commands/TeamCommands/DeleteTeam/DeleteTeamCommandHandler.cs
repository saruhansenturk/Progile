using MediatR;
using Progile.Application.Repositories;
using Progile.Application.Response;

namespace Progile.Application.Features.Commands.TeamCommands.DeleteTeam;

public class DeleteTeamCommandHandler : IRequestHandler<DeleteTeamCommandRequest, CommonResponse<bool>>
{
    private readonly ITeamReadRepository _teamReadRepository;
    private readonly ITeamWriteRepository _teamWriteRepository;

    public DeleteTeamCommandHandler(ITeamWriteRepository teamWriteRepository, ITeamReadRepository teamReadRepository)
    {
        _teamWriteRepository = teamWriteRepository;
        _teamReadRepository = teamReadRepository;
    }
    
    public async Task<CommonResponse<bool>> Handle(DeleteTeamCommandRequest request, CancellationToken cancellationToken)
    {
        var isDeleted = await _teamWriteRepository.RemoveAsync(request.Id);
        if (isDeleted)
        {
            var saveChanges = await _teamWriteRepository.SaveAsync();
            if (saveChanges.Data == 1)
                return new CommonResponse<bool>
                {
                    ResponseStatus = ResponseStatus.Success,
                    Message = "Team successfully deleted!"
                };
            else
                return new CommonResponse<bool>
                {
                    Message = "An error occured while executing the delete command!",
                    ResponseStatus = ResponseStatus.Fail
                };
        }
        return new CommonResponse<bool>
        {
            Message = "There is no team for this id.",
            ResponseStatus = ResponseStatus.Fail
        };
    }
}


public class DeleteTeamCommandRequest: IRequest<CommonResponse<bool>>
{
    public string Id { get; set; }
}