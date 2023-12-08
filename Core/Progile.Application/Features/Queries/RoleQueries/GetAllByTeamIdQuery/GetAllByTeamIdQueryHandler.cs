using MediatR;
using Progile.Application.Dtos.Role;
using Progile.Application.Repositories;
using Progile.Application.Response;

namespace Progile.Application.Features.Queries.RoleQueries.GetAllByTeamIdQuery
{
    public class RoleGetAllByTeamQueryHandler : IRequestHandler<RoleGetAllByTeamQueryRequest, CommonResponse<List<RoleGetAllByTeamDto>>>
    {
        private readonly IRoleReadRepository _roleReadRepository;

        public RoleGetAllByTeamQueryHandler(IRoleReadRepository roleReadRepository)
        {
            _roleReadRepository = roleReadRepository;
        }

        public async Task<CommonResponse<List<RoleGetAllByTeamDto>>> Handle(RoleGetAllByTeamQueryRequest request, CancellationToken cancellationToken)
        {
            var roles = _roleReadRepository.GetAllById(Guid.Parse(request.TeamId), "TeamId", false);

            if (roles.Any())
            {
                var mappedRoles = roles.Select(r => new RoleGetAllByTeamDto
                {
                    Name = r.Name,
                }).ToList();

                return new CommonResponse<List<RoleGetAllByTeamDto>>
                {
                    Data = mappedRoles,
                    ResponseStatus = ResponseStatus.Success,
                    Message = "Roles retrieved successfully."
                };
            }

            return new CommonResponse<List<RoleGetAllByTeamDto>>
            {
                Data = null,
                ResponseStatus = ResponseStatus.NoData,
                Message = "There are no roles for this team."
            };
        }
    }

    public class RoleGetAllByTeamQueryRequest : IRequest<CommonResponse<List<RoleGetAllByTeamDto>>>
    {
        public string TeamId { get; set; }
    }
}