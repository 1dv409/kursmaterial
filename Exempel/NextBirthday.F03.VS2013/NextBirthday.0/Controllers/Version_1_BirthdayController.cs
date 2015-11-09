using NextBirthday._0.Models.Version_1;
using System;
using System.Web.Mvc;

namespace NextBirthday._0.Controllers
{
    public class Version_1_BirthdayController : Controller
    {
        // GET: Version_1_Birthday/Index
        public ActionResult Index()
        {
            return View("Index");
        }

        // POST: Version_1_Birthday/Index
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(string name, DateTime birthdate) // named parameters
        {
            var model = new Birthday
            {
                Name = name,
                Birthdate = birthdate
            };

            return View("UpcomingBirthday", model);
        }
    }
}