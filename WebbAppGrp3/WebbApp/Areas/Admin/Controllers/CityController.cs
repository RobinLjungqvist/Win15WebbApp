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
    public class CityController : Controller
    {
        private IRepository<City> repo;

        public CityController()
        {
            this.repo = new CityRepository();
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
        public ActionResult Edit(City model)
        {
            if (ModelState.IsValid)
            {
                City city = new City();
                city.CityId = model.CityId;
                city.CityName = model.CityName;
                repo.Update(city);
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
        public ActionResult Create(City model)
        {
            if (ModelState.IsValid)
            {
                City city = new City();
                city.CityId = Guid.NewGuid();
                city.CityName = model.CityName;
                repo.Add(city);
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}