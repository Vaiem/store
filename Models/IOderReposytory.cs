using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;

namespace Store.Models
{
   public interface IOderReposytory
    {
          IQueryable<Oder> AllOders { get; }
          Task SaveOder(Oder oder);
    }
}
