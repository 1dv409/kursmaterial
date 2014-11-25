using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelloAjax.Controllers
{
    public class Hello_2_SimpleAjaxController : Controller
    {
        // GET: Hello_1_NoAjax
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public string HelloAjax(string greeting)
        {
            return "Din Ajax-hälsning: " + greeting;
        }
    }
}