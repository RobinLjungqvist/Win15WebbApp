using System;
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
using WebbApp.DAL.Interfaces;
using WebbApp.DAL.Repositories;
using System.Collections.Generic;

namespace WebbApp.Controllers
{
    public class AccountController : Controller
    {
        private ApplicationSignInManager signInManager;
        private ApplicationUserManager userManager;
        private ApplicationRoleManager roleManager;

        private IRepository<Region> regionRepo;
        private IRepository<City> cityRepo;

        public AccountController()
        {
            this.regionRepo = new RegionRepository();
            this.cityRepo = new CityRepository();
        }

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
                        returnUrl = (String)TempData["tmpReturnUrl"];
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
            RegisterViewModel rvm = new RegisterViewModel();
            rvm.Cities = new List<City>(cityRepo.GetAll());
            rvm.Regions = new List<Region>(regionRepo.GetAll());
            return View(rvm);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            ModelState.Remove("Cities");
            ModelState.Remove("Regions");
            ModelState.Remove("UserRole");
            ModelState.Remove("City.CityName");
            ModelState.Remove("Region.RegionName");
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser()
                {
                    Id = Guid.NewGuid().ToString(),
                    Password = model.Password,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    UserName = model.UserName,
                    Email = model.Email,
                    UserRole = "User",
                    RegionId = model.Region.RegionId.ToString(),
                    CityID = model.City.CityId.ToString()
                };

                var result = await UserManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {

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

                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);



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