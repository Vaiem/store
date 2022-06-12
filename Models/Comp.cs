using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Models
{
    public class Comp<T> : IComparer<T>
    {
        public int Compare(T x, T y)
        {
            throw new NotImplementedException();
        }
    }
}
