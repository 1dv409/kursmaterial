using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NextBirthday.Models;

namespace NextBirthday.Controllers
{
    public class BirthdayController : Controller
    {
        //
        // GET: /Birthday/

        public ActionResult Index()
        {
            return View("Index");
        }

        //
        // POST: /Birthday/

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Birthday birthday)
        {
            //ModelState.AddModelError("Birthdate", "Birthdate Error #1");
            //ModelState.AddModelError("Birthdate", "Birthdate Error #2");
            //ModelState.AddModelError("Name", "Name Error #1");
            //ModelState.AddModelError(String.Empty, "Form Error #1");

            if (Request.IsAjaxRequest())
            {
                if (ModelState.IsValid)
                {
                    return PartialView("_UpcomingBirthday", birthday);
                }
                else
                {
                    Response.StatusCode = 400;

                    var errors = ModelState
                        .Where(kvp => kvp.Value.Errors.Any())
                        .ToDictionary(kvp => kvp.Key,
                                      kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray());

                    return Json(new { Errors = errors }, JsonRequestBehavior.AllowGet);

                    //return Content("Ett fel inträffade.");
                }
            }

            return View("Index", birthday);
        }

        //public ActionResult ValidateBirthdate(string birthdate)
        //{
        //    DateTime parsedBirthdate;

        //    if (!DateTime.TryParse(birthdate, out parsedBirthdate))
        //    {
        //        return Json("Födelsedatumet måste vara ett datum.", JsonRequestBehavior.AllowGet);
        //    }
        //    else if (parsedBirthdate > DateTime.Today)
        //    {
        //        return Json("Ett födelsedatum tidigare än dagens datum måste anges.", JsonRequestBehavior.AllowGet);
        //    }
        //    else
        //    {
        //        return Json(true, JsonRequestBehavior.AllowGet);
        //    }

        //}
    }
}
