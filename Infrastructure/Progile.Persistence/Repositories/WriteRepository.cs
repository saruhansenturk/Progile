using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Progile.Application.Repositories;
using Progile.Application.Response;
using Progile.Domain.Entities.Common;
using Progile.Persistence.Contexts;

namespace Progile.Persistence.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
    {
        private readonly ProgileContext _context;


        public WriteRepository(ProgileContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();


        public async Task<CommonResponse<T>> AddAsync(T model)
        {
            try
            {
                EntityEntry<T> addedEntity = await Table.AddAsync(model);

                if (addedEntity.State == EntityState.Added)
                {
                    return new CommonResponse<T>
                    {
                        Data = addedEntity.Entity,
                        ResponseStatus = ResponseStatus.Success,
                        Message = "Entity inserted successfully."
                    };
                }

                return new CommonResponse<T>
                {
                    ResponseStatus = ResponseStatus.Info,
                    Message = "Entity couldn't be inserted."
                };
            }
            catch (Exception e)
            {
                return new CommonResponse<T>
                {
                    Data = null,
                    ResponseStatus = ResponseStatus.Fail,
                    Message = "An error occurred when inserting the data.",
                    Errors = new List<string> { e.Message }
                };
            }
        }

        public async Task<bool> AddRangeAsync(List<T> datas)
        {
            try
            {
                await Table.AddRangeAsync(datas);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message, exception.InnerException);
            }
            return true;
        }

        public async Task<bool> RemoveAsync(string id)
        {
            T? deletedToEntity = await Table.FirstOrDefaultAsync(t => t.Id == Guid.Parse(id) && !t.IsDeleted);

            if (deletedToEntity != null)
            {
                deletedToEntity.IsDeleted = true;
                var updateToDeleted = Update(deletedToEntity).Data;
                return updateToDeleted.IsDeleted;
            }
            return false;
        }

        public bool RemoveRange(List<T> datas)
        {
            datas.ForEach(t =>
            {
                t.IsDeleted = true;
            });

            Table.UpdateRange(datas);
            return true;
        }

        public CommonResponse<T> Update(T model)
        {
            EntityEntry<T> entityEntry = Table.Update(model);

            if (entityEntry.State == EntityState.Modified)
                return new CommonResponse<T>
                {
                    Data = entityEntry.Entity,
                    ResponseStatus = ResponseStatus.Success
                };

            return new CommonResponse<T>
            {
                ResponseStatus = ResponseStatus.Fail
            };
        }

        public async Task<CommonResponse<int>> SaveAsync()
        {
            try
            {
                int saveChanges = await _context.SaveChangesAsync();
                return new CommonResponse<int>
                {
                    Data = saveChanges,
                    Message = "Changes were successfully saved!",
                    ResponseStatus = ResponseStatus.Success
                };
            }
            catch (Exception e)
            {
                return new CommonResponse<int>
                {
                    Data = 0,
                    Message = $"Failed to save changes. {e.Message}",
                    ResponseStatus = ResponseStatus.Fail
                };
            }
        }
    }
}
