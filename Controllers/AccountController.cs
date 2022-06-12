using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Store.Models;

namespace Store.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private UserManager<IdentityUser> userManager;
        private SignInManager<IdentityUser> signInManager;

        public AccountController(UserManager<IdentityUser> useMg,SignInManager<IdentityUser> SignInManager)
        {
            userManager = useMg;
            signInManager = SignInManager;
        }
          

        [AllowAnonymous]
        public IActionResult Login()
        {
            
            return View( new LoginView());
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginView logView)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = await userManager.FindByNameAsync(logView.Name);
                if (user != null)
                {
                    await signInManager.SignOutAsync();
                    if ((await signInManager.PasswordSignInAsync(user, logView.Password, false, false)).Succeeded)
                    {
                        return Redirect("~/Admin/AllProduct");

                    }
                }
            }
            else
            {
                ModelState.AddModelError("", "Проверьте правильность введеных данных");
            }
                return View();
            
        }



        public async Task<IActionResult> LogOut()
        {
            await signInManager.SignOutAsync();
            return Redirect("/");
        }
           


    }
}