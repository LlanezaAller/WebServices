using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tachan.WS.SOAP.Model
{
    public class SpotifyWrapper
    {
        public Albums albums { get; set; }
    }

    public class ExternalUrls
    {
        public string Spotify { get; set; }
    }

    public class Artist
    {
        public ExternalUrls ExternalUrls { get; set; }
        public string Href { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Uri { get; set; }
    }

    public class ExternalUrls2
    {
        public string Spotify { get; set; }
    }

    public class Image
    {
        public int Height { get; set; }
        public string Url { get; set; }
        public int Width { get; set; }
    }

    public class Item
    {
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
    }

    public class Albums
    {
        public string Href { get; set; }
        public List<Item> Items { get; set; }
        public int Limit { get; set; }
        public string Next { get; set; }
        public int Offset { get; set; }
        public object Previous { get; set; }
        public int Total { get; set; }
    }
}