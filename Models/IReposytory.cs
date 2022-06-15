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
        Task AddProductAsync (Product prod);

        Task UpdateProductAsync(Product upProduct);

        Task DeletProductAsync(int ProdId);

    }
}
