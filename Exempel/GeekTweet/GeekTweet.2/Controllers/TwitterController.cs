using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using GeekTweet.Models;
using GeekTweet.Models.Webservices;
using GeekTweet.ViewModels;

namespace GeekTweet.Controllers
{
    public class TwitterController : Controller
    {
        //
        // GET: /Twitter/

        public ActionResult Index()
        {
            return View("Index");
        }

        //
        // POST: /Twitter/

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "ScreenName")] TwitterIndexViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var service = new GeekTweetService();
                    model.Tweets = service.GetTweets(model.ScreenName);
                    model.User = model.Tweets.First().User;
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(String.Empty, ex.Message);
            }

            return View("Index", model);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

    }
}
