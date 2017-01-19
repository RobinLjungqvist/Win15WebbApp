using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebbApp.Mockup.Interfaces;
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
        public ActionResult NewImage(HttpPostedFileBase[] file)
        {
            for (int i = 0; i < file.Length; i++)
            {
                if (file[i] != null)
                {
                    // Additional information should be added to the filename here to specify the userID, UserIdentity
                    string pic = System.IO.Path.GetFileName(file[i].FileName);
                    string path = System.IO.Path.Combine(
                        Server.MapPath("~/Images"), pic);
                    // file is uploaded
                    file[i].SaveAs(path);

                }
            }
           
            // after successfully uploading redirect the user
            return RedirectToAction("actionname", "controller name");
        }

        public ActionResult DisplaySingleItem(Guid ItemID)
        {
            var repoItem = itemRepository.GetItemByID(ItemID);

            var newViewModel = new ItemViewModel(repoItem.ItemID, repoItem.Title, repoItem.Description, repoItem.CreateDate, repoItem.ExpirationDate, repoItem.City, repoItem.Condition, repoItem.Region, repoItem.Category, repoItem.Image);

            return View(newViewModel);
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


            return PartialView(ViewModelItems);
        }
    }
}