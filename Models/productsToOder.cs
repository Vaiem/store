using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Models
{
    public class productsToOder
    {
        public int ProductId { get; set; }
        public  Product ProductQ { get; set; }

        public int id { get; set; }
        public Oder OderQ { get; set; }
    }
}
