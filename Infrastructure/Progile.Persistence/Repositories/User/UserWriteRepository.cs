using Progile.Application.Paging;
using Progile.Application.Repositories;
using Progile.Domain.Entities;
using Progile.Persistence.Contexts;

namespace Progile.Persistence.Repositories;

public class UserWriteRepository: WriteRepository<User>, IUserWriteRepository
{
    public UserWriteRepository(ProgileContext context) : base(context)
    {
    }
}