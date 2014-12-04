using GeekTweet.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GeekTweet.Api.Controllers
{
    [RoutePrefix("api/screennames")]
    public class ScreenNamesController : ApiController
    {
        #region Fields

        private IGeekTweetService _service;

        #endregion

        #region Constructors

        public ScreenNamesController()
            : this(new GeekTweetService())
        {
            // Empty!
        }

        public ScreenNamesController(IGeekTweetService service)
        {
            _service = service;
        }

        #endregion

        [Route("find/{query}")]
        [HttpGet]
        public IHttpActionResult Find(string query)
        {
            return Ok(_service.GetScreenNames(query));
        }

        #region IDisposable

        protected override void Dispose(bool disposing)
        {
            _service.Dispose();
            base.Dispose(disposing);
        }

        #endregion
    }
}
