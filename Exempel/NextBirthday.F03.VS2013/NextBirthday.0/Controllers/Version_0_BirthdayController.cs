using NextBirthday._0.Models.Version_0;
using System;
using System.Web.Mvc;

namespace NextBirthday._0.Controllers
{
    public class Version_0_BirthdayController : Controller
    {
        // GET: Version_0_Birthday/Index
        public ActionResult Index()
        {
            return View("Index");
        }

        // POST: Version_0_Birthday/Index
        [HttpPost, ActionName("Index")]
        public ActionResult Index_POST()
        {
            // "vanilla"; very bad idea
            var model = new Birthday
            {
                Name = Request.Form["namn"],
                Birthdate = DateTime.Parse(Request.Form["fodelsedatum"])
            };

            return View("UpcomingBirthday", model);
        }
    }
}