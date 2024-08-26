using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSUSAPP.Common.DTO
{
    public class paginationDTO
    {
        public int pageNumber { get; set; } = 1;
        public int pageSize { get; set; } = 10;
    }

    public class PaginatedResult<T>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
        public List<T> Items { get; set; }
    }
}
