using MediatR;
using Progile.Application.Dtos.Task;
using Progile.Application.Extensions;
using Progile.Application.Repositories;
using Progile.Application.Response;

namespace Progile.Application.Features.Queries.TaskQueries.GetTaskByIdQuery
{
    public class GetTaskByIdQueryHandler : IRequestHandler<GetTaskByIdQueryRequest, CommonResponse<ByIdTaskDto>>
    {
        private readonly ITaskReadRepository _taskReadRepository;

        public GetTaskByIdQueryHandler(ITaskReadRepository taskReadRepository)
        {
            _taskReadRepository = taskReadRepository;
        }

        /// <summary>
        /// This method may be used when clicking the task item.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<CommonResponse<ByIdTaskDto>> Handle(GetTaskByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var task = await _taskReadRepository.GetByIdAsync(request.TaskId, false);

            if (task != null)
                return new CommonResponse<ByIdTaskDto>
                {
                    Data = task.MapTo<ByIdTaskDto>(),
                    ResponseStatus = ResponseStatus.Success
                };

            return new CommonResponse<ByIdTaskDto>
            {
                Data = null,
                ResponseStatus = ResponseStatus.NoData,
                Message = "There is no task!"
            };
        }
    }

    public class GetTaskByIdQueryRequest : IRequest<CommonResponse<ByIdTaskDto>>
    {
        public string TaskId { get; set; }
    }
}
