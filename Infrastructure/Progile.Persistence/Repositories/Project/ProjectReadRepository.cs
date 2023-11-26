using Progile.Application.Repositories;
using Progile.Domain.Entities;
using Progile.Persistence.Contexts;


namespace Progile.Persistence.Repositories;

public class ProjectReadRepository: ReadRepository<Project>, IProjectReadRepository
{
    public ProjectReadRepository(ProgileContext context) : base(context)
    {
    }
}