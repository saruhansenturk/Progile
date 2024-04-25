using Progile.Application.Paging;
using Progile.Domain.Entities.Common;

namespace Progile.Application.Repositories
{
    public interface IReadRepository<T>: IRepository<T> where T : BaseEntity
    {
        Pagination<T> GetAll(int skip, int take, bool tracking = true);
        Pagination<T> GetAllById(Guid id, string field, int skip, int take, bool tracking = true);
        List<T> GetAllById(Guid id, string field, bool tracking = true);

        Task<T?> GetByIdAsync(string id, bool tracking = true);
    }
}
