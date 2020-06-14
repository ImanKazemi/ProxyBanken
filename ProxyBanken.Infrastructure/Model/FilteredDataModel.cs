using System.Collections.Generic;

namespace ProxyBanken.Infrastructure.Model
{
    public class FilteredDataModel<T>
    {
        public List<T> Result { get; set; }
        public int FilteredCount { get; set; }
        public int Total { get; set; }

        public FilteredDataModel(List<T> result, int filteredCount, int totalCount)
        {
            Result = result;
            FilteredCount = filteredCount;
            Total = totalCount;
        }
    }
}
