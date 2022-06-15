using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace Store.Models
{
    public class OderReposytory : IOderReposytory
    {
        private ApplicationDbContext context { get; set; }
        public OderReposytory(ApplicationDbContext DbCont)
        {
            context = DbCont;
        }
        public IQueryable<Oder> AllOders => context.OdersDB.Include(o => o.products).ThenInclude(o => o.ProductQ);
         
        public async Task SaveOder(Oder oder)
        {
            context.AttachRange(oder.products.Select(o => o.ProductQ));
            if (oder.id == 0)
            {
               
                
               await context.AddAsync(oder);
            }
          await context.SaveChangesAsync();
               
        }
    }
}
