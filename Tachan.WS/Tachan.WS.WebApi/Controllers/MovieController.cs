using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Tachan_WS.Controllers
{
    public class MovieController : ApiController
    {

        public IHttpActionResult GetMovie(string movieName)
        {
            
            
            return Ok();
        }
    }
}
