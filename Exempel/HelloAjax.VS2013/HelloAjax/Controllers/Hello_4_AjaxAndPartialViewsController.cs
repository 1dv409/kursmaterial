using HelloAjax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelloAjax.Controllers
{
    public class Hello_4_AjaxAndPartialViewsController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Greeting greeting)
        {
            if (Request.IsAjaxRequest())
            {
                return PartialView("_Greeting", greeting);
            }

            return View(greeting);
        }
    }
}