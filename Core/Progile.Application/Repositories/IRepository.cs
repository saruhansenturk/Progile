using Progile.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace Progile.Application.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        DbSet<T> Table { get; }
    }
}
