using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Store.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Store
{
    public class Startup
    {
        
        public IConfiguration config { get; }
        public Startup(IConfiguration configuration)
        {
            config = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer( config["ConnectionStrings:DefaultConnection"]));
            services.AddDbContext<IdentityUserDbContext>(options =>
            options.UseSqlServer(config["StoreIdentity:ConnectionStrings"]));

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<IdentityUserDbContext>()
                .AddDefaultTokenProviders();
            services.AddTransient<IReposytory, Repos>();
            services.AddScoped<Cart>(serv => CartSession.GetCart(serv));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IOderReposytory, OderReposytory>();

           
            services.AddMvc();
            services.AddMemoryCache();
            services.AddSession();
        }

        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            
            app.UseStaticFiles();
            app.UseSession();
            app.UseAuthentication();
            app.UseMvc(route => {
                route.MapRoute( name:null,
                    template: "{categoria}/{ProductPage:int}",
                    defaults:new { controller = "Product", action = "Home"  }
                    );
              
             
            route.MapRoute(name: null, 
                template:"{controller=Product}/{action=Home}/{id?}");
                 });
            SeedData.Seed(app);
            SeedDataDbIdentity.SeedDBIdentity(app);
        }
    }
}
