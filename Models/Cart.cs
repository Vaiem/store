using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Models
{
    public class Cart
    {
        private List<Product> products = new List<Product>();

      
       

        public virtual void AddProductInCart(Product prod)
        {
           
            products.Add(prod);
        }
        public virtual void RemoveProductInCart(int id)
        {
            products.RemoveAll(o => o.ProductId == id);
        }

        public virtual IEnumerable<Product> lines => products;
        public virtual decimal ResultPrice => products.Sum(o => o.Price);
    }
}
