using System.Collections.Generic;
using System.Web.Http;
using GeekTweet.Domain.Abstract;

namespace GeekTweet.Controllers
{
    public class ScreenNameController : ApiController
    {
        private IGeekTweetService _service;

        public ScreenNameController(IGeekTweetService service)
        {
            _service = service;
        }

        //
        // GET api/screenname

        public IEnumerable<string> Get([FromUri]string term)
        {
            return _service.GetScreenNames(term);
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
