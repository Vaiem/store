using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;

namespace Store.Models
{
    public class Repos : IReposytory
    {
        private ApplicationDbContext Db;
        public  Repos(ApplicationDbContext dbContext)
        {
            Db = dbContext;
        }
        public IQueryable<Product> products => Db.Products;

        public void AddProduct(Product prod)
        {

             Db.Products.Add(prod);
            int res2 = Thread.CurrentThread.ManagedThreadId;
             Db.SaveChanges();
        }

        public async Task AddProductAsync (Product prod)
        {
            
            await Db.Products.AddAsync(prod);
            int res2 = Thread.CurrentThread.ManagedThreadId;
            await Db.SaveChangesAsync();
        }

        public async Task UpdateProductAsync(Product upProduct)
        {
            var prod = await Task.Run(()=> Db.Products.FirstOrDefault(o => o.ProductId == upProduct.ProductId));
            if (prod != null)
            {
               prod.Name = upProduct.Name;
                prod.Description = upProduct.Description;
                prod.Categoria = upProduct.Categoria;
                prod.Price = upProduct.Price;
                await Db.SaveChangesAsync();
            }
            
        }

        public async Task DeletProductAsync(int ProdId)
        {
          await Task.Run(()=>  Db.Products.Remove(Db.Products.FirstOrDefault(o => o.ProductId == ProdId)));
           await Db.SaveChangesAsync();
            
        }



    }
}
