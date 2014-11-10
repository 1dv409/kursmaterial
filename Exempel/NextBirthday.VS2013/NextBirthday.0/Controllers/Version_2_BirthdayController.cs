using NextBirthday._0.Models.Version_2;
using System.Web.Mvc;

namespace NextBirthday._0.Controllers
{
    public class Version_2_BirthdayController : Controller
    {
        // GET: Version_2_Birthday/Index
        public ActionResult Index()
        {
            return View("Index");
        }

        // POST: Version_2_Birthday/Index
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Birthday model) // model class as parameter
        {
            return View("UpcomingBirthday", model);
        }
    }
}