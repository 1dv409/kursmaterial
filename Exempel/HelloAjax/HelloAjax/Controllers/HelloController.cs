using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HelloAjax.Models;

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
        public ActionResult Index(GreetData greetData)
        {
            if (greetData.Greeting.Length % 2 == 0)
            {
                ModelState.AddModelError("Greeting",
                    "Strängen kan inte innehåll ett jämt antal tecken.");
            }

            if (Request.IsAjaxRequest())
            {
                if (ModelState.IsValid)
                {
                    return PartialView("_Greeting", greetData.Greeting);
                }

                Response.StatusCode = 400;

                // Transform the modelstate errors to a dictionary where property names is 
                // associated with there errors.
                var errors = ModelState
                    .Where(kvp => kvp.Value.Errors.Any())
                    .ToDictionary(kvp => kvp.Key,
                                  kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray());

                return Json(new { Errors = errors }, JsonRequestBehavior.AllowGet);

            }

            return View("Index", greetData);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index_simple_error(GreetData greetData)
        {
            if (greetData.Greeting.Length % 2 == 0)
            {
                ModelState.AddModelError("Greeting",
                    "Strängen kan inte innehåll ett jämt antal tecken.");
            }

            if (Request.IsAjaxRequest())
            {
                if (ModelState.IsValid)
                {
                    return PartialView("_Greeting", greetData.Greeting);
                }

                Response.StatusCode = 400;
                return Content("Ett fel inträffade.");
            }

            return View("Index", greetData);
        }
 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index_no_validation(string greeting)
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
