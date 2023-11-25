using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Progile.Application.Dtos.Team;
using Progile.Application.Paging;
using Progile.Application.Repositories;
using Progile.Application.Response;

namespace Progile.Application.Features.Queries.TeamQueries.GetAllTeamQuery
{
    public class GetAllTeamQueryHandler: IRequestHandler<GetAllTeamQueryRequest, CommonResponse<Pagination<GetAllTeamDto>>>
    {
        private readonly ITeamReadRepository _teamReadRepository;

        public GetAllTeamQueryHandler(ITeamReadRepository teamReadRepository)
        {
            _teamReadRepository = teamReadRepository;
        }

        public async Task<CommonResponse<Pagination<GetAllTeamDto>>> Handle(GetAllTeamQueryRequest request, CancellationToken cancellationToken)
        {
            var teams = _teamReadRepository.GetAll(request.Skip, request.Take, false);

            if (teams.Items.Any())
            {
                var mappedTeams = teams.Items.Select(t => new GetAllTeamDto
                {
                    Name = t.Name,
                    Description = t.Description,
                    CreatedDate = t.CreatedDate
                }).ToList();

                return new CommonResponse<Pagination<GetAllTeamDto>>
                {

                    Data = new Pagination<GetAllTeamDto>
                    {
                        Items = mappedTeams,
                        TotalCount = teams.TotalCount
                    },
                    ResponseStatus = ResponseStatus.Success
                };
            }

            return new CommonResponse<Pagination<GetAllTeamDto>>
            {
                Data = null,
                ResponseStatus = ResponseStatus.NoData,
                Message = "There is no team!"
            };
        }
    }

    public class GetAllTeamQueryRequest : IRequest<CommonResponse<Pagination<GetAllTeamDto>>>
    {
        public int Take { get; set; }
        public int Skip { get; set; }
    }
}
