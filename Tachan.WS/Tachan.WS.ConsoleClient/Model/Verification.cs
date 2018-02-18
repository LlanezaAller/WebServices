namespace Tachan.WS.ConsoleClient.Model
{
    internal class Verification
    {
        #region Properties

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