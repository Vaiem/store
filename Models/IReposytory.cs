using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Models
{
    public interface IReposytory
    {
        IQueryable<Product> products { get; }

        void AddProduct(Product prod);

        void UpdateProduct(Product upProduct);

        void DeletProduct(int ProdId);

    }
}
