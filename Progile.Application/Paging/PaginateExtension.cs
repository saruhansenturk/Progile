namespace Progile.Application.Paging;

public static class PaginateExtension
{
    public static IQueryable<T> Paginate<T>(this IQueryable<T> source, int skip, int take)
    {
        source = source.Skip(skip).Take(take);

        return source;
    }
}