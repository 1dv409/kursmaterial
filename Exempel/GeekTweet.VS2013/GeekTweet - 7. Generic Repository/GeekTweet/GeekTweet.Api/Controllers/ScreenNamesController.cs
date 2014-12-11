using GeekTweet.Domain;
using System.Web.Http;

namespace GeekTweet.Api.Controllers
{
    /// <summary>
    /// This API enables operations on a set of screen names.
    /// </summary>
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

        /// <summary>
        /// Gets all screen names matching the value of the query parameter.
        /// </summary>
        /// <param name="query">The string to seek.</param>
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
