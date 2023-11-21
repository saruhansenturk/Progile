using Progile.Application.Paging;
using Progile.Application.Repositories;
using Progile.Domain.Entities;
using Progile.Persistence.Contexts;

namespace Progile.Persistence.Repositories;

public class TeamReadRepository: ReadRepository<Team>, ITeamReadRepository
{
    public TeamReadRepository(ProgileContext context) : base(context)
    {
    }
}