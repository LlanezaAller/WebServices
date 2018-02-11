using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Configuration;
using System.Web.Http;
using Newtonsoft.Json;
using Tachan.WS.Tools;

namespace Tachan.WS.WebApi.Controllers
{
    public class MovieController : ApiController
    {
        [Route("movie/name/{movieName}")]
        public IHttpActionResult GetMovieByName(string movieName)
        {
            string uri = string.Format(CultureInfo.InvariantCulture,
                $"{WebConfigurationManager.AppSettings["OMDBURI"]}{CreateQueryName("s", movieName)}");

            return Json(JsonConvert.DeserializeObject(Client.WebGet(uri)));
        }

        [Route("movie/id/{id}")]
        public IHttpActionResult GetMovieByID(string id)
        {
            string uri = string.Format(CultureInfo.InvariantCulture,
                $"{WebConfigurationManager.AppSettings["OMDBURI"]}{CreateQueryName("i", id)}");

            return Json(JsonConvert.DeserializeObject(Client.WebGet(uri)));
        }

        private string CreateQueryName(string type, string movieName)
        {
            return string.Format(CultureInfo.InvariantCulture, $"?{type}={movieName}&apikey={WebConfigurationManager.AppSettings["APIKEY"]}");
        }
    }
}
