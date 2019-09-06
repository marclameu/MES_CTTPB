using System;
using System.Collections.Generic;

namespace CTTPB.MESCDP.DOMAIN
{
    public class PaginationInfo<T>
    {
        public PaginationInfo(int page, int pageSize, string sortIndex, string sortDirection, object userData)
        {
            Page = page;
            PageSize = pageSize;
            SortIndex = sortIndex;
            SortDirection = sortDirection;
            UserData = userData;
        }

        public PaginationInfo(int page, int pageSize, string sortIndex, string sortDirection)
        {
            Page = page;
            PageSize = pageSize;
            SortIndex = sortIndex;
            SortDirection = sortDirection;
            UserData = null;
        }

        public long Total { get; set; }
        public object UserData { get; set; }

        public int PageSize { get; set; }
        public int Page { get; set; }

        public int NumPages
        {
            get
            {
                if (PageSize == 0)
                    PageSize = 1;
                var numPages = (float)Total / PageSize;
                return (int)Math.Ceiling(numPages);
            }
        }

        public string SortIndex { get; set; }
        public string SortDirection { get; set; }

        public IList<T> List { get; set; }
    }
}
