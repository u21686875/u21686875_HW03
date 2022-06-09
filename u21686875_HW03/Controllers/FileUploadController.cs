using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace u21686875_HW03.Controllers
{
    public class FileUploadController : Controller
    {
        // GET: FileUpload
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase files)
        {
            if(files != null && files.ContentLength > 0)
            {
                var fileName = Path.GetFileName(files.FileName);
                var path = Path.Combine(Server.MapPath("~/Media/Documents"), fileName);

                files.SaveAs(path);
            }

            return RedirectToAction("Index");
        }
    }
}