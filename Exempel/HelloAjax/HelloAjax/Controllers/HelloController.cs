using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelloAjax.Controllers
{
    public class HelloController : Controller
    {
        //
        // GET: /Hello/

        public ActionResult Index()
        {
            return View("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(string greeting)
        {
            if (Request.IsAjaxRequest())
            {
                return PartialView("_Greeting", greeting);
            }

            ViewData.Model = greeting;
            return View("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public string HelloAjax(string greeting)
        {
            return "Din Ajax-hälsning: " + greeting;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult HelloAjax2(string greeting)
        {
            if (Request.IsAjaxRequest())
            {
                return Content("Din Ajax-hälsning: " + greeting);
            }

            ViewData.Model = greeting;
            return View("Index");
        }

    }
}
