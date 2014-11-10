using NextBirthday._0.Models.Version_5;
using System;
using System.Web.Mvc;

namespace NextBirthday._0.Controllers
{
    public class Version_5_BirthdayController : Controller
    {
        // GET: Version_5_Birthday/Index
        public ActionResult Index()
        {
            return View("Index");
        }

        // POST: Version_5_Birthday/Index
        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            var model = new Birthday();
            if (TryUpdateModel(model, new[] { "name", "birthdate" }, collection) &&
                model.Birthdate > DateTime.Today)
            {
                // Custom error (there are better ways!).
                ModelState.AddModelError("Birthdate",
                    "Datumet har inte infallit.");
            }

            if (ModelState.IsValid)
            {
                return View("UpcomingBirthday", model);
            }

            return View("Index");
        }
    }
}