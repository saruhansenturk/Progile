using MediatR;
using Progile.Application.Dtos.Team;
using Progile.Application.Repositories;
using Progile.Application.Response;

namespace Progile.Application.Features.Commands.TeamCommands.UpdateTeamCommand
{
    public class UpdateTeamCommandHandler : IRequestHandler<UpdateTeamCommandRequest, CommonResponse<UpdateTeamDto>>
    {
        private readonly ITeamReadRepository _teamReadRepository;
        private readonly ITeamWriteRepository _teamWriteRepository;

        public UpdateTeamCommandHandler(ITeamReadRepository teamReadRepository, ITeamWriteRepository teamWriteRepository)
        {
            _teamReadRepository = teamReadRepository;
            _teamWriteRepository = teamWriteRepository;
        }

        public async Task<CommonResponse<UpdateTeamDto>> Handle(UpdateTeamCommandRequest request, CancellationToken cancellationToken)
        {
            var updateToItem = await _teamReadRepository.GetByIdAsync(request.Id, false);

            if (updateToItem != null)
            {
                updateToItem.Name = request.Name;
                updateToItem.Description = request.Description;
                var updatedTeam = _teamWriteRepository.Update(updateToItem);

                var saveChanges = await _teamWriteRepository.SaveAsync();

                if (saveChanges.Data == 1)
                    return new CommonResponse<UpdateTeamDto>
                    {
                        Data = new UpdateTeamDto
                        {
                            Description = updatedTeam.Data.Description,
                            Name = updatedTeam.Data.Name
                        },
                        ResponseStatus = ResponseStatus.Success,
                        Message = "Team successfully updated!"
                    };

                return new CommonResponse<UpdateTeamDto>
                {
                    Data = null,
                    Message = "An error occured when update to data!",
                    ResponseStatus = ResponseStatus.Fail
                };
            }

            return new CommonResponse<UpdateTeamDto>
            {
                Data = null,
                Message = "There is no update to item!",
                ResponseStatus = ResponseStatus.NoData
            };
        }
    }

    public class UpdateTeamCommandRequest : IRequest<CommonResponse<UpdateTeamDto>>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

}
