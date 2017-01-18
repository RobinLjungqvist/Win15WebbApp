using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using WebbApp.ViewModels;
using System.Security.Claims;
using WebbApp.Mockup.Repo;

namespace WebbApp.Controllers   
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        public MockupUserRepo userRepo;
        // GET: Account
        [HttpGet]
        public ActionResult Login()
        {
            var User = new UserViewModel();
            return View(User);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }

            var user = userRepo.LoginUser(model.Email, model.Password);


            if (user != null)
            {
                var identity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Email, model.Email),
                    new Claim("UserID", user.)
                }, "ApplicationCookie");

            }

            
        }

        public string GetIdFromClaims()
        {
            var identity = (ClaimsIdentity)User.Identity;

            var id = identity.FindFirst("UserID");

            return id.ToString();
        }
    }


}