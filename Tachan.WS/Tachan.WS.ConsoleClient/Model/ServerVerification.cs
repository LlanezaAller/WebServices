namespace Tachan.WS.ConsoleClient.Model
{
    internal class ServerVerification
    {
        #region Properties

        public string _id { get; set; }
        public string albumId { get; set; }
        public string movieId { get; set; }

        #endregion Properties

        #region Methods

        public override string ToString()
        {
            return $"ServerVerification: [MovieID: {movieId} AlbumID: {albumId}]";
        }

        #endregion Methods
    }
}