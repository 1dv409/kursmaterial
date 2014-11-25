using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelloAjax.Controllers
{
    public class Hello_3_AjaxAndJavaScriptDisabledController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(string greeting)
        {
            if (Request.IsAjaxRequest())
            {
                return Content("Din Ajax-hälsning: " + greeting);
            }

            return View((object)greeting);
        }
    }
}