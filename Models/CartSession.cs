using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
namespace Store.Models
{
    public class CartSession : Cart 
    {
        public static Cart GetCart(IServiceProvider service)
        {
            var session = service.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            CartSession cart = session.GetCart<CartSession>("Cart") ?? new CartSession();
            cart.Session = session;
            return cart;
        }
        [JsonIgnore]
        ISession Session { get; set; }

        public override void AddProductInCart(Product prod)
        {
            base.AddProductInCart(prod);
            Session.SetJson("Cart", this);
        }

        public override void RemoveProductInCart(int id)
        {
            base.RemoveProductInCart(id);
            Session.SetJson("Cart", this);
        }

    }
}
