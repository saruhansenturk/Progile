using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Progile.Application.Dtos.Project;
using Progile.Application.Extensions;
using Progile.Application.Repositories;
using Progile.Application.Response;
using Progile.Domain.Entities;

namespace Progile.Application.Features.Commands.ProjectCommands.CreateProjectCommand
{
    public class ProjectCreateCommandHandler: IRequestHandler<CreateProjectCommandRequest, CommonResponse<CreateProjectDto>>
    {
        private readonly IProjectWriteRepository _projectWriteRepository;

        public ProjectCreateCommandHandler(IProjectWriteRepository projectWriteRepository)
        {
            _projectWriteRepository = projectWriteRepository;
        }

        public async Task<CommonResponse<CreateProjectDto>> Handle(CreateProjectCommandRequest request, CancellationToken cancellationToken)
        {
            var createdProject = await _projectWriteRepository.AddAsync(new Project
            {
                Name = request.Name,
                TeamId = request.TeamId,
                Description = request.Description,
                Creator = "Saruhan",
                Modifier = "Saruhan",
                IsDeleted = false,
                IsActive = true
            });

            var saveChanges = await _projectWriteRepository.SaveAsync();

            if (saveChanges.Data == 1)
                return new CommonResponse<CreateProjectDto>
                {
                    Data = createdProject?.Data?.MapTo<CreateProjectDto>(),
                    ResponseStatus = ResponseStatus.Success
                };

            return new CommonResponse<CreateProjectDto>
            {
                Data = null,
                ResponseStatus = ResponseStatus.Fail,
                Message = "An error occured when insert to data!"
            };
        }
    }

    public class CreateProjectCommandRequest : IRequest<CommonResponse<CreateProjectDto>>
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public Guid TeamId { get; set; }
    }

}
