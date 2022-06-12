using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public void AddProduct (Product prod)
        {
           
            Db.Products.Add(prod);
            Db.SaveChanges();
        }

        public void UpdateProduct(Product upProduct)
        {
            var prod = Db.Products.FirstOrDefault(o => o.ProductId == upProduct.ProductId);
            if (prod != null)
            {
               prod.Name = upProduct.Name;
                prod.Description = upProduct.Description;
                prod.Categoria = upProduct.Categoria;
                prod.Price = upProduct.Price;
                Db.SaveChanges();
            }
        }

        public void DeletProduct(int ProdId)
        {
            Db.Products.Remove(Db.Products.FirstOrDefault(o => o.ProductId == ProdId));
            Db.SaveChanges();
        }



    }
}
