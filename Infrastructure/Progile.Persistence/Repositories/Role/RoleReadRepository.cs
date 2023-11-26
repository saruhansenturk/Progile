using Progile.Application.Repositories;
using Progile.Domain.Entities;
using Progile.Persistence.Contexts;

namespace Progile.Persistence.Repositories;

public class RoleReadRepository: ReadRepository<Role>, IRoleReadRepository
{
    public RoleReadRepository(ProgileContext context) : base(context)
    {
    }
}