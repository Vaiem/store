using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Store.Models;

namespace Store.Components
{
    public class NavigationViewComponent : ViewComponent
    {
        private IReposytory repos {get;set;}
        public NavigationViewComponent (IReposytory reposytory)
        {
            repos = reposytory;
        }
        public IViewComponentResult Invoke()
        {
            ViewData["categoria"] = RouteData?.Values["categoria"];
            return View(repos.products.Select(o => o.Categoria).Distinct().OrderBy(o => o));
        }
    }
}
