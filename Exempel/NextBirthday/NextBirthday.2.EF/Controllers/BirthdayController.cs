using System.Web.Mvc;
using NextBirthday.Models;
using NextBirthday.Models.Repository;

namespace NextBirthday.Controllers
{
    public class BirthdayController : Controller
    {
        private IRepository _repository;

        public BirthdayController()
            : this(new EFRepository())
        {
            // Empty!
        }

        public BirthdayController(IRepository repository)
        {
            _repository = repository;
        }

        protected override void Dispose(bool disposing)
        {
            _repository.Dispose();
            base.Dispose(disposing);
        }

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

            return View("Create", birthday);
        }
    }
}
