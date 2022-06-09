using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using u21686875_HW03.Models;

namespace u21686875_HW03.Controllers
{
    public class FileDownloadController : Controller
    {
        // GET: FileDownload
        public ActionResult Index()
        {

            string[] filepaths = Directory.GetFiles(Server.MapPath("~/Media/Documents/"));

            List<ModelFile> files = new List<ModelFile>();

            foreach(string filepath in filepaths)
            {
                files.Add(new ModelFile { FileName = Path.GetFileName(filepath) });
            }
            return View(files);
        }
        public ActionResult DownloadFile(string fileName)
        {

            string path = Server.MapPath("~/Media/Documents/") + fileName;

            byte[] bytes = System.IO.File.ReadAllBytes(path);

            
            return File(bytes, "application/octet-stream", fileName);
        }

        public ActionResult DeleteFile(string fileName)
        {

            string path = Server.MapPath("~/Media/Documents/") + fileName;

            byte[] bytes = System.IO.File.ReadAllBytes(path);

            System.IO.File.Delete(path);

            return RedirectToAction("Index");
        }

    }
}