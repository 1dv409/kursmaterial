using GeekTweet.Domain;
using System.Web.Http;

namespace GeekTweet.Controllers
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

        [Route("find/{query?}", Name="FindScreenNames")]  // HACK: The additional ? is a quite dirty workaround 
        [HttpGet]                                         //       to get @Url.HttpRouteUrl to work.
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
