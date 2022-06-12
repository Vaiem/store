using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Store.Models
{
    public class Product
    {
        
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Categoria { get; set; }
        public ICollection<productsToOder> oders { get; set; } = new List<productsToOder>();
    }
}
