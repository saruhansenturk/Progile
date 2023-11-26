using Progile.Domain.Entities;
using Task = Progile.Domain.Entities.Task;

namespace Progile.Application.Repositories;

public interface ITaskWriteRepository : IWriteRepository<Task>
{
    
}