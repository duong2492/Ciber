using System.Collections.Generic;

namespace Ciber.Models.Paging
{
    public class PagedResult<T>
    {
        public long totalSum { get; set; }
        public long totalCount { get; set; }
        public IList<T> items { get; set; }
     
    }
}
