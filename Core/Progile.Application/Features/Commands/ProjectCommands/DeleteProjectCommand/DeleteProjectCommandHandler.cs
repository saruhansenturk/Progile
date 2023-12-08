using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Progile.Application.Repositories;
using Progile.Application.Response;

namespace Progile.Application.Features.Commands.ProjectCommands.DeleteProjectCommand
{
    public class DeleteProjectCommandHandler: IRequestHandler<DeleteProjectCommandRequest, CommonResponse<bool>>
    {
        private readonly IProjectWriteRepository _projectWriteRepository;

        public DeleteProjectCommandHandler(IProjectWriteRepository projectWriteRepository, IProjectReadRepository projectReadRepository)
        {
            _projectWriteRepository = projectWriteRepository;
        }

        public async Task<CommonResponse<bool>> Handle(DeleteProjectCommandRequest request, CancellationToken cancellationToken)
        {
            var deleted = await _projectWriteRepository.RemoveAsync(request.Id);

            if (deleted)
            {
                var saveChanges = await _projectWriteRepository.SaveAsync();
                if (saveChanges.Data == 1)
                {
                    return new CommonResponse<bool>
                    {
                        ResponseStatus = ResponseStatus.Success,
                        Message = "Project ssuccessfully deleted!"
                    };
                }

                return new CommonResponse<bool>
                {
                    Message = "An error occurred while executing the delete command!",
                    ResponseStatus = ResponseStatus.Fail
                };
            }

            return new CommonResponse<bool>
            {
                Message = "There is no project for this id.",
                ResponseStatus = ResponseStatus.NoData
            };
        }
    }

    public class DeleteProjectCommandRequest : IRequest<CommonResponse<bool>>
    {
        public string Id { get; set; }
    }
}
