using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Progile.Application.Repositories;
using Progile.Application.Response;
using Progile.Domain.Enums;

namespace Progile.Application.Features.Commands.TaskCommands.UpdateTaskCommand
{
    public class UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommandRequest, CommonResponse<bool>>
    {
        private readonly ITaskWriteRepository _taskWriteRepository;
        private readonly ITaskReadRepository _taskReadRepository;

        public UpdateTaskCommandHandler(ITaskWriteRepository taskWriteRepository, ITaskReadRepository taskReadRepository)
        {
            _taskWriteRepository = taskWriteRepository;
            _taskReadRepository = taskReadRepository;
        }

        public async Task<CommonResponse<bool>> Handle(UpdateTaskCommandRequest request, CancellationToken cancellationToken)
        {
            // todo will update to tasks users! Don't forget!
            var updateToEntity = await _taskReadRepository.GetByIdAsync(request.TaskId, false);

            if (updateToEntity != null)
            {
                updateToEntity.Description = request.Description;
                updateToEntity.EndDate = request.EndDate;
                updateToEntity.StartDate = request.StartDate;
                updateToEntity.IsCanceled = request.IsCanceled;
                updateToEntity.IsDone = request.IsDone;
                updateToEntity.IsLimited = request.IsLimited;
                updateToEntity.Title = request.Title;
                updateToEntity.UrgentStatus = request.UrgentStatus;
                updateToEntity.Name = request.Name;

                _taskWriteRepository.Update(updateToEntity);
            }

            var saveChanges = await _taskWriteRepository.SaveAsync();

            return new CommonResponse<bool>
            {
                Data = saveChanges.Data > 0,
                ResponseStatus = saveChanges.Data > 0 ? ResponseStatus.Success : ResponseStatus.Fail
            };
        }
    }

    public class UpdateTaskCommandRequest : IRequest<CommonResponse<bool>>
    {
        public string TaskId { get; set; }

        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsLimited { get; set; }
        public UrgentStatus UrgentStatus { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsDone { get; set; }
        public bool IsCanceled { get; set; }
    }
}
