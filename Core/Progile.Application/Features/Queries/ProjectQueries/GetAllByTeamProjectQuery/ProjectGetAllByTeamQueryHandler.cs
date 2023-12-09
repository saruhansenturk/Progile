using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Progile.Application.Dtos.Project;
using Progile.Application.Extensions;
using Progile.Application.Paging;
using Progile.Application.Repositories;
using Progile.Application.Response;
using Progile.Domain.Enums;

namespace Progile.Application.Features.Queries.ProjectQueries.GetAllByTeamProjectQuery
{
    public class ProjectGetAllByTeamQueryHandler: IRequestHandler<ProjectGetAllByTeamQueryRequest, CommonResponse<Pagination<ProjectGetAllByTeamDto>>>
    {
        private readonly IProjectReadRepository _projectReadRepository;

        public ProjectGetAllByTeamQueryHandler(IProjectReadRepository projectReadRepository)
        {
            _projectReadRepository = projectReadRepository;
        }

        public async Task<CommonResponse<Pagination<ProjectGetAllByTeamDto>>> Handle(ProjectGetAllByTeamQueryRequest request, CancellationToken cancellationToken)
        {
            var projects = _projectReadRepository.GetAllById(Guid.Parse(request.TeamId), ForeignKey.TeamId.ToString(), request.Skip, request.Take, false);

            if (projects.TotalCount > 0)
            {
                var mappedProjects = projects.Items.Select(t => new ProjectGetAllByTeamDto
                {
                    Name = t.Name,
                    Description = t.Description
                }).ToList();

                return new CommonResponse<Pagination<ProjectGetAllByTeamDto>>
                {
                    Data = new Pagination<ProjectGetAllByTeamDto>
                    {
                        Items = mappedProjects,
                        TotalCount = projects.TotalCount,
                    },
                    ResponseStatus = ResponseStatus.Success
                };
            }
                

            return new CommonResponse<Pagination<ProjectGetAllByTeamDto>>
            {
                Data = null,
                ResponseStatus = ResponseStatus.NoData,
                Message = "There is have no projects for this team."
            };
        }
    }

    public class ProjectGetAllByTeamQueryRequest : IRequest<CommonResponse<Pagination<ProjectGetAllByTeamDto>>>
    {
        public string TeamId { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }
    }

}
