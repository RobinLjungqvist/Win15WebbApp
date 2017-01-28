using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static WebbApp.App_Start.IdentityConfig;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using WebbApp.ViewModels;
using WebbApp.DAL.DB.Models;
using WebbApp.DAL;
using System.Web.ModelBinding;
using System.Web.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.Owin;

namespace WebbApp.Utilities
{
    //By refactorisering of register and create new user
    //TODO: Send in HttpContext from Controller
    public class CreateUser
    {
        private ApplicationSignInManager signInManager;
        private ApplicationUserManager userManager;
        private ApplicationRoleManager roleManager;

        //public ApplicationSignInManager SignInManager
        //{
        //    get { return signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>(); }
        //    private set { signInManager = value; }
        //}

        //public ApplicationUserManager UserManager
        //{
        //    get { return userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>(); }
        //    private set { userManager = value; }
        //}

        //public ApplicationRoleManager RoleManager
        //{
        //    get { return roleManager ?? HttpContext.GetOwinContext().Get<ApplicationRoleManager>(); }
        //    private set { roleManager = value; }
        //}

        //public async void createNewUser(RegisterViewModel model)
        //{
        //    var user = new ApplicationUser
        //    {
        //        Id = Guid.NewGuid().ToString(),
        //        Password = model.Password,
        //        FirstName = model.FirstName,
        //        LastName = model.LastName,
        //        UserName = model.UserName,
        //        Email = model.Email,
        //        City = model.City,
        //        IsAdmin = model.UserRole == RegisterViewModel.UserRoles.Admin,
        //        UserRole = model.UserRole.ToString(),
        //        Region = model.Region.ToString()
        //    };

        //    var result = await UserManager.CreateAsync(user, model.Password);

        //    if (result.Succeeded)
        //    {
        //        await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

        //        var rm = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationContext()));

        //        string userString = model.UserRole == RegisterViewModel.UserRoles.User ? "User" : "Admin";

        //        if (!rm.RoleExists(userString))
        //        {
        //            rm.Create(new IdentityRole(userString));
        //        }

        //        if (!UserManager.IsInRole(user.Id, userString))
        //        {
        //            UserManager.AddToRole(user.Id, userString);
        //        }
        //    }
        //}
    }
}