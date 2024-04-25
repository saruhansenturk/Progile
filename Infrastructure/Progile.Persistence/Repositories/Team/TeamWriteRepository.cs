using Progile.Application.Repositories;
using Progile.Domain.Entities;
using Progile.Persistence.Contexts;

namespace Progile.Persistence.Repositories
{
    public class TeamWriteRepository : WriteRepository<Team>, ITeamWriteRepository
    {
        public TeamWriteRepository(ProgileContext context) : base(context)
        {
        }
    }
}
