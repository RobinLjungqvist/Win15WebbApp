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
using System.Security.Claims;
using Microsoft.AspNet.Identity;

namespace WebbApp.Controllers
{
    public class ItemController : Controller
    {
        private IRepository<Item> itemRepo;
        private IRepository<Category> categoryRepo;
        private IRepository<Region> regionRepo;
        private IRepository<City> cityRepo;
        private IRepository<Condition> conditionRepo;
        private IRepository<ApplicationUser> userRepo;

        public ItemController()
        {
            this.itemRepo = new ItemRepository();
            this.categoryRepo = new CategoryRepository();
            this.regionRepo = new RegionRepository();
            this.cityRepo = new CityRepository();
            this.conditionRepo = new ConditionRepository();
            this.userRepo = new UserRepository();
        }

        [AllowAnonymous]
        public ActionResult Index()
        {

            return PartialView();
        }

        [Authorize]
        [HttpGet]
        public ActionResult NewItem()
        {
            var ivm = new ItemViewModel();
            ivm.Categories = categoryRepo.GetAll().ToList();
            ivm.Conditions = conditionRepo.GetAll().ToList();
            //ivm.Regions = regionRepo.GetAll().ToList();
            //ivm.Cities = cityRepo.GetAll().ToList();
            return View(ivm);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewItem(ItemViewModel model, IEnumerable<HttpPostedFileBase> files)
        {
            DateTime date = DateTime.Today;
            Guid newItemId = Guid.NewGuid();
            var newItem = new Item() { ItemID = newItemId, Title = model.Title, CreateDate = date, ExpirationDate = date.AddDays(14), Description = model.Description };
            newItem.CategoryId = model.Category.CategoryId;
            newItem.ConditionId = model.Condition.ConditionId;
            //newItem.CityId = model.City.CityId;
            //newItem.RegionId = model.Region.RegionId;
            Guid userId = new Guid(User.Identity.GetUserId());
            newItem.RegionId = userRepo.GetById(userId).Region.RegionId;
            newItem.CityId = userRepo.GetById(userId).City.CityId;
            itemRepo.Add(newItem);

            if (files != null && files.ElementAt(0) != null && files.ElementAt(0).ContentLength != 0)
            {
                foreach (var file in files)
                {
                    string newImg = System.IO.Path.GetFileName(file.FileName);
                    string path = System.IO.Path.Combine(Server.MapPath("~/Images"), newImg);
                    if (newImg.ToLower().EndsWith(".jpg") || newImg.ToLower().EndsWith(".png"))
                    {
                        file.SaveAs(path);

                        using (MemoryStream ms = new MemoryStream())
                        {
                            file.InputStream.CopyTo(ms);
                            byte[] array = ms.GetBuffer();
                        }
                        Image newImage = new Image();
                        newImage.ImageId = Guid.NewGuid();
                        //newImage.Path = "../Images/" + newImg;
                        newImage.Path = newImg;
                        newImage.ItemID = newItemId;
                        newImage.Item = newItem;
                        itemRepo.AddImage(newImage);
                    }
                }
            }
            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        public ActionResult DisplaySingleItem(Guid itemID)
        {
            var repoItem = itemRepo.GetById(itemID);
            var newViewModel = new ItemViewModel(repoItem.ItemID, repoItem.Title, repoItem.Description, repoItem.CreateDate, repoItem.ExpirationDate, repoItem.City, repoItem.Condition, repoItem.Region, repoItem.Category, repoItem.Images);
            return View(newViewModel);
        }

        [AllowAnonymous]
        public ActionResult ListAllItems()
        {
            var ItemsFromRepo = itemRepo.GetAll();
            var ViewModelItems = new List<ItemViewModel>();

            foreach (var repoItem in ItemsFromRepo)
            {
                var newViewModel = new ItemViewModel(repoItem.ItemID, repoItem.Title, repoItem.Description, repoItem.CreateDate, repoItem.ExpirationDate, repoItem.City, repoItem.Condition, repoItem.Region, repoItem.Category, repoItem.Images);
                ViewModelItems.Add(newViewModel);
            }

                return View(ViewModelItems);
        }

        [Authorize]
        public ActionResult RemoveItem(Guid itemID)
        {
            itemRepo.Delete(itemID);
            return RedirectToAction("Index", "Home");
        }

        [Authorize]
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

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditItem(ItemViewModel viewItem, IEnumerable<HttpPostedFileBase> files)
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
                CategoryId = viewItem.Category.CategoryId,
                ConditionId = viewItem.Condition.ConditionId,
                CityId = viewItem.City.CityId,
                RegionId = viewItem.Region.RegionId
                
            };
            itemRepo.Update(edit);
            //}
            if (files != null && files.ElementAt(0) != null && files.ElementAt(0).ContentLength != 0)
            {
                foreach (var file in files)
                {
                    string newImg = System.IO.Path.GetFileName(file.FileName);
                    string path = System.IO.Path.Combine(Server.MapPath("~/Images"), newImg);
                    if (newImg.ToLower().EndsWith(".jpg") || newImg.ToLower().EndsWith(".png"))
                    {
                        file.SaveAs(path);

                        using (MemoryStream ms = new MemoryStream())
                        {
                            file.InputStream.CopyTo(ms);
                            byte[] array = ms.GetBuffer();
                        }
                        Image newImage = new Image();
                        newImage.ImageId = Guid.NewGuid();
                        //newImage.Path = "../Images/" + newImg;
                        newImage.Path = "../Images/"+newImg;
                        newImage.ItemID = edit.ItemID;
                        newImage.Item = edit;
                        itemRepo.AddImage(newImage);
                    }
                }
            }
            return RedirectToAction("ListAllItems");
        }
    }
}