using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Progile.Application.Dtos.Project;
using Progile.Application.Dtos.Team;
using Progile.Application.Paging;
using Progile.Application.Repositories;
using Progile.Application.Response;
using Progile.Domain.Entities;

namespace Progile.Application.Features.Queries.ProjectQueries.GetAllProjectQuery
{
    public class GetAllProjectQueryHandler: IRequestHandler<GetAllProjectQueryRequest, CommonResponse<Pagination<GetAllProjectDto>>>
    {
        private readonly IProjectReadRepository _projectReadRepository;

        public GetAllProjectQueryHandler(IProjectReadRepository projectReadRepository)
        {
            _projectReadRepository = projectReadRepository;
        }

        public async Task<CommonResponse<Pagination<GetAllProjectDto>>> Handle(GetAllProjectQueryRequest request, CancellationToken cancellationToken)
        {
            var projects = _projectReadRepository.GetAll(request.Skip, request.Take, false);

            if (projects.Items.Any())
            {
                var mappedProjects = projects.Items.Select(t => new GetAllProjectDto()
                {
                    Name = t.Name,
                    Description = t.Description,
                    CreatedDate = t.CreatedDate
                }).ToList();

                return new CommonResponse<Pagination<GetAllProjectDto>>
                {

                    Data = new Pagination<GetAllProjectDto>
                    {
                        Items = mappedProjects,
                        TotalCount = projects.TotalCount
                    },
                    ResponseStatus = ResponseStatus.Success
                };
            }

            return new CommonResponse<Pagination<GetAllProjectDto>>
            {
                Data = null,
                ResponseStatus = ResponseStatus.NoData,
                Message = "There is no team!"
            };
        }
    }

    public class GetAllProjectQueryRequest : IRequest<CommonResponse<Pagination<GetAllProjectDto>>>
    {
        public int Take { get; set; }
        public int Skip { get; set; }
    }
}
