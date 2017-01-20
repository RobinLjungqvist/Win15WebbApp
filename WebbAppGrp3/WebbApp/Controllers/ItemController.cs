using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebbApp.Mockup.Interfaces;
using WebbApp.Mockup.Models;
using WebbApp.Mockup.Repo;
using WebbApp.ViewModels;

namespace WebbApp.Controllers
{
    public class ItemController : Controller
    {
        private IItemRepository itemRepository;

        public ItemController()
        {
            this.itemRepository = new MockupItemRepository();
        }
        public ActionResult Index()
        {
            return PartialView();
        }

        // GET: Item
        public ActionResult NewItem(ItemViewModel model, HttpPostedFileBase file)
        {
            string path = string.Empty;

       
                if (file != null)
                {
                    // Additional information should be added to the filename here to specify the userID, UserIdentity
                    string pic = System.IO.Path.GetFileName(file.FileName);
                    path = System.IO.Path.Combine(
                        Server.MapPath("~/Images"), pic);
                    // file is uploaded
                    file.SaveAs(path);

                }
          

            if(model != null)
            {
                var newItem = new MockupItem();

                newItem.Title = model.Title;
                newItem.Category = model.Category;
                newItem.City = model.City;
                newItem.Condition = model.Condition;
                newItem.CreateDate = model.CreateDate;
                newItem.Description = model.Description;
                newItem.ExpirationDate = model.ExpirationDate;
                if (path != "")
                {
                    newItem.Image = path;
                }
                newItem.Region = model.Region;

                itemRepository.CreateOrUpdateItem(newItem);
            }

            // after successfully uploading redirect the user
            return RedirectToAction("actionname", "controller name");
        }

        public ActionResult DisplaySingleItem()
        {
            
            var repoItem = new MockupItem(Guid.NewGuid(), "Titlestring", "decriptionstring", DateTime.Now, DateTime.Now.AddDays(7),
                "CityMalmö", "ConditionNormal", "RegionSkåne", "CategoryBed", "../Images/PlaceholderImage.png");
          

            var newViewModel = new ItemViewModel(repoItem.ItemID, repoItem.Title, repoItem.Description, repoItem.CreateDate, repoItem.ExpirationDate, repoItem.City, repoItem.Condition, repoItem.Region, repoItem.Category, repoItem.Image);

            return PartialView(newViewModel);
        }

        public ActionResult ListAllItems()
        {
            var ItemsFromRepo = itemRepository.GetAllItems();

            var ViewModelItems = new List<ItemViewModel>();

            foreach (var repoItem in ItemsFromRepo)
            {
                var newViewModel = new ItemViewModel(repoItem.ItemID, repoItem.Title, repoItem.Description, repoItem.CreateDate, repoItem.ExpirationDate, repoItem.City, repoItem.Condition, repoItem.Region, repoItem.Category, repoItem.Image);   

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
            itemRepository.RemoveItemByID(itemID);

            return RedirectToAction("Index", "Home");
        }
        public ActionResult EditItem(ItemViewModel viewitem)
        {
           return PartialView("EditItem",viewitem);
        }
        [HttpPost]
        public ActionResult EditItem(ItemViewModel viewitem,FormCollection collection)
        {
            var edit = new MockupItem(viewitem.ItemID, viewitem.Title, viewitem.Description, viewitem.CreateDate, viewitem.ExpirationDate, viewitem.City, viewitem.Condition, viewitem.Region, viewitem.Category, viewitem.Image);
            itemRepository.CreateOrUpdateItem(edit);

            return PartialView("EditItem",viewitem);
        }

    }     
}