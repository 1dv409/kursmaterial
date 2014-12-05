using System;
using System.Net;
using System.Web.Mvc;

namespace CustomError.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Fire400()
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        public ActionResult Fire404()
        {
            return new HttpNotFoundResult();
        }

        public ActionResult Fire500()
        {
            throw new ApplicationException("An application exception occured.");
        }
    }
}