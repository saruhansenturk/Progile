using MediatR;
using Progile.Application.Dtos.Project;
using Progile.Application.Extensions;
using Progile.Application.Repositories;
using Progile.Application.Response;

namespace Progile.Application.Features.Queries.ProjectQueries.GetByIdProjectQuery
{
    public class GetByIdProjectQueryHandler: IRequestHandler<GetByIdProjectQueryRequest, CommonResponse<GetByIdProjectDto>>
    {
        private readonly IProjectReadRepository _projectReadRepository;

        public GetByIdProjectQueryHandler(IProjectReadRepository projectReadRepository)
        {
            _projectReadRepository = projectReadRepository;
        }

        public async Task<CommonResponse<GetByIdProjectDto>> Handle(GetByIdProjectQueryRequest request, CancellationToken cancellationToken)
        {
            var project = await _projectReadRepository.GetByIdAsync(request.ProjectId, false);

            if (project != null)
                return new CommonResponse<GetByIdProjectDto>
                {
                    Data = project.MapTo<GetByIdProjectDto>(),
                    ResponseStatus = ResponseStatus.Success
                };

            return new CommonResponse<GetByIdProjectDto>
            {
                Data = null,
                ResponseStatus = ResponseStatus.NoData,
                Message = "There is no project your search criteria!"
            };
        }
    }

    public class GetByIdProjectQueryRequest: IRequest<CommonResponse<GetByIdProjectDto>>
    {
        public string ProjectId { get; set; }
    }
}
