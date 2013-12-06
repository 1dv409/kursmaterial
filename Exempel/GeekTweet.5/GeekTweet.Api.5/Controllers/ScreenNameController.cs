using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GeekTweet.Domain;
using GeekTweet.Domain.Abstract;

namespace GeekTweet.Api._5.Controllers
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

        //public IEnumerable<string> Get([FromUri]string term)
        //{
        //    return _service.GetScreenNames(term);
        //}

        public HttpResponseMessage Get([FromUri]string id)
        {
            var response = Request.CreateResponse<IEnumerable<string>>(HttpStatusCode.OK, _service.GetScreenNames(id));
            response.Headers.Add("Access-Control-Allow-Origin", "*");
            return response;
        }

        public HttpResponseMessage Post(Model model)
        {
            var response = Request.CreateResponse<IEnumerable<string>>(HttpStatusCode.OK, _service.GetScreenNames(model.Id));
            response.Headers.Add("Access-Control-Allow-Origin", "*");
            return response;
        }

        public HttpResponseMessage Options()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Headers.Add("Access-Control-Allow-Origin", "*");
            response.Headers.Add("Access-Control-Allow-Methods", "GET, POST");
            return response;
        }

        public class Model
        {
            public string Id { get; set; }
        }
    }

}
