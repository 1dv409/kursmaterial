using NextBirthdayCRUD.Models;
using NextBirthdayCRUD.Models.Repositories;
using System;
using System.Data;
using System.Net;
using System.Web.Mvc;

namespace NextBirthdayCRUD.Controllers
{
    public class BirthdayController : Controller
    {
        private IRepository _repository;

        public BirthdayController(IRepository repository)
        {
            _repository = repository;
        }

        // GET: /Birthday/
        public ActionResult Index()
        {
            return View(_repository.GetBirthdays());
        }

        // GET: /Birthday/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Birthday/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name, Birthdate")]Birthday birthday)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repository.InsertBirthday(birthday);
                    _repository.Save();
                    TempData["success"] = "Födelsedatumet sparat.";
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                TempData["error"] = "Misslyckades att spara födelsedatumet. Försök igen, och kvarstår problemet kontakta systemadministratören.";
            }

            return View(birthday);
        }

        // GET: /Birthday/Edit/42
        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Birthday birthday = _repository.GetBirthdayById(id.Value);
            if (birthday == null)
            {
                return HttpNotFound();
            }

            return View(birthday);
        }

        // POST: /Birthday/Edit/42
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int id)
        {
            var birthdaytoUpdate = _repository.GetBirthdayById(id);

            if (birthdaytoUpdate == null)
            {
                return HttpNotFound();
            }

            if (TryUpdateModel(birthdaytoUpdate, String.Empty, new string[] { "Name", "Birthdate" }))
            {
                try
                {
                    _repository.UpdateBirthday(birthdaytoUpdate);
                    _repository.Save();
                    TempData["success"] = "Ändringarna sparade.";
                    return RedirectToAction("Index");
                }
                catch (DataException)
                {
                    TempData["error"] = "Misslyckades att spara ändringarna. Försök igen, och kvarstår problemet kontakta systemadministratören.";
                }
            }

            return View(birthdaytoUpdate);
        }

        // GET: /Birthday/Delete/42
        public ActionResult Delete(int? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var birthday = _repository.GetBirthdayById(id.Value);
            if (birthday == null)
            {
                return HttpNotFound();
            }
            
            return View(birthday);
        }

        // POST: /Birthday/Delete/42
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                var studentToDelete = new Birthday { BirthdayId = id }; 
                _repository.DeleteBirthday(studentToDelete);
                _repository.Save();
                TempData["success"] = "Födelsedatumet togs bort.";
            }
            catch (DataException)
            {
                TempData["error"] = "Misslyckades att ta bort födelsedatumet. Försök igen, och kvarstår problemet kontakta systemadministratören.";
                return RedirectToAction("Delete", new { id = id });
            }

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _repository.Dispose();
            base.Dispose(disposing);
        }
    }
}