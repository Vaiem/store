using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Store.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;

namespace Store.Controllers
{
    public class OdersController : Controller
    {
       private IOderReposytory odersContextDb { get; set; }
        private  Cart cart { get; set; }
        public OdersController(IOderReposytory oderDb, Cart serviceCart)
        {
            odersContextDb = oderDb;
            cart = serviceCart;
        }
        [HttpGet]
        public IActionResult OdersAdd() => View(new Oder());
        
            
        
        [HttpPost]
        public IActionResult OdersAdd(Oder oder)
        {
            
            if (cart.lines.Count()==0)
            {
                ModelState.AddModelError("", "список пуст");
            }
            if (ModelState.IsValid)
            {
                foreach (var item in cart.lines)
                {

                    var productsOder = new productsToOder { OderQ = oder, ProductQ = item };
                    oder.products.Add(productsOder);
                }
                odersContextDb.SaveOder(oder);
                return Redirect("~/Oders/AllOders ");
            }
            return View();
        }

        [Authorize]
        public ActionResult AllOders()
       {
            HttpContext.Session.Remove("Cart");
            return View(odersContextDb.AllOders.Where(o=>!o.Shipped).ToList());
       }
        
        [HttpPost]
        [Authorize]
        public IActionResult MarkShipperd(int id)
        {
            var oder =odersContextDb.AllOders.FirstOrDefault(o => o.id == id);
            oder.Shipped = true;
            odersContextDb.SaveOder(oder);
            return RedirectToAction("AllOders");
        }
         
    }
}