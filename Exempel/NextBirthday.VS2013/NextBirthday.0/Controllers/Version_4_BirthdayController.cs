using NextBirthday._0.Models.Version_4;
using System.Web.Mvc;

namespace NextBirthday._0.Controllers
{
    public class Version_4_BirthdayController : Controller
    {
        // GET: Version_4_Birthday/Index
        public ActionResult Index()
        {
            return View("Index");
        }

        // POST: Version_4_Birthday/Index
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(FormCollection collection)
        {
            var model = new Birthday();
            if (TryUpdateModel(model, new [] { "name", "birthdate" }, collection))
            {
                return View("UpcomingBirthday", model);
            }

            return View("Index");
        }
    }
}