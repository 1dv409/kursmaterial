using NextBirthdayXML.Models;
using System.Web.Mvc;

namespace NextBirthdayXML.Controllers
{
    public class BirthdayController : Controller
    {
        private XmlRepository _repository = new XmlRepository();

        //
        // GET: /Birthday/

        public ActionResult Index()
        {
            return View("Index", _repository.GetBirthdays());
        }

        //
        // GET: /Birthday/Create

        public ActionResult Create()
        {
            return View("Create");
        }

        //
        // POST: /Birthday/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Birthday birthday)
        {
            if (ModelState.IsValid)
            {
                _repository.InsertBirthday(birthday);
                _repository.Save();

                return RedirectToAction("Index");
            }

            return View("Create");
        }
    }
}