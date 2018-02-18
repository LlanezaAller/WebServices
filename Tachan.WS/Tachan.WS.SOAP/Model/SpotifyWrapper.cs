using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tachan.WS.SOAP.Model
{
    public class Albums
    {
        #region Properties

        public string Href { get; set; }
        public List<Item> Items { get; set; }
        public int Limit { get; set; }
        public string Next { get; set; }
        public int Offset { get; set; }
        public object Previous { get; set; }
        public int Total { get; set; }

        #endregion Properties
    }

    public class Artist
    {
        #region Properties

        public ExternalUrls ExternalUrls { get; set; }
        public string Href { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Uri { get; set; }

        #endregion Properties
    }

    public class ExternalUrls
    {
        #region Properties

        public string Spotify { get; set; }

        #endregion Properties
    }

    public class ExternalUrls2
    {
        #region Properties

        public string Spotify { get; set; }

        #endregion Properties
    }

    public class Image
    {
        #region Properties

        public int Height { get; set; }
        public string Url { get; set; }
        public int Width { get; set; }

        #endregion Properties
    }

    public class Item
    {
        #region Properties

        public string AlbumType { get; set; }
        public List<Artist> Artists { get; set; }
        public List<string> AvailableMarkets { get; set; }
        public ExternalUrls2 ExternalUrls { get; set; }
        public string Href { get; set; }
        public string Id { get; set; }
        public List<Image> Images { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Uri { get; set; }

        #endregion Properties
    }

    public class SpotifyWrapper
    {
        #region Properties

        public Albums albums { get; set; }

        #endregion Properties
    }
}