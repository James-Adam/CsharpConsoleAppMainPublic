using System.Collections.Generic;
using System.Linq;

namespace AuthenticatedSchoolSystem.Back_End.Services
{
    public class PagedList<T> : List<T>, IPagedList<T>
    {
        private readonly int pageIndex;
        private readonly int pageSize;

        public PagedList(object query1, int pageIndex, int pageSize)
        {
            Query = query1;
            this.pageIndex = pageIndex;
            this.pageSize = pageSize;
        }

        public PagedList(IQueryable<T> source, int pageIndex, int pageSize, int totalCount)
        {
            int total = source.Count();
            TotalCount = total;
            TotalPages = total / pageSize;

            if (total % pageSize > 0)
            {
                TotalPages++;
            }

            PageSize = pageSize;
            PageIndex = pageIndex;
            AddRange(source.Skip(pageIndex * pageSize).Take(pageSize));
        }

        public PagedList(IEnumerable<T> source, int pageIndex, int pageSize, int totalCount)
        {
            TotalCount = totalCount;
            TotalPages = totalCount / pageSize;

            if (TotalCount % pageSize > 0)
            {
                TotalPages++;
            }

            PageSize = pageSize;
            PageIndex = pageIndex;
            AddRange(source);
        }

        public int TotalCount { get; }
        public int TotalPages { get; }
        public int PageSize { get; private set; }
        public int PageIndex { get; private set; }
        public object Query { get; }
        public int criteria1 { get; }
        public int criteria2 { get; }
    }
}