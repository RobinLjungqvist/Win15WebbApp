using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebbApp.DAL.Repositories;
using WebbApp.DAL.Interfaces;
using WebbApp.DAL.DB.Models;

namespace WebbApp.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        private IRepository<ApplicationUser> userRepo;

        public UserController()
        {
            this.userRepo = new UserRepository();
        }

        // GET: Admin/User
        public ActionResult Index()
        {
            return View(userRepo.GetAll().ToList());
        }

        [HttpGet]
        public ActionResult Edit(Guid userId)
        {
            return View(userRepo.GetById(userId));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ApplicationUser user)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrWhiteSpace(user.UserName) || 
                    string.IsNullOrWhiteSpace(user.Password) || 
                    string.IsNullOrWhiteSpace(user.Email)    || 
                    string.IsNullOrWhiteSpace(user.FirstName)||
                    string.IsNullOrWhiteSpace(user.LastName))
                {
                    ModelState.AddModelError("error", "Error: username, password or name is empty!");
                    return View(user);
                }
                userRepo.Update(user);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(Guid userId)
        {
            userRepo.Delete(userId);
            return RedirectToAction("Index");
        }

    }
}