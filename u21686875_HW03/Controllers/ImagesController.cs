using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using u21686875_HW03.Models;
using System.IO;

namespace u21686875_HW03.Controllers
{
    public class ImagesController : Controller
    {
        // GET: Images
        public ActionResult Index()
        {

            string[] Imagepaths = Directory.GetFiles(Server.MapPath("~/Media/Images/"));

            List<ModelFile> images = new List<ModelFile>();

            foreach (string imagepath in Imagepaths)
            {
                images.Add(new ModelFile { FileName = Path.GetFileName(imagepath) });
            }
            return View(images);
        }
        public ActionResult DownloadFile(string fileName)
        {

            string path = Server.MapPath("~/Media/Images/") + fileName;

            byte[] bytes = System.IO.File.ReadAllBytes(path);


            return File(bytes, "application/octet-stream", fileName);
        }

        public ActionResult DeleteFile(string fileName)
        {

            string path = Server.MapPath("~/Media/Images/") + fileName;

            byte[] bytes = System.IO.File.ReadAllBytes(path);

            System.IO.File.Delete(path);

            return RedirectToAction("Index");
        }
    }
}