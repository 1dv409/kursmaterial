using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GeekSimpleLogin.Areas.Member.Models
{
    [Authorize]
    public class HomeController : Controller
    {
        //
        // GET: /Member/Home/

        public ActionResult Index()
        {
            return View();
        }

    }
}
