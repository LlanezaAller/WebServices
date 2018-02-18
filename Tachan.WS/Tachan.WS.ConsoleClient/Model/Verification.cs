using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tachan.WS.ConsoleClient.Model
{
    internal class Verification
    {
        public string movieId { get; set; }
        public string albumId { get; set; }

        public override string ToString()
        {
            return $"ServerVerification: [MovieID: {movieId} AlbumID: {albumId}]";
        }
    }
}