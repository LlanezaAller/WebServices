using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Tachan.WS.SOAP.Model;
using Tachan.WS.SOAP.Spotify;

namespace Tachan.WS.SOAP
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IMusicRS" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IMusicRS
    {
        [OperationContract]
        [WebGet(UriTemplate = "xml/{search}", ResponseFormat = WebMessageFormat.Xml)]
        SpotifyWrapper GetMusicFrom(string search);
    }
}