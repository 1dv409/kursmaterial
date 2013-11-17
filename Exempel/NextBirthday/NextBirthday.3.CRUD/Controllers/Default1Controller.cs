using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NextBirthday.Models;
using NextBirthday.Models.DataModels;

namespace NextBirthday.Controllers
{
    public class Default1Controller : Controller
    {
        private GeekBirthdayEntities db = new GeekBirthdayEntities();

        //
        // GET: /Default1/

        public ActionResult Index()
        {
            return View(db.Birthdays.ToList());
        }

        //
        // GET: /Default1/Details/5

        public ActionResult Details(int id = 0)
        {
            Birthday birthday = db.Birthdays.Find(id);
            if (birthday == null)
            {
                return HttpNotFound();
            }
            return View(birthday);
        }

        //
        // GET: /Default1/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Default1/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Birthday birthday)
        {
            if (ModelState.IsValid)
            {
                db.Birthdays.Add(birthday);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(birthday);
        }

        //
        // GET: /Default1/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Birthday birthday = db.Birthdays.Find(id);
            if (birthday == null)
            {
                return HttpNotFound();
            }
            return View(birthday);
        }

        //
        // POST: /Default1/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Birthday birthday)
        {
            if (ModelState.IsValid)
            {
                db.Entry(birthday).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(birthday);
        }

        //
        // GET: /Default1/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Birthday birthday = db.Birthdays.Find(id);
            if (birthday == null)
            {
                return HttpNotFound();
            }
            return View(birthday);
        }

        //
        // POST: /Default1/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Birthday birthday = db.Birthdays.Find(id);
            db.Birthdays.Remove(birthday);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}