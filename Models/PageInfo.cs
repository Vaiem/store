using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Models
{
    public class PageInfo
    {
        public int CurrentPage { get; set; }
        public int AllCountElemnts { get; set; }
        public int PerPage { get; set; }

        public int AllPage => (int)Math.Ceiling((decimal)AllCountElemnts / PerPage);

    }
}
