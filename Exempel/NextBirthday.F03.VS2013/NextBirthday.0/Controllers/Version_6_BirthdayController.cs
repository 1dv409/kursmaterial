using NextBirthday._0.Models.Version_6;
using System;
using System.Web.Mvc;

namespace NextBirthday._0.Controllers
{
    public class Version_6_BirthdayController : Controller
    {
        // GET: Birthday/Index
        public ActionResult Index()
        {
            return View("Index");
        }

        // POST: Birthday/Index
        [HttpPost]
        public ActionResult Index([Bind(Include = "Name, Birthdate")]Birthday model)  // using a custom validation attribute
        {
            if (ModelState.IsValid)
            {
                return View("UpcomingBirthday", model);
            }

            return View("Index");
        }
    }
}