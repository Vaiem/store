using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Store.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

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
        public IActionResult AddProduct(Product sasa)
        {
            reposytory.AddProduct(sasa);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int productId)
        {
            var upprod = reposytory.products.FirstOrDefault(o => o.ProductId == productId);
            return View(upprod);
        }
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                reposytory.UpdateProduct(product);
                return RedirectToAction("AllProduct");

            }
            else
            {
                return View();
            }
            
        }
        [HttpPost]
        public IActionResult Delet(int ProdId)
        {
            reposytory.DeletProduct(ProdId);
            return RedirectToAction("AllProduct");
        }
    }
}