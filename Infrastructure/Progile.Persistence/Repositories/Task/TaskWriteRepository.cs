using Progile.Application.Repositories;
using Progile.Persistence.Contexts;
using Task = Progile.Domain.Entities.Task;

namespace Progile.Persistence.Repositories;

public class TaskWriteRepository: WriteRepository<Task>, ITaskWriteRepository
{
    public TaskWriteRepository(ProgileContext context) : base(context)
    {
    }
}