using Progile.Application.Response;
using Progile.Domain.Entities.Common;

namespace Progile.Application.Repositories;

public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity
{
    Task<CommonResponse<T>> AddAsync(T model);
    Task<bool> AddRangeAsync(List<T> datas);
    Task<bool> RemoveAsync(string id);
    bool RemoveRange(List<T> datas);
    CommonResponse<T> Update(T model);

    Task<CommonResponse<int>> SaveAsync();

}