using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GeekTweet.Domain;
using GeekTweet.Domain.Abstract;

namespace GeekTweet.Controllers
{
    public class ScreenNameController : ApiController
    {
        private IGeekTweetService _service;

        public ScreenNameController()
            : this(new GeekTweetService())
        {
            // Empty!
        }

        public ScreenNameController(IGeekTweetService service)
        {
            _service = service;
        }

        // GET api/screenname
        public IEnumerable<string> Get([FromUri]string term)
        {
            return _service.GetScreenNames(term);
        }

        protected override void Dispose(bool disposing)
        {
            _service.Dispose();
            base.Dispose(disposing);
        }
    }
}
