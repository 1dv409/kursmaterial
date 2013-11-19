using System;
using System.Web.Mvc;
using NextBirthday.Models;

namespace NextBirthday.Controllers
{
    public class BirthdayController : Controller
    {
        //
        // GET: /Birthday/

        public ActionResult Index()
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}
