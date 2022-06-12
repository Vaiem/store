using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Models
{
   public interface IOderReposytory
    {
          IQueryable<Oder> AllOders { get; }
          void SaveOder(Oder oder);
    }
}
