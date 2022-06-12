using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Models
{
    public class viewProduct
    {
       public PageInfo PageInfo { get; set; }

        public IEnumerable<Product> prod { get; set; }

        public IEnumerable<Product> AllProd { get; set; }

            public string CurrentCategoria { get; set; }

        public List<string> categories { get
            {
                var AllCategories = new List<string> {"All"};
                foreach (var item in AllProd)
                {
                    if ((AllCategories.FirstOrDefault(o => o == item?.Categoria))==null)
                    {
                        AllCategories.Add(item?.Categoria);
                    }

                }
                return AllCategories;
            }
        }
       
    }
}
