using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IDSkills.Data
{
    public class DataPager<T>
    {
        public const int DefaultPageSize = 3;

        private IQueryable<T> qData = null;
        private List<T> iData;
        private List<T> _currPageItems;
        private int _pageIndex = 1;
        private int _pageSize = DefaultPageSize;

        public DataPager(List<T> items, int pageSize = DefaultPageSize, int initialIndex = 1)
        {
            iData = new List<T>();
            if (items?.Count > 0)
                iData.AddRange(items);
            qData = iData.AsQueryable();
            PageSize = pageSize;
            PageIndex = initialIndex;
        }
        public DataPager(IQueryable<T> items, int pageSize = DefaultPageSize, int initialIndex = 1)
        {
            qData = items ?? new List<T>().AsQueryable();
            PageSize = pageSize;
            PageIndex = initialIndex;
        }
        protected IQueryable<T> All => qData;
        public int PageIndex
        {
            get { return _pageIndex; }
            private set
            {
                int newValue = value == 0 ? _pageIndex : value;
                int totPages = TotalPages;
                if (newValue < 1 || newValue > totPages)
                    throw new ArgumentOutOfRangeException($"Page {newValue} does not exist. Total pages={totPages}");
                _pageIndex = newValue;
            }
        }
        public int PageSize
        {
            get => _pageSize;
            private set
            {
                _pageSize = value < 0 ? DefaultPageSize : value;
            }
        }

        public int TotalPages => (int)Math.Ceiling(All.Count() / (double)PageSize);

        public IEnumerable<T> Page(int pageIndex = 0)
        {
            int curr = PageIndex;
            PageIndex = pageIndex;
            if (curr != PageIndex)
                _currPageItems = All.Skip((PageIndex - 1) * PageSize).Take(PageSize).ToList();
            return _currPageItems;
        }
        public IEnumerable<T> Current() => Page(PageIndex);
        public IEnumerable<T> Previous() => HasPrevious ? Page(PageIndex - 1) : null;
        public IEnumerable<T> Next() => HasNext ? Page(PageIndex + 1) : null;
        public IEnumerable<T> First() => Page(1);
        public IEnumerable<T> Last() => Page(TotalPages);

        public async Task<IEnumerable<T>> PageAsync(int pageIndex = 0)
        {
            int curr = PageIndex;
            PageIndex = pageIndex;
            if (curr != PageIndex || _currPageItems == null)
                _currPageItems = await All.Skip((PageIndex - 1) * PageSize).Take(PageSize).ToListAsync();
            return _currPageItems;
        }
        public async Task<IEnumerable<T>> CurrentAsync() => await PageAsync(PageIndex);
        public async Task<IEnumerable<T>> PreviousAsync() => HasPrevious ? await PageAsync(PageIndex - 1) : null;
        public async Task<IEnumerable<T>> NextAsync() => HasNext ? await PageAsync(PageIndex + 1) : null;
        public async Task<IEnumerable<T>> FirstAsync() => await PageAsync(1);
        public async Task<IEnumerable<T>> LastAsync() => await PageAsync(TotalPages);

        public bool HasPrevious => PageIndex > 1;
        public bool HasNext => PageIndex < TotalPages;

        public static async Task<DataPager<T>> CreateAsync(IQueryable<T> data, int pageIndex, int pageSize)
        {
            var count = await data.CountAsync();
            var items = await data.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            return new DataPager<T>(items, pageIndex, pageSize);
        }
    }
}
