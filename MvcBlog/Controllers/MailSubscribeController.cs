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
    [AllowAnonymous]
    public class MailSubscribeController : Controller
    {
        SubscribeMailManager sm = new SubscribeMailManager(new EfMailDal());

        [HttpGet]
        public PartialViewResult AddMail()
        {
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult AddMail(SubscribeMail p)
        {
            sm.TAdd(p);
            return PartialView();
        }
    }
}