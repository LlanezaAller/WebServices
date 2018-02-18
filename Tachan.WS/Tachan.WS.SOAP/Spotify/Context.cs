using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tachan.WS.SOAP.Spotify
{
    using System;

    public sealed class Context
    {
        #region Fields

        private static volatile Context instance;
        private static object syncRoot = new Object();

        private SpotifyClient client;

        #endregion Fields

        #region Constructors

        private Context()
        {
        }

        #endregion Constructors

        #region Properties

        public static Context Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new Context();
                    }
                }

                return instance;
            }
        }

        public SpotifyClient Client
        {
            get
            {
                if (client == null)
                    client = new SpotifyClient();
                return client;
            }
        }

        #endregion Properties
    }
}