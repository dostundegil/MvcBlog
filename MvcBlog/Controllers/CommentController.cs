using BusinessLayer.Concrate;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBlog.Controllers
{
    public class CommentController : Controller
    {
        CommentManager cm = new CommentManager(new EfCommentDal());
        [AllowAnonymous]
        public PartialViewResult CommentList(int id)
        {
            var commentList = cm.CommentByBlog(id);
            return PartialView(commentList);
        }
        [AllowAnonymous]
        [HttpGet]
        public PartialViewResult LeaveComment(int id)
        {
            ViewBag.id = id;
            return PartialView();
        }
        [AllowAnonymous]
        [HttpPost]
        public PartialViewResult LeaveComment(Comment c)
        {
            c.CommentStatus = true;
            cm.TAdd(c);
            return PartialView();
        }
        public ActionResult AdminCommentListTrue()
        {
            var commentList = cm.CommentByStatusTrue();
            return View(commentList);
        }
        public ActionResult AdminCommentListFalse()
        {
            var commentList = cm.CommentByStatusFalse();
            return View(commentList);
        }
        public ActionResult CommentStatusChangeTrue(int id)
        {
            cm.CommentStatusChangeTrue(id);
            return RedirectToAction("AdminCommentListFalse");
        }
        public ActionResult CommentStatusChangeFalse(int id)
        {
            cm.CommentStatusChangeFalse(id);
            return RedirectToAction("AdminCommentListTrue");
        }

    }
}