using MediatR;
using Progile.Application.Repositories;
using Progile.Application.Response;

namespace Progile.Application.Features.Commands.TaskCommands.DeleteTaskCommand
{
    public class DeleteTaskCommandHandler : IRequestHandler<DeleteTaskCommandRequest, CommonResponse<bool>>
    {
        private readonly ITaskWriteRepository _taskWriteRepository;
        public DeleteTaskCommandHandler(ITaskWriteRepository taskWriteRepository)
        {
            _taskWriteRepository = taskWriteRepository;
        }

        public async Task<CommonResponse<bool>> Handle(DeleteTaskCommandRequest request, CancellationToken cancellationToken)
        {
            var deleteToTask = await _taskWriteRepository.RemoveAsync(request.TaskId);

            if (deleteToTask)
            {
                var saveChanges = await _taskWriteRepository.SaveAsync();

                if (saveChanges.Data == 1)
                    return new CommonResponse<bool>
                    {
                        Data = true,
                        ResponseStatus = ResponseStatus.Success,
                        Message = "Task successfully deleted!"
                    };
                
                return new CommonResponse<bool>
                {
                    Data = false,
                    Message = "An error occurred while executing the delete command!",
                    ResponseStatus = ResponseStatus.Fail
                };
            }

            return new CommonResponse<bool>
            {
                Message = "There is no task for this id.",
                ResponseStatus = ResponseStatus.NoData
            };

        }
    }

    public class DeleteTaskCommandRequest : IRequest<CommonResponse<bool>>
    {
        public string TaskId { get; set; }
    }
}
