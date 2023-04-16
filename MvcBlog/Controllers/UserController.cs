using BusinessLayer.Concrate;
using DataAccessLayer.Concrate;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcBlog.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        
        UserProfileManager userProfile = new UserProfileManager();
        BlogManager bm = new BlogManager(new EfBlogDal());
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Partial1(string p)
        {
            p = (string)Session["AuthorMail"];
            var profileValues = userProfile.GetAuthorByMail(p);
            return PartialView(profileValues);
        }
        public ActionResult AuthorName(string p)
        {
            p = (string)Session["AuthorMail"];
            var authorName = userProfile.GetAuthorByMail(p);
            ViewBag.authorName = authorName.Select(x => x.AuthorName).FirstOrDefault();
            ViewBag.authorImage = authorName.Select(x => x.AuthorImage).FirstOrDefault();
            return PartialView();
        }
        public ActionResult UpdateUserProfile(Author p)
        {
            userProfile.UpdateAuthor(p);
            return RedirectToAction("Index");
        }
        public ActionResult BlogList(string p)
        {
            p = (string)Session["AuthorMail"];
            Context c = new Context();
            int id = c.Authors.Where(x => x.AuthorMail == p).Select(y => y.AuthorID).FirstOrDefault();
            var blogs = userProfile.GetBlogByAuthor(id);
            return View(blogs);
        }

        [HttpGet]
        public ActionResult UpdateBlog(int id)
        {
            Blog blog = bm.GetByID(id);
            Context c = new Context();
            List<SelectListItem> values = (from x in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString()
                                           }).ToList();
            ViewBag.values = values;

            List<SelectListItem> values2 = (from x in c.Authors.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.AuthorName,
                                                Value = x.AuthorID.ToString()
                                            }).ToList();
            ViewBag.image = blog.BlogImage;
            ViewBag.values2 = values2;
            return View(blog);
        }
        [HttpPost]
        public ActionResult UpdateBlog(Blog p)
        {
            bm.TUpdate(p);
            return RedirectToAction("BlogList");
        }
        [HttpGet]
        public ActionResult AddNewBlog()
        {
            Context c = new Context();
            List<SelectListItem> values = (from x in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString()
                                           }).ToList();
            ViewBag.values = values;

            List<SelectListItem> values2 = (from x in c.Authors.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.AuthorName,
                                                Value = x.AuthorID.ToString()
                                            }).ToList();
            ViewBag.image = "/Image/1.jpg";
            ViewBag.values2 = values2;
            return View();
        }
        [HttpPost]
        public ActionResult AddNewBlog(Blog p)
        {
            bm.TAdd(p);
            return RedirectToAction("BlogList");
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("AuthorLogin", "Login");
        }
        
    }
}