using System.ServiceModel;
using System.ServiceModel.Web;
using Tachan.WS.SOAP.Model;

namespace Tachan.WS.SOAP
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IMusicRS" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IMusicRS
    {
        #region Methods

        [OperationContract]
        [WebGet(UriTemplate = "xml/{search}", ResponseFormat = WebMessageFormat.Xml)]
        SpotifyWrapper GetMusicFrom(string search);

        #endregion Methods
    }
}