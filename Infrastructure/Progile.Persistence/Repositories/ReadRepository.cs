using System.Linq.Expressions;
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
        /// Retrieves a paginated list of entities based on the specified identifier and field using reflection. 
        /// Generates a generic conditional expression in a lambda form according to the given field name.
        /// </summary>
        /// <private-method>_GetExpression</private-method>
        /// <param name="id">The unique identifier to filter entities.</param>
        /// <param name="field">The field name for which the conditional expression is generated.</param>
        /// <param name="skip">The number of entities to skip before starting to return results.</param>
        /// <param name="take">The maximum number of entities to return.</param>
        /// <param name="tracking">Specifies whether change tracking should be enabled (default is true).</param>
        /// <returns>A paginated result containing the total count of entities and a subset based on the specified conditions.</returns>
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

        /// <summary>
        /// Retrieves a list of entities based on the specified identifier and field using reflection. 
        /// Generates a generic conditional expression in a lambda form according to the given field name.
        /// </summary>
        /// <private-method>_GetExpression</private-method>
        /// <param name="id">The unique identifier to filter entities.</param>
        /// <param name="field">The field name for which the conditional expression is generated.</param>
        /// <param name="tracking">Specifies whether change tracking should be enabled (default is true).</param>
        /// <returns>A list of entities matching the specified conditions.</returns>
        public List<T> GetAllById(Guid id, string field, bool tracking = true)
        {
            var expression = _GetExpression(id, field);

            var query = Table.AsQueryable().Where(t => !t.IsDeleted).Where(expression);

            if (!tracking)
                query = query.AsNoTracking();

            return query.ToList();

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
