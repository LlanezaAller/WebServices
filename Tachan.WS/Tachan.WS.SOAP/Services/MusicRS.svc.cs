using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Tachan.WS.SOAP.Model;
using Tachan.WS.SOAP.Spotify;

namespace Tachan.WS.SOAP
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class MusicRS : IMusicRS
    {
        private Context context;

        public SpotifyWrapper GetMusicFrom(string search)
        {
            if (context == null)
                context = Context.Instance;
            return context.Client.GetAlbum(search);
        }
    }
}