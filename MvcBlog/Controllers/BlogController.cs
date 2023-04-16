using BusinessLayer.Concrate;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using EntityLayer.Concrate;
using DataAccessLayer.Concrate;
using System.IO;
using DataAccessLayer.EntityFramework;
using BusinessLayer.ValidationRules;
using FluentValidation.Results;

namespace MvcBlog.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        BlogManager bm = new BlogManager(new EfBlogDal());
        CommentManager cm = new CommentManager(new EfCommentDal());

        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public PartialViewResult BlogList(int page = 1)
        {
            var bloglist = bm.GetList().ToPagedList(page, 6);
            return PartialView(bloglist);
        }

        [AllowAnonymous]
        public PartialViewResult FeaturedPosts()
        {
            //1. post
            var postid1 = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 1).Select(y => y.BlogID).FirstOrDefault();
            var postitem1 = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 1).Select(y => y.BlogTitle).FirstOrDefault();
            var img1 = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 1).Select(y => y.BlogImage).FirstOrDefault();
            var blogdate1 = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 1).Select(y => y.BlogDate).FirstOrDefault();
            var blogpostid1 = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 1).Select(y => y.BlogID).FirstOrDefault();

            ViewBag.postitem1 = postitem1;
            ViewBag.img1 = img1;
            ViewBag.blogdate1 = blogdate1;
            ViewBag.blogpostid1 = blogpostid1;

            //2. post
            var postid2 = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 4).Select(y => y.BlogID).FirstOrDefault();
            var postitem2 = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 4).Select(y => y.BlogTitle).FirstOrDefault();
            var img2 = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 4).Select(y => y.BlogImage).FirstOrDefault();
            var blogdate2 = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 4).Select(y => y.BlogDate).FirstOrDefault();
            var blogpostid2 = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 4).Select(y => y.BlogID).FirstOrDefault();

            ViewBag.postitem2 = postitem2;
            ViewBag.img2 = img2;
            ViewBag.blogdate2 = blogdate2;
            ViewBag.blogpostid2 = blogpostid2;

            //3. post
            var postid3 = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 3).Select(y => y.BlogID).FirstOrDefault();
            var postitem3 = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 3).Select(y => y.BlogTitle).FirstOrDefault();
            var img3 = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 3).Select(y => y.BlogImage).FirstOrDefault();
            var blogdate3 = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 3).Select(y => y.BlogDate).FirstOrDefault();
            var blogpostid3 = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 3).Select(y => y.BlogID).FirstOrDefault();

            ViewBag.postitem3 = postitem3;
            ViewBag.img3 = img3;
            ViewBag.blogdate3 = blogdate3;
            ViewBag.blogpostid3 = blogpostid3;

            //4. post
            var postid4 = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 2).Select(y => y.BlogID).FirstOrDefault();
            var postitem4 = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 2).Select(y => y.BlogTitle).FirstOrDefault();
            var img4 = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 2).Select(y => y.BlogImage).FirstOrDefault();
            var blogdate4 = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 2).Select(y => y.BlogDate).FirstOrDefault();
            var blogpostid4 = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 2).Select(y => y.BlogID).FirstOrDefault();


            ViewBag.postitem4 = postitem4;
            ViewBag.img4 = img4;
            ViewBag.blogdate4 = blogdate4;
            ViewBag.blogpostid4 = blogpostid4;

            //5. post
            var postid5 = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 1002).Select(y => y.BlogID).FirstOrDefault();
            var postitem5 = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 1002).Select(y => y.BlogTitle).FirstOrDefault();
            var img5 = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 1002).Select(y => y.BlogImage).FirstOrDefault();
            var blogdate5 = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 1002).Select(y => y.BlogDate).FirstOrDefault();
            var blogpostid5 = bm.GetList().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 1002).Select(y => y.BlogID).FirstOrDefault();

            ViewBag.postitem5 = postitem5;
            ViewBag.img5 = img5;
            ViewBag.blogdate5 = blogdate5;
            ViewBag.blogpostid5 = blogpostid5;

            return PartialView();
        }

        [AllowAnonymous]
        public PartialViewResult OtherFeaturedPosts()
        {
            return PartialView();
        }

        [AllowAnonymous]
        public ActionResult BlogDetails(int id)
        {
            var blogTitle = bm.GetBlogByID(id);
            ViewBag.title = blogTitle.Select(x => x.BlogTitle).FirstOrDefault();
            return View();
        }

        [AllowAnonymous]
        public PartialViewResult BlogCover(int id)
        {
            var BlogDetailsList = bm.GetBlogByID(id);
            ViewBag.title = BlogDetailsList.Select(x => x.BlogTitle).FirstOrDefault();
            return PartialView(BlogDetailsList);
        }

        [AllowAnonymous]
        public PartialViewResult BlogReadAll(int id)
        {
            var BlogDetailsList = bm.GetBlogByID(id);
            return PartialView(BlogDetailsList);
        }

        [AllowAnonymous]
        public ActionResult BlogByCategory(int id)
        {
            var blogListByCategory = bm.GetBlogByCategory(id);
            var categoryName = bm.GetBlogByCategory(id).Select(y => y.Category.CategoryName).FirstOrDefault();
            ViewBag.categoryName = categoryName;
            var categoryDescription = bm.GetBlogByCategory(id).Select(y => y.Category.CategoryDescription).FirstOrDefault();
            ViewBag.categoryDescription = categoryDescription;
            return View(blogListByCategory);
        }

        public ActionResult AdminBlogList()
        {
            var blogList = bm.GetList();
            return View(blogList);
        }

        public ActionResult AdminBlogList2()
        {
            var blogList = bm.GetList();
            return View(blogList);
        }

        //Blog Ekleme Kısmı
        [Authorize(Roles = "A")]
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
            BlogValitador blogValidator = new BlogValitador();
            ValidationResult results = blogValidator.Validate(p);
            if (results.IsValid)
            {
                bm.TAdd(p);
                return RedirectToAction("AdminBlogList");
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

        public ActionResult DeleteBlog(int id)
        {
            Blog blog = bm.GetByID(id);
            bm.TDelete(blog);
            return RedirectToAction("AdminBlogList");
        }

        //Blog Güncelleme
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
            BlogValitador blogValidator = new BlogValitador();
            ValidationResult results = blogValidator.Validate(p);
            if (results.IsValid)
            {
                bm.TUpdate(p);
                return RedirectToAction("AdminBlogList");
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

        public ActionResult GetCommentByBlog(int id)
        {
            var commentList = cm.CommentByBlog(id);
            return View(commentList);
        }
    }
}