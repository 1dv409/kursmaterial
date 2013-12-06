using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using GeekTweet.Domain.Entities;
using GeekTweet.Domain.Abstract;
using GeekTweet.Domain.Webservices;
using GeekTweet.ViewModels;
using GeekTweet.Domain;

namespace GeekTweet.Controllers
{
    public class TwitterController : Controller
    {
        private IGeekTweetService _service;

        public TwitterController()
            : this(new GeekTweetService())
        {
            // Empty!
        }

        public TwitterController(IGeekTweetService service)
        {
            _service = service;
        }

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
                    model.Tweets = _service.GetTweets(model.ScreenName);
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
            _service.Dispose();
            base.Dispose(disposing);
        }

    }
}
