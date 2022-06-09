using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using u21686875_HW03.Models;

namespace u21686875_HW03.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        public ActionResult Index()
        {
            String path = Server.MapPath("~/Content");
            string[] Imagepaths = Directory.GetFiles(path);
            ViewBag.images = Imagepaths;

            return View();
        }
    }
}