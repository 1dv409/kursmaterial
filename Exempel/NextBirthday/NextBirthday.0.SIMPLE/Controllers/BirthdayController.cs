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
        public ActionResult Index(FormCollection collection)
        {
            var model = new Birthday();
            if (TryUpdateModel(model, new[] { "name", "birthdate" }, collection) &&
                model.Birthdate > DateTime.Today)
            {
                ModelState.AddModelError("Birthdate",
                    "Datumet har inte infallit.");
            }

            if (ModelState.IsValid)
            {
                return View("UpcomingBirthday", model);
            }

            return View("Index", model);
        }

        #region #1

        public ActionResult Index1()
        {
            return View("Index1");
        }

        [HttpPost, ActionName("Index1")]
        public ActionResult Index1_POST()
        {
            var model = new Birthday
            {
                Name = Request.Form["namn"],
                Birthdate = DateTime.Parse(Request.Form["fodelsedatum"])
            };

            return View("UpcomingBirthday", model);
        }

        #endregion

        #region #2

        public ActionResult Index2()
        {
            return View("Index2");
        }

        [HttpPost]
        public ActionResult Index(string name, DateTime birthdate)
        {
            var model = new Birthday
            {
                Name = name,
                Birthdate = birthdate
            };

            return View("UpcomingBirthday", model);
        }

        #endregion

        #region #2.1

        public ActionResult Index2_1()
        {
            return View("Index2");
        }

        [HttpPost]
        public ActionResult Index2_1(Birthday birthday)
        {
            return View("UpcomingBirthday", birthday);
        }

        #endregion

        #region #2.2

        public ActionResult Index2_2()
        {
            return View("Index2");
        }

        [HttpPost]
        public ActionResult Index2_2(FormCollection collection)
        {
            var model = new Birthday();
            UpdateModel(model, collection);

            return View("UpcomingBirthday", model);
        }

        #endregion
    }
}
