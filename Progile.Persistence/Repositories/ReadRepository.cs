using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Progile.Application.Paging;
using Progile.Application.Repositories;
using Progile.Domain.Entities.Common;
using Progile.Persistence.Contexts;

namespace Progile.Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly ProgileContext _context;

        public ReadRepository(ProgileContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public Pagination<T> GetAll(int skip, int take, bool tracking = true)
        {
            var totalCount = Table.AsQueryable().Count(t => !t.IsDeleted);

            var query = Table.AsQueryable()
                    .Where(t => !t.IsDeleted)
                    .Paginate(skip, take);

            if (!tracking)
                query = query.AsNoTracking();

            return new Pagination<T>(totalCount, query.ToList());
        }

        public async Task<T?> GetByIdAsync(string id, bool tracking = true)
        {
            var query = Table.AsQueryable();

            if (!tracking)
                query = query.AsNoTracking();

            return await query.FirstOrDefaultAsync(t => t.Id == Guid.Parse(id) && !t.IsDeleted);
        }
    }
}
