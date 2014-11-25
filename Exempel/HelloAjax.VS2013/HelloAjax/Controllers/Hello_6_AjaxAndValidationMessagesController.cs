using HelloAjax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace HelloAjax.Controllers
{
    public class Hello_6_AjaxAndValidationMessagesController : Controller
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

                // Transform the modelstate errors to a dictionary where property names is 
                // associated with there errors.
                var errors = ModelState
                    .Where(kvp => kvp.Value.Errors.Any())
                    .ToDictionary(kvp => kvp.Key,
                                  kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray());

                return Json(new { Errors = errors });
            }

            return View(greeting);
        }
    }
}