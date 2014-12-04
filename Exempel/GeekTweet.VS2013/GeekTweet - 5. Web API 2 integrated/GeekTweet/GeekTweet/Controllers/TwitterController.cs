using GeekTweet.Domain;
using GeekTweet.Infrastructure;
using GeekTweet.ViewModels;
using System;
using System.Web.Mvc;

namespace GeekTweet.Controllers
{
    public class TwitterController : Controller
    {
        #region Fields

        private IGeekTweetService _service;

        #endregion

        #region Constructors

        public TwitterController()
            : this(new GeekTweetService())
        {
            // Empty!
        }

        public TwitterController(IGeekTweetService service)
        {
            _service = service;
        }

        #endregion

        #region Index

        // GET: /
        public ActionResult Index()
        {
            return View();
        }

        // POST: /
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "ScreenName")] TwitterIndexViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.User = _service.GetUser(model.ScreenName);
                    _service.RefreshTweets(model.User);
                }
            }
            catch (Exception ex)
            {
                // Get the innermost exception.
                while (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                }

                ModelState.AddModelError(String.Empty, ex.Message);
            }

            return View(model);
        }

        #endregion

        #region Ajax action methods

        [HttpPost]
        [AjaxOnly]
        public ActionResult GetScreenNames(string term)
        {
            return Json(_service.GetScreenNames(term));
        }

        #endregion

        #region IDisposable

        protected override void Dispose(bool disposing)
        {
            _service.Dispose();
            base.Dispose(disposing);
        }

        #endregion
    }
}