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
    public class ConditionController : Controller
    {
        private IRepository<Condition> repo;

        public ConditionController()
        {
            this.repo = new ConditionRepository();
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
        public ActionResult Edit(Condition model)
        {
            if (ModelState.IsValid)
            {
                Condition condition = new Condition();
                condition.ConditionId = model.ConditionId;
                condition.Status = model.Status;
                repo.Update(condition);
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
        public ActionResult Create(Condition model)
        {
            if (ModelState.IsValid)
            {
                Condition condition = new Condition();
                condition.ConditionId = Guid.NewGuid();
                condition.Status = model.Status;
                repo.Add(condition);
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}