﻿using System;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using System.Threading.Tasks;
using static WebbApp.App_Start.IdentityConfig;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity.EntityFramework;
using WebbApp.ViewModels;
using WebbApp.DAL.DB.Models;
using WebbApp.DAL;

namespace WebbApp.Controllers   
{
    public class AccountController : Controller
    {
        private ApplicationSignInManager signInManager;
        private ApplicationUserManager userManager;
        private ApplicationRoleManager roleManager;

        public ApplicationSignInManager SignInManager
        {
            get { return signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>(); }
            private set { signInManager = value; }
        }

        public ApplicationUserManager UserManager
        {
            get { return userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>(); }
            private set { userManager = value; }
        }

        public ApplicationRoleManager RoleManager
        {
            get { return roleManager ?? HttpContext.GetOwinContext().Get<ApplicationRoleManager>(); }
            private set { roleManager = value; }
        }

        // GET: Account
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = await SignInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, shouldLockout: false);
            switch (result)
            {
                case SignInStatus.Success:

                    if (returnUrl == null)
                    {
                        returnUrl = (String) TempData["tmpReturnUrl"];
                    }
                    return RedirectToLocal(returnUrl);
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Invalid login attempt.");
                    var tmp = TempData["tmpReturnUrl"];
                    if (tmp == null)
                        TempData["tmpReturnUrl"] = returnUrl;
                    else
                        TempData["tmpReturnUrl"] = tmp;
                    return View(model);
            }
        }

        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    Id = Guid.NewGuid().ToString(),
                    Password = model.Password,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    UserName = model.UserName,
                    Email = model.Email,
                    City = model.City,
                    //IsAdmin = model.UserRole == RegisterViewModel.UserRoles.Admin,
                    UserRole = "User",
                    Region = model.Region
                };

                var result = await UserManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

                    var rm = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationContext()));

                    string userString = user.UserRole;

                    if (!rm.RoleExists(userString))
                    {
                        rm.Create(new IdentityRole(userString));
                    }

                    if (!UserManager.IsInRole(user.Id, userString))
                    {
                        UserManager.AddToRole(user.Id, userString);
                    }

                    return RedirectToAction("Index", "Home");
                }
                AddErrors(result);
            }
            return View(model);
        }

        [HttpGet]
        //[ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Index", "Home", new { area = "" });
        }

        private IAuthenticationManager AuthenticationManager
        {
            get { return HttpContext.GetOwinContext().Authentication; }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}