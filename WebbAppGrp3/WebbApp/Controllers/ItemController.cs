using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebbApp.Controllers
{
    public class ItemController : Controller
    {
        public ActionResult Index()
        {
            return PartialView();
        }
        // GET: Item
        public ActionResult NewImage(HttpPostedFileBase file)
        {
            if (file != null)
            {
                // Additional information should be added to the filename here to specify the userID, UserIdentity
                string pic = System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine(
                                       Server.MapPath("~/Images/profile"), pic);
                // file is uploaded
                file.SaveAs(path);

            }
            // after successfully uploading redirect the user
            return RedirectToAction("actionname", "controller name");
        }
    
    }
}