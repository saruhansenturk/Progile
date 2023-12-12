using MediatR;
using Progile.Application.Dtos.Task;
using Progile.Application.Extensions;
using Progile.Application.Paging;
using Progile.Application.Repositories;
using Progile.Application.Response;
using Progile.Domain.Enums;

namespace Progile.Application.Features.Queries.TaskQueries.GetTaskByProjectQuery
{
    public class GetAllTaskByProjectIdQueryHandler : IRequestHandler<GetAllTaskByProjectIdQueryRequest, CommonResponse<Pagination<AllTaskByProjectIdDto>>>
    {
        private readonly ITaskReadRepository _taskReadRepository;

        public GetAllTaskByProjectIdQueryHandler(ITaskReadRepository taskReadRepository)
        {
            _taskReadRepository = taskReadRepository;
        }

        public async Task<CommonResponse<Pagination<AllTaskByProjectIdDto>>> Handle(GetAllTaskByProjectIdQueryRequest request, CancellationToken cancellationToken)
        {
            var tasks = _taskReadRepository.GetAllById(Guid.Parse(request.ProjectId), ForeignKey.ProjectId.ToString(), request.Skip, request.Take, false);

            if (tasks.Items.Any())
            {
                var mappedTasks = tasks.Items.Select(t => t.MapTo<AllTaskByProjectIdDto>()).ToList();

                return new CommonResponse<Pagination<AllTaskByProjectIdDto>>
                {
                    Data = new Pagination<AllTaskByProjectIdDto>
                    {
                        Items = mappedTasks,
                        TotalCount = tasks.TotalCount
                    },
                    ResponseStatus = ResponseStatus.Success
                };
            }

            return new CommonResponse<Pagination<AllTaskByProjectIdDto>>
            {
                Data = null,
                ResponseStatus = ResponseStatus.NoData,
                Message = "There is have no projects for this team."
            };
        }
    }

    public class GetAllTaskByProjectIdQueryRequest : IRequest<CommonResponse<Pagination<AllTaskByProjectIdDto>>>
    {
        public string ProjectId { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }
    }
}
