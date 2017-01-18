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

        public AccountController()
        {
            this.userRepo = new MockupUserRepo();
        }
        // GET: Account
        [HttpGet]
        public ActionResult Login()
        {
            var x = GetIdFromClaims();
            var UserModel = new UserViewModel();
            return View(UserModel);
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


            if (user.UserID != null)
            {
                var identity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.UserID.ToString()),
                    new Claim(ClaimTypes.Email, model.Email),
                    new Claim("UserID", user.UserID.ToString())
                }, "ApplicationCookie");

                var ctx = Request.GetOwinContext();
                var authManager = ctx.Authentication;

                authManager.SignIn(identity);
                
            }

            model.id = user.UserID;

            return View(model);
        }

        public string GetIdFromClaims()
        {
            var identity = (ClaimsIdentity)User.Identity;

            var id = identity.FindFirst("UserID");

            return id.ToString();
        }

        public ActionResult Logout()
        {
            var ctx = Request.GetOwinContext();
            var authM = ctx.Authentication;
            authM.SignOut("ApplicationCookie");

            return RedirectToAction("Login", "Account");
        }
    }


}