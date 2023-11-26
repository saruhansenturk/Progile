using Progile.Application.Repositories;
using Progile.Persistence.Contexts;
using Task = Progile.Domain.Entities.Task;

namespace Progile.Persistence.Repositories;

public class TaskReadRepository: ReadRepository<Task>, ITaskReadRepository
{
    public TaskReadRepository(ProgileContext context) : base(context)
    {
    }
}