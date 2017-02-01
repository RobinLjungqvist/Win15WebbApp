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
    public class ExpiredController : Controller
    {
        IRepository<Item> itemRepo;

        public ExpiredController()
        {
            itemRepo = new ItemRepository();
        }

        // GET: Admin/Expired
        public ActionResult Index()
        {
            List<Item> list = itemRepo.GetAll().ToList();
            DateTime expDate = DateTime.Now;
            List<Item> deleteItems = list.FindAll(x => x.ExpirationDate < expDate);

            if (deleteItems == null || deleteItems.Count == 0)
            {
                return Content("No item to remove");
            }
            else
            {
                foreach (var item in deleteItems)
                {
                    foreach (var image in item.Images)
                    {
                        var filePath = Server.MapPath(image.Path);
                        if (System.IO.File.Exists(filePath))
                        {
                            System.IO.File.Delete(filePath);
                        }
                    }
                    itemRepo.Delete(item);

                }

                return Content("OK!");
            }
        }
    }
}