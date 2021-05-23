using BlogProject.CORE.Entity.Service;
using BlogProject.MODEL.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BlogProject.WEBUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly ICoreService<User> _us;

        public AccountController(ICoreService<User> us)
        {
            _us = us;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(User user)
        {
         
            if(  _us.Any(x => x.EmailAddress == user.EmailAddress && x.Password == user.Password))
                {
                User logged = _us.GetByDefault(x => x.EmailAddress == user.EmailAddress && x.Password == user.Password);
                   var claims = new List<Claim>()
                   {
                       new Claim("ID", logged.ID.ToString()),
                       new Claim(ClaimTypes.Name, logged.FirstName),
                        new Claim(ClaimTypes.Name, logged.LastName),
                         new Claim(ClaimTypes.Name, logged.EmailAddress),
                          new Claim(ClaimTypes.Name, logged.ImageURL),

                   };
                var userIdentity = new ClaimsIdentity(claims, "login");
                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Index", "Home");
                }
               

            return View(user);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
