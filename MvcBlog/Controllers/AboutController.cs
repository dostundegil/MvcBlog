using BusinessLayer.Concrate;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBlog.Controllers
{
    [AllowAnonymous]
    public class AboutController : Controller
    {
        AboutManager abm = new AboutManager(new EfAboutDal());
        public ActionResult Index()
        {
            var aboutContent = abm.GetList();
            return View(aboutContent);
        }
        public PartialViewResult Footer()
        {
            var aboutcontentlist=abm.GetList();
            return PartialView(aboutcontentlist);
        }
        public PartialViewResult MeetTheTeam()
        {
            AuthorManager autMan = new AuthorManager(new EfAuthorDal());
            var authorList = autMan.GetList();
            return PartialView(authorList);
        }
        [HttpGet]
        public ActionResult UpdateAbout(int id=1)
        {
            About about = abm.GetByID(id);
            ViewBag.image1 = about.AboutImage1;
            ViewBag.image2 = about.AboutImage2;
            return View(about);
        }
        [HttpPost]
        public ActionResult UpdateAbout(About p)
        {
            abm.TUpdate(p);
            return RedirectToAction("UpdateAbout");
        }
    }
}