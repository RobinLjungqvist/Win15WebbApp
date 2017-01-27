using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebbApp.ViewModels;
using WebbApp.DAL.Repositories;
using WebbApp.DAL.Interfaces;
using WebbApp.DAL.DB.Models;

namespace WebbApp.Controllers
{
    [AllowAnonymous]
    public class ItemController : Controller
    {
        private IRepository<Item> itemRepo;

        //public static CategoryRepository categoryRepo;
        private IRepository<Category> categoryRepo;
        private IRepository<Region> regionRepo;
        private IRepository<City> cityRepo;
        private IRepository<Condition> conditionRepo;

        public ItemController()
        {
            this.itemRepo = new ItemRepository();
            this.categoryRepo = new CategoryRepository();
            //categoryRepo = CategoryRepository.getRepo();
            this.regionRepo = new RegionRepository();
            this.cityRepo = new CityRepository();
            this.conditionRepo = new ConditionRepository();
        }
        public ActionResult Index()
        {

            return PartialView();
        }
        [HttpGet]
        public ActionResult NewItem()
        {
            var ivm = new ItemViewModel();
            ivm.Categories = categoryRepo.GetAll().ToList();
            ivm.Conditions = conditionRepo.GetAll().ToList();
            ivm.Regions = regionRepo.GetAll().ToList();
            ivm.Cities = cityRepo.GetAll().ToList();
            return PartialView(ivm);
        }
        // GET: Item
        [HttpPost]
        public ActionResult NewItem(ItemViewModel model, HttpPostedFileBase file)
        {
            string path = string.Empty;
            string pic = string.Empty;

            //TODO: utforska varför går det in hela tiden och sätta tillbaka
            //if (!ModelState.IsValid)
            //{
            //    return PartialView(model);
            //}
            if (file != null)
            {
                // Additional information should be added to the filename here to specify the userID, UserIdentity
                pic = System.IO.Path.GetFileName(file.FileName);
                path = System.IO.Path.Combine(
                    Server.MapPath("~/Images"), pic);
                // file is uploaded
                file.SaveAs(path);
            }
            if (model != null)
            {
                DateTime date = DateTime.Today;
                var item = new Item() { ItemID = Guid.NewGuid(), Title = model.Title, CreateDate = date, ExpirationDate = date.AddDays(14), Description = model.Description };
                item.CategoryId = model.Category.CategoryId;
                item.CityId = model.City.CityId;
                item.ConditionId = model.Condition.ConditionId;
                item.RegionId = model.Region.RegionId;
                if (path != "")
                {
                    //TODO
                    //item.Image.ImageId = Guid.NewGuid();
                    //item.Image.Path = "./Images/" + pic;
                }

                itemRepo.Add(item);
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult DisplaySingleItem(Guid itemID)
        {
            var repoItem = itemRepo.GetById(itemID);
            var newViewModel = new ItemViewModel(repoItem.ItemID, repoItem.Title, repoItem.Description, repoItem.CreateDate, repoItem.ExpirationDate, repoItem.City, repoItem.Condition, repoItem.Region, repoItem.Category, null);
            return PartialView(newViewModel);
        }

        public ActionResult ListAllItems()
        {
            var ItemsFromRepo = itemRepo.GetAll();
            var ViewModelItems = new List<ItemViewModel>();

            foreach (var repoItem in ItemsFromRepo)
            {
                var newViewModel = new ItemViewModel(repoItem.ItemID, repoItem.Title, repoItem.Description, repoItem.CreateDate, repoItem.ExpirationDate, repoItem.City, repoItem.Condition, repoItem.Region, repoItem.Category, null);
                ViewModelItems.Add(newViewModel);
            }

            if (Request.IsAjaxRequest())
            {
                return PartialView("ListAllItems", ViewModelItems);
            }
            return PartialView(ViewModelItems);
        }

        public ActionResult RemoveItem(Guid itemID)
        {
            itemRepo.Delete(itemID);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult EditItem(Guid ItemID)
        {
            var item = itemRepo.GetById(ItemID);
            // var ivm = new ItemViewModel(item.ItemID, item.Title, item.Description, item.CreateDate, item.ExpirationDate, item.City, item.Condition, item.Region, item.Category, item.Image);
            var ivm = new ItemViewModel() { ItemID = item.ItemID, Title = item.Title, Description = item.Description, };
            ivm.Categories = categoryRepo.GetAll().ToList();
            ivm.Conditions = conditionRepo.GetAll().ToList();
            ivm.Regions = regionRepo.GetAll().ToList();
            ivm.Cities = cityRepo.GetAll().ToList();
            return View(ivm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditItem(ItemViewModel viewItem, FormCollection formcollection)
        {
            //MockupItem edit=null;
            Item edit = null;
            ModelState.Remove("Image");
            //if (ModelState.IsValid)
            //{
                edit = new Item()
                {
                    ItemID = viewItem.ItemID,
                    Title = viewItem.Title,
                    Description = viewItem.Description,
                    CreateDate = viewItem.CreateDate,
                    ExpirationDate = viewItem.ExpirationDate,
                    //Category = viewItem.Category.CategoryId,
                    Category = categoryRepo.GetById(viewItem.Category.CategoryId),
                    City = cityRepo.GetById(viewItem.City.CityId),
                    Condition = conditionRepo.GetById(viewItem.Condition.ConditionId),
                    Region = regionRepo.GetById(viewItem.Region.RegionId),
                    //City = viewitem.City,
                    //Condition = viewitem.Condition,
                    //Region = viewitem.Region,
                    //Category = viewitem.Category,
                    //Image = viewItem.Image
                };
                itemRepo.Update(edit);
            //}
            return RedirectToAction("ListAllItems");
        }

    }
}