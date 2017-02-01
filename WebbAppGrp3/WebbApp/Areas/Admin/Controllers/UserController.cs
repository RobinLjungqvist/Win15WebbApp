using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebbApp.DAL.Repositories;
using WebbApp.DAL.Interfaces;
using WebbApp.DAL.DB.Models;
using WebbApp.Areas.Admin.ViewModels;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using WebbApp.DAL;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.Owin;
using static WebbApp.App_Start.IdentityConfig;
using System.Collections.Generic;

namespace WebbApp.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private IRepository<ApplicationUser> userRepo;
        private IRepository<Region> regionRepo;
        private IRepository<City> cityRepo;
        private IRepository<Item> itemRepo;

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

        public UserController()
        {
            this.userRepo = new UserRepository();
            this.regionRepo = new RegionRepository();
            this.cityRepo = new CityRepository();
            this.itemRepo = new ItemRepository();
        }

        // GET: Admin/User
        public ActionResult Index()
        {
            List<ApplicationUser> au = new List<ApplicationUser>();
            foreach (var item in userRepo.GetAll().ToList())
            {
                if (item.CityID != null && item.RegionId != null)
                {
                    item.Region = regionRepo.GetById(new Guid(item.RegionId));
                    item.City = cityRepo.GetById(new Guid(item.CityID));
                }
                au.Add(item);
            }
            return View(au);
        }

        [HttpGet]
        public ActionResult Edit(Guid userId)
        {
            ApplicationUser user = userRepo.GetById(userId);
            UserViewModel model = new UserViewModel();
            model.UserId = user.Id;
            model.Email = user.Email;
            model.FirstName = user.FirstName;
            model.LastName = user.LastName;
            model.Password = user.Password;
            model.UserName = user.UserName;
            model.UserRole = (UserViewModel.UserRoles)Enum.Parse(typeof(UserViewModel.UserRoles), user.UserRole, true);
            model.Cities = cityRepo.GetAll().ToList();
            model.SelectedCityId = new Guid(user.CityID);
            model.Regions = regionRepo.GetAll().ToList();
            model.SelectedRegionId = new Guid(user.RegionId);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserViewModel model)
        {
            ModelState.Remove("City.CityName");
            ModelState.Remove("Region.RegionName");
            if (ModelState.IsValid)
            {
                if (string.IsNullOrWhiteSpace(model.UserName) ||
                    string.IsNullOrWhiteSpace(model.Password) ||
                    string.IsNullOrWhiteSpace(model.Email) ||
                    string.IsNullOrWhiteSpace(model.FirstName) ||
                    string.IsNullOrWhiteSpace(model.LastName))
                {
                    ModelState.AddModelError("error", "Error: username, password or name is empty!");
                    return View(model);
                }

                ApplicationUser user = new ApplicationUser();
                user.Id = model.UserId;
                user.UserRole = model.UserRole.ToString();
                user.UserName = model.UserName;
                user.Password = model.Password;
                user.LastName = model.LastName;
                user.FirstName = model.FirstName;
                user.Email = model.Email;
                user.CityID = model.City.CityId.ToString();
                user.RegionId = model.Region.RegionId.ToString();

                userRepo.Update(user);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(Guid userId)
        {
            List<Item> items = itemRepo.GetByUserId(userId);
            foreach (var item in items)
            {
                foreach (var image in item.Images)
                {
                    var filePath = Server.MapPath(image.Path);
                    if (System.IO.File.Exists(filePath))
                    {
                        System.IO.File.Delete(filePath);
                    }
                }
                itemRepo.Delete(item.ItemID);
            }
            userRepo.Delete(userId);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Create()
        {
            UserViewModel uvm = new UserViewModel();
            uvm.Regions = regionRepo.GetAll().ToList();
            uvm.Cities = cityRepo.GetAll().ToList();
            return View(uvm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(UserViewModel model)
        {
            ModelState.Remove("City.CityName");
            ModelState.Remove("Region.RegionName");
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
                    UserRole = model.UserRole.ToString(),
                    RegionId = model.Region.RegionId.ToString(),
                    CityID = model.City.CityId.ToString()
                };

                var result = await UserManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    //await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

                    var rm = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationContext()));

                    string userString = model.UserRole == UserViewModel.UserRoles.User ? "User" : "Admin";

                    if (!rm.RoleExists(userString))
                    {
                        rm.Create(new IdentityRole(userString));
                    }

                    if (!UserManager.IsInRole(user.Id, userString))
                    {
                        UserManager.AddToRole(user.Id, userString);
                    }
                    return RedirectToAction("Index", "User", new { area = "Admin" });
                }
                AddErrors(result);
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Index", "Home", new { area = "" });
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
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
            return RedirectToAction("Index", "Home", new { area = "" });
        }
    }
}
