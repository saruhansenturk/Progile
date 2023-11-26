using Progile.Application.Repositories;
using Progile.Persistence.Contexts;
using Progile.Domain.Entities;

namespace Progile.Persistence.Repositories;

public class ProjectWriteRepository: WriteRepository<Project>, IProjectWriteRepository
{
    public ProjectWriteRepository(ProgileContext context) : base(context)
    {
    }
}