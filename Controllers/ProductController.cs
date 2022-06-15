using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Store.Models;
using Microsoft.AspNetCore.Http;
using System.Threading;

namespace Store.Controllers
{
    public class ProductController : Controller
    {
        private IReposytory reposytory;
        private int ElementPage = 1;
        private Cart Carts;
        public ProductController(IReposytory repos, Cart serviceCart)
        {
            reposytory = repos;
            Carts = serviceCart;
        }
        public async Task<IActionResult> Home(string categoria, int ProductPage = 1) => View(new viewProduct {
            prod = await Task.Run(()=> reposytory.products.
              Where(o => categoria == null || o.Categoria == categoria).
              Skip((ProductPage - 1) * ElementPage).
              Take(ElementPage)),
            PageInfo = new PageInfo
            {
                AllCountElemnts = reposytory.products.Where(o => categoria == null || o.Categoria == categoria).Count(),
                PerPage = ElementPage,
                CurrentPage = ProductPage

            },
            CurrentCategoria = categoria,

            AllProd = await Task.Run(() => reposytory.products)

        });



       

        public ViewResult Cart(string url)
        {
            var cartResult = Carts;
            return View(cartResult);
        }
        public IActionResult AddCart(int ProductId)
        {
            var prod = reposytory.products.FirstOrDefault(o => o.ProductId == ProductId);
            if (prod != null)
            {
                Carts.AddProductInCart(prod);
            }
            return RedirectToAction("Cart", new { url = ProductId.ToString() });
        }
        public IActionResult RemoveProductCart(int id)
        {
            var prod = reposytory.products.FirstOrDefault(o => o.ProductId == id);
            if (prod != null)
            {
                Carts.RemoveProductInCart(id);
            }
            return RedirectToAction("Cart", new { url = id.ToString() });
        }


        

    }
}