using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Progile.Application.Repositories;
using Progile.Application.Response;
using Progile.Domain.Entities;

namespace Progile.Application.Features.Commands.ProjectCommands.UpdateProjectCommand
{
    public class UpdateProjectCommandHandler: IRequestHandler<UpdateProjectCommandRequest, CommonResponse<bool>>
    {
        private readonly IProjectWriteRepository _projectWriteRepository;
        private readonly IProjectReadRepository _projectReadRepository;

        public UpdateProjectCommandHandler(IProjectWriteRepository projectWriteRepository, IProjectReadRepository projectReadRepository)
        {
            _projectWriteRepository = projectWriteRepository;
            _projectReadRepository = projectReadRepository;
        }

        public async Task<CommonResponse<bool>> Handle(UpdateProjectCommandRequest request, CancellationToken cancellationToken)
        {
            var updateToEntity = await _projectReadRepository.GetByIdAsync(request.Id, false);

            if (updateToEntity != null)
            {
                updateToEntity.Name = request.Name;
                updateToEntity.Description = request.Description;

                _projectWriteRepository.Update(updateToEntity);
            }


            var saveChanges = await _projectWriteRepository.SaveAsync();

            return new CommonResponse<bool>
            {
                Data = saveChanges.Data > 0,
                ResponseStatus = saveChanges.Data > 0 ? ResponseStatus.Success : ResponseStatus.Fail
            };
        }
    }


    public class UpdateProjectCommandRequest : IRequest<CommonResponse<bool>>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
