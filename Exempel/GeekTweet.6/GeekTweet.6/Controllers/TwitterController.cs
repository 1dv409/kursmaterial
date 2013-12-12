using System;
using System.Web.Mvc;
using GeekTweet.Domain.Abstract;
using GeekTweet.ViewModels;

namespace GeekTweet.Controllers
{
    public class TwitterController : Controller
    {
        private IGeekTweetService _service;

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
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(String.Empty, ex.Message);
            }

            return View("Index", model);
        }

        //
        // GET: /Twitter/IndexApiGet

        public ActionResult IndexApiGet()
        {
            return View("IndexApiGet");
        }

        //
        // POST: /Twitter/IndexApiGet

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult IndexApiGet([Bind(Include = "ScreenName")] TwitterIndexViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.Tweets = _service.GetTweets(model.ScreenName);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(String.Empty, ex.Message);
            }

            return View("IndexApiGet", model);
        }

        //
        // GET: /Twitter/IndexApiPost

        public ActionResult IndexApiPost()
        {
            return View("IndexApiPost");
        }

        //
        // POST: /Twitter/IndexApiPost

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult IndexApiPost([Bind(Include = "ScreenName")] TwitterIndexViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.Tweets = _service.GetTweets(model.ScreenName);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(String.Empty, ex.Message);
            }

            return View("IndexApiPost", model);
        }

        #region Dispose

        protected override void Dispose(bool disposing)
        {
            _service.Dispose();
            base.Dispose(disposing);
        }

        #endregion
    }
}
