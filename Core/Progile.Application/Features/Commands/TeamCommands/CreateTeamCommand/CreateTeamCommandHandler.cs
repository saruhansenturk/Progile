using MediatR;
using Progile.Application.Dtos;
using Progile.Application.Extensions;
using Progile.Application.Repositories;
using Progile.Application.Response;
using Progile.Domain.Entities;

namespace Progile.Application.Features.Commands.TeamCommands.CreateTeamCommand
{
    public class CreateTeamCommandHandler : IRequestHandler<CreateTeamCommandRequest, CommonResponse<CreateTeamDto>>
    {
        private readonly ITeamWriteRepository _teamWriteRepository;

        public CreateTeamCommandHandler(ITeamWriteRepository teamWriteRepository)
        {
            _teamWriteRepository = teamWriteRepository;
        }

        public async Task<CommonResponse<CreateTeamDto>> Handle(CreateTeamCommandRequest request, CancellationToken cancellationToken)
        {
            var createdTeam = await _teamWriteRepository.AddAsync(new Team
            {
                Name = request.Name,
                Description = request.Description,
                Creator = "Saruhan",
                Modifier = "Saruhan",
                IsDeleted = false,
                IsActive = true
            });

            var saveChanges = await _teamWriteRepository.SaveAsync();

            if (saveChanges.Data == 1)
                return new CommonResponse<CreateTeamDto>
                {
                    Data = createdTeam.MapTo<CreateTeamDto>(),
                    Message = "Team created successfuly!",
                    ResponseStatus = ResponseStatus.Success
                };


            return new CommonResponse<CreateTeamDto>
            {
                Data = null,
                Message = "",
                ResponseStatus = ResponseStatus.Fail
            };

        }
    }

    public class CreateTeamCommandRequest: IRequest<CommonResponse<CreateTeamDto>>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
    //public class CreateTeamCommandResponse
    //{
    //}

}
