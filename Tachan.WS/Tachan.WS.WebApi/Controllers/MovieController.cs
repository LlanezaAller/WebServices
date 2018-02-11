using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Configuration;
using System.Web.Http;
using Tachan.WS.Tools;

namespace Tachan.WS.WebApi.Controllers
{
    public class MovieController : ApiController
    {
        [Route("movie/name/{movieName}")]
        public IHttpActionResult GetMovieByName(string movieName)
        {
            string result = Client.CreateClient()
                .SetUri(WebConfigurationManager.AppSettings["OMDBURI"])
                .SetMimeType("application/json")
                .Get<string>(CreateQueryName("s", movieName))
                .Result;
            
            return Ok(result);
        }

        [Route("movie/id/{id}")]
        public IHttpActionResult GetMovieByID(string id)
        {
            string result = Client.CreateClient()
                .SetUri(WebConfigurationManager.AppSettings["OMDBURI"])
                .SetMimeType("application/json")
                .Get<string>(CreateQueryName("i", id))
                .Result;

            return Ok(result);

            return Ok();
        }

        private string CreateQueryName(string type, string movieName)
        {
            return string.Format(CultureInfo.InvariantCulture, $"?{type}={movieName}&apikey={WebConfigurationManager.AppSettings["APIKEY"]}");
        }
    }
}
