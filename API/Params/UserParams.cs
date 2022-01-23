using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Pagination;

namespace API.Params
{
    public class UserParams : PaginationParams
    {
        public int CurrentUserId { get; set; }
      

    }
}