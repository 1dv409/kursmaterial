using GeekGuestbook.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GeekGuestbook.Controllers
{
    public class GuestbookController : Controller
    {
        private GeekGuestbookEntities _entities = new GeekGuestbookEntities();

        // GET: Guestbook
        public ActionResult Index()
        {
            var model = _entities.Messages.ToList();

            return View(model);
        }

        // GET: Guestbook/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Guestbook/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Message message)
        {
            message.Created = DateTime.Now;

            _entities.Messages.Add(message);
            _entities.SaveChanges();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _entities.Dispose();
            base.Dispose(disposing);
        }
    }
}