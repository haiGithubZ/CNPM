using System.Collections.Generic;

namespace Jhipster.Service.Utilities
{
    public class PagedList<T> where T : class
    {
        public PagedList()
        {
            Data = new List<T>();
        }

        public PagedList(IEnumerable<T> _Data, int _TotalCount)
        {
            Data = _Data;
            TotalCount = _TotalCount;
        }
        public IEnumerable<T> Data { get; set; }
        public int TotalCount { get; set; }
    }
}
