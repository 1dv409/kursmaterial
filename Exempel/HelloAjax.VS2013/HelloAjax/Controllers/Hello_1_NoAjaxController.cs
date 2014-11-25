using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelloAjax.Controllers
{
    public class Hello_1_NoAjaxController : Controller
    {
        // GET: Hello_1_NoAjax
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(string greeting)
        {
            return View("Index", null, greeting);
        }
    }
}