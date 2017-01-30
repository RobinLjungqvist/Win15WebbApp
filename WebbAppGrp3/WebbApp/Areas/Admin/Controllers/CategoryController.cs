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
    public class CategoryController : Controller
    {
        private IRepository<Category> repo;

        public CategoryController()
        {
            this.repo = new CategoryRepository();
        }

        // GET: Admin/Category
        public ActionResult Index()
        {
            return View(repo.GetAll().ToList());
        }

        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            return View(repo.GetById(id));
        }

        [HttpPost]
        public ActionResult Edit(Category model)
        {
            if (ModelState.IsValid)
            {
                Category category = new Category();
                category.CategoryId = model.CategoryId;
                category.CategoryName = model.CategoryName;
                repo.Update(category);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Delete(Guid id)
        {
            repo.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Category model)
        {
            if (ModelState.IsValid)
            {
                Category category = new Category();
                category.CategoryId = Guid.NewGuid();
                category.CategoryName = model.CategoryName;
                repo.Add(category);
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}