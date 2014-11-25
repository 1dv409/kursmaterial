using HelloAjax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace HelloAjax.Controllers
{
    public class Hello_5_AjaxAndSimpleErrorHandlingController : Controller
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
                if (ModelState.IsValid)
                {
                    return PartialView("_Greeting", greeting);
                }

                Response.StatusCode = 400;
                return Content("Ett fel inträffade.");
            }

            return View(greeting);
        }
    }
}