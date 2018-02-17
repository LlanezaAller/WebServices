using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tachan.WS.SOAP.Model
{
    public class SpotifyToken
    {
        public string Access_Token { get; set; }
        public string TokenType { get; set; }
        public int ExpiresIn { get; set; }
    }
}