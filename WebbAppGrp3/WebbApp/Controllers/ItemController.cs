﻿using System;
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
            ivm.Regions = regionRepo.GetAll().ToList();
            ivm.Cities = cityRepo.GetAll().ToList();
            return View(ivm);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewItem(ItemViewModel model, IEnumerable<HttpPostedFileBase> files)
        {
            DateTime date = DateTime.Today;
            Guid newItemId = Guid.NewGuid();
            var newItem = new Item() { ItemID = newItemId, Title = model.Title, CreateDate = date, ExpirationDate = date.AddDays(7), Description = model.Description };
            newItem.CategoryId = model.Category.CategoryId;
            newItem.ConditionId = model.Condition.ConditionId;
            //newItem.CityId = model.City.CityId;
            //newItem.RegionId = model.Region.RegionId;
            newItem.ApplicationUserId = Guid.Parse(User.Identity.GetUserId());
            newItem.RegionId = model.Region.RegionId;
            newItem.CityId = model.City.CityId;
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
                        newImage.Path = "../Images/" + newImg;
                        //newImage.Path = newImg;
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
            var newViewModel = new ItemViewModel(repoItem.ItemID,
                repoItem.Title,
                repoItem.Description,
                repoItem.CreateDate,
                repoItem.ExpirationDate,
                repoItem.City,
                repoItem.Condition,
                repoItem.Region,
                repoItem.Category,
                repoItem.Images);
            newViewModel.UploaderID = repoItem.ApplicationUserId.ToString();
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
        [HttpPost]
        public ActionResult RemoveItem(Guid itemID)
        {
            var itemToDelete = itemRepo.GetById(itemID);

            foreach (var image in itemToDelete.Images)
            {
                var filePath = Server.MapPath(image.Path);
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
            }

            itemRepo.Delete(itemID);
            if (Request.IsAjaxRequest())
            {
                return Content("/Item/ListAllItems");
            }
            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        [HttpGet]
        public ActionResult EditItem(Guid ItemID)
        {
            var item = itemRepo.GetById(ItemID);
            var ivm = new ItemViewModel() { ItemID = item.ItemID, Title = item.Title, Description = item.Description, };
            ivm.Categories = categoryRepo.GetAll().ToList();
            ivm.SelectedCategoryId = item.CategoryId;
            ivm.Conditions = conditionRepo.GetAll().ToList();
            ivm.SelectedConditionId = item.ConditionId;
            ivm.Regions = regionRepo.GetAll().ToList();
            ivm.SelectedRegionId = item.RegionId;
            ivm.Cities = cityRepo.GetAll().ToList();
            ivm.SelectedCityId = item.CityId;
            ivm.CreateDate = DateTime.Now;
            ivm.ExpirationDate = DateTime.Now.AddDays(7);
            return View(ivm);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditItem(ItemViewModel viewItem, IEnumerable<HttpPostedFileBase> files)
        {
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
                        newImage.Path = "../Images/" + newImg;
                        newImage.ItemID = edit.ItemID;
                        newImage.Item = edit;
                        itemRepo.AddImage(newImage);
                    }
                }
            }
            return RedirectToAction("ListAllItems");
        }

        public ActionResult GetUploaderEmail(Guid UserID)
        {
            var user = userRepo.GetById(UserID);
            var email = string.Empty;

            if(user != null)
            {
                email = user.Email;
            }

            if(email != string.Empty)
            {
                return Content(email);
            }
            else
            {
                return Content("Couldn't find email.");
            }
        }

    }
}