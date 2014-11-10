using NextBirthday._0.Models;
using System.Web.Mvc;

namespace NextBirthday._0.Controllers
{
    public class BirthdayController : Controller
    {
        // GET: Birthday/Index
        public ActionResult Index()
        {
            return View("Index");
        }

        // POST: Birthday/Index
        [HttpPost]
        public ActionResult Index([Bind(Include = "Name, Birthdate")]Birthday model)
        {
            if (ModelState.IsValid)
            {
                return View("UpcomingBirthday", model);
            }

            return View("Index");
        }
    }
}