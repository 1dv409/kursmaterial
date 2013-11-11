using System;
using System.Web.Mvc;
using Hello.Models;

namespace Hello.Controllers
{
    public class HelloController : Controller
    {
        public string Greet()
        {
            return "Hello, world!";
        }

        public ActionResult GreetWithView()
        {
            return View();
        }

        public ActionResult GreetWithViewBag()
        {
            int hour = DateTime.Now.Hour;
            ViewBag.Greeting = hour < 12 ?
                "Good morning" : "Good afternoon";
            return View();
        }

        public ActionResult GreetWithViewBagAndModel()
        {
            ViewBag.Salutation = new Salutation();
            return View();
        }

        public ActionResult GreetWithModel()
        {
            var model = new Salutation();
            return View(model);
        }
    }
}
