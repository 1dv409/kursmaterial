using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GeekGuestbook.Models;
using GeekGuestbook.Models.DataModels;

namespace GeekGuestbook.Controllers
{
    public class GuestbookController : Controller
    {
        GeekGuestbookEntities _entities = new GeekGuestbookEntities();

        //
        // GET: /Guestbook/

        public ActionResult Index()
        {
            var model = _entities.Messages.ToList();

            return View("Index", model);
        }

        public ActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Message message)
        {
            message.Created = DateTime.Now;

            _entities.Messages.Add(message);
            _entities.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var message = _entities.Messages.Find(id);
            return View("Delete", message);
        }

        [ActionName("Delete")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var message = _entities.Messages.Find(id);

            _entities.Messages.Remove(message);
            _entities.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
