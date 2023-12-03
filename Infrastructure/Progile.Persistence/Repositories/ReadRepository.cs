using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
        /// <summary>
        /// field id ye gore reflectionla o alanı burada lambda seklinde olusturur. Gelen alan ismine gore generic olarak kosul ifadesi olusturur.
        /// </summary>
        /// <private-method>_GetExpression</private-method>
        /// <param name="id"></param>
        /// <param name="field"></param>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <param name="tracking"></param>
        /// <returns></returns>
        public Pagination<T> GetAllById(Guid id, string field, int skip, int take, bool tracking = true)
        {
            var totalCount = Table.AsQueryable().Count(t => !t.IsDeleted);

            var expression = _GetExpression(id, field);

            var query = Table.AsQueryable()
                .Where(t => !t.IsDeleted)
                .Where(expression)
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


        private Expression<Func<T, bool>> _GetExpression(Guid id, string field)
        {
            var property = typeof(T).GetProperty(field);

            var parametre = Expression.Parameter(typeof(T));
            var prop = Expression.Property(parametre, property);
            var equal = Expression.Equal(prop, Expression.Constant(id));
            var lambda = Expression.Lambda<Func<T, bool>>(equal, parametre);
            return lambda;
        }
    }
}
