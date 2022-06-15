using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Store.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Threading;

namespace Store.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {

        private IReposytory reposytory { get; set; }

        public AdminController(IReposytory repos)
        {
            reposytory = repos;
        }


        public IActionResult AllProduct()
        {

            return View(reposytory.products.ToArray());
        }

        public ViewResult AddProduct() => View();
        [HttpPost]
        public async Task<IActionResult> AddProduct(Product sasa)
        {
            int res2 = Thread.CurrentThread.ManagedThreadId;
           
               
            await  reposytory.AddProductAsync(sasa);
            int res3 = Thread.CurrentThread.ManagedThreadId;
            return RedirectToAction("AllProduct");
        }

        [HttpGet]
        public IActionResult Edit(int productId)
        {
            var upprod = reposytory.products.FirstOrDefault(o => o.ProductId == productId);
            return View(upprod);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Product product)
        {
            if (ModelState.IsValid)
            {
              await  reposytory.UpdateProductAsync(product);
                return RedirectToAction("AllProduct");

            }
            else
            {
                return View();
            }
            
        }
        [HttpPost]
        public async Task<IActionResult> Delet(int ProdId)
        {
           await reposytory.DeletProductAsync(ProdId);
           return RedirectToAction("AllProduct");
        }
    }
}