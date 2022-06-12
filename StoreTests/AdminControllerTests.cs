using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Moq;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Store.Models;
using Store.Controllers;

namespace StoreTests
{
    public class AdminControllerTests
    {
        [Fact]
        public void EditTest()
        {

            Product product = new Product {Name ="Nintendo",ProductId = 1 };

            var mock = new Mock<IReposytory>();
            mock.SetupGet(o => o.products).Returns((new Product[] {
                new Product {Name = "ps",ProductId=1 },
                new Product {Name ="Xbox",ProductId = 2}
            }).AsQueryable());


            AdminController target = new AdminController(mock.Object);

            IActionResult result = target.Edit(product);

            Assert.Equal("AllProduct", (result as RedirectToActionResult).ActionName);

            


        }

        [Fact]
        public void DeletTest()
        {

            var mock = new Mock<IReposytory>();

            mock.SetupGet(o => o.products).Returns((new Product[] {
                new Product {Name ="ps",ProductId=1 },
                new Product {Name = "xbox",ProductId = 2 } })
                .AsQueryable());

            AdminController target = new AdminController(mock.Object);

            target.Delet(2);

            mock.Verify(o => o.DeletProduct(2));


        }

        [Fact]
        public void AllProductTest()
        {

            var mock = new Mock<IReposytory>();
            mock.SetupGet(o => o.products).Returns((new Product[] {
                new Product { Name = "ps", ProductId = 1 },
                new Product { Name = "xbox", ProductId = 2 } })
                .AsQueryable());

            AdminController target = new AdminController(mock.Object);

            var action = target.AllProduct();

            var result = ((action as ViewResult)?.ViewData.Model as IEnumerable<Product>)?.ToArray();

            Assert.Equal(2, result.Length);
            Assert.Equal("ps", result[0].Name);


        }
        
    }

}
