using System;
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
        public ActionResult Create([Bind(Include="Name, Birthdate")]Birthday birthday)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _repository.InsertBirthday(birthday);
                    _repository.Save();

                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    ModelState.AddModelError(String.Empty,
                        "Ett fel inträffade då födelsedagen skulle sparas.");
                }
            }

            return View("Create", birthday);
        }

        //
        // GET: /Birthday/Edit/5

        public ActionResult Edit(int id = 0)
        {
            var birthday = _repository.GetBirthdayById(id);
            if (birthday == null)
            {
                return View("NotFound");
            }

            return View("Edit", birthday);
        }

        //
        // POST: /Birthday/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Birthday birthday)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _repository.UpdateBirthday(birthday);
                    _repository.Save();

                    TempData.Add("birthday",birthday);

                    return RedirectToAction("Saved");
                }
                catch (Exception)
                {
                    ModelState.AddModelError(String.Empty,
                        "Ett fel inträffade då födelsedagen skulle sparas.");
                }
            }

            return View("Edit", birthday);
        }

        //
        // GET: /Birthday/Delete/5

        public ActionResult Delete(int id = 0)
        {
            var birthday = _repository.GetBirthdayById(id);
            if (birthday == null)
            {
                return View("NotFound");
            }

            return View("Delete", birthday);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                _repository.DeleteBirthday(id);
                _repository.Save();

                return RedirectToAction("Deleted");
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty,
                    "Ett fel inträffade då födelsedagen skulle tas bort.");
            }

            return View("Delete", _repository.GetBirthdayById(id));
        }

        public ActionResult Saved()
        {
            return View("Saved", TempData["birthday"]);
        }

        public ActionResult Deleted()
        {
            return View("Deleted");
        }
    }
}
