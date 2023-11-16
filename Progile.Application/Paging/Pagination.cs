namespace Progile.Application.Paging
{
    public class Pagination<T>
    {
        public int TotalCount { get; set; }
        public List<T> Items { get; set; }

        public Pagination(int totalCount, List<T> items)
        {
            TotalCount = totalCount;
            Items = items;
        }

        public Pagination()
        {
        }
    }
}
