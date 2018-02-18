namespace Tachan.WS.SOAP.Model
{
    public class SpotifyToken
    {
        #region Properties

        public string Access_Token { get; set; }
        public int ExpiresIn { get; set; }
        public string TokenType { get; set; }

        #endregion Properties
    }
}