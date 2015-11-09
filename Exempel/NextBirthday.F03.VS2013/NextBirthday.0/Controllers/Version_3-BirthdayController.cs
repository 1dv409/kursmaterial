using NextBirthday._0.Models.Version_3;
using System.Web.Mvc;

namespace NextBirthday._0.Controllers
{
    public class Version_3_BirthdayController : Controller
    {
        // GET: Version_3_Birthday/Index
        public ActionResult Index()
        {
            return View("Index");
        }

        // POST: Version_3_Birthday/Index
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(FormCollection collection)
        {
            var model = new Birthday();
            UpdateModel(model, collection);

            return View("UpcomingBirthday", model);
        }
    }
}