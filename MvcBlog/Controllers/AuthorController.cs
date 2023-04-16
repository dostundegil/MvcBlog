using BusinessLayer.Concrate;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrate;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBlog.Controllers
{
    public class AuthorController : Controller
    {
        BlogManager blogmanager = new BlogManager(new EfBlogDal());
        AuthorManager authormanager = new AuthorManager(new EfAuthorDal());

        [AllowAnonymous]
        public PartialViewResult AuthorAbout(int id)
        {
            var authorDetails = blogmanager.GetBlogByID(id);
            return PartialView(authorDetails);
        }
        [AllowAnonymous]
        public PartialViewResult AuthorPopularPost(int id)
        {
            var blogAuthorID = blogmanager.GetList().Where(x => x.BlogID == id).Select(y => y.AuthorID).FirstOrDefault();
            ViewBag.blogAuthorID = blogAuthorID;
            var authorBlogs = blogmanager.GetBlogByAuthor(blogAuthorID);
            return PartialView(authorBlogs);
        }

        //Yazarları listeleme
        public ActionResult AuthorList()
        {
            var authorList = authormanager.GetList();
            return View(authorList);
        }

        //Yeni yazar ekleme işlemi
        [HttpGet]
        public ActionResult AddAuthor()
        {
            ViewBag.image = "/Image/2.jpg";
            return View();
        }

        [HttpPost]
        public ActionResult AddAuthor(Author p)
        {
            AuthorValidator authorValidator = new AuthorValidator();
            ValidationResult results = authorValidator.Validate(p);
            if (results.IsValid)
            {
                authormanager.TAdd(p);
                return RedirectToAction("AuthorList");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);

                }
            }
            return View();
        }

        //Güncelleme İşlemi
        [HttpGet]
        public ActionResult AuthorEdit(int id)
        {
            Author author = authormanager.GetByID(id);
            ViewBag.image = author.AuthorImage;
            return View(author);
            
        }

        [HttpPost]
        public ActionResult AuthorEdit(Author p)
        {
            AuthorValidator authorValidator = new AuthorValidator();
            ValidationResult results = authorValidator.Validate(p);
            if (results.IsValid)
            {
                authormanager.TUpdate(p);
                return RedirectToAction("AuthorList");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);

                }
            }
            return View();
        }

    }
}