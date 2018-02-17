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
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "MusicRS" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione MusicRS.svc o MusicRS.svc.cs en el Explorador de soluciones e inicie la depuración.
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