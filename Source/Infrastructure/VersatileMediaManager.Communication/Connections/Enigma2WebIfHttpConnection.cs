using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VersatileMediaManager.Communication.Interfaces;

namespace VersatileMediaManager.Communication.Connections
{
    /// <summary>
    /// Enigma2 Web-Interface connection
    /// </summary>
    public class Enigma2WebIfHttpConnection : IConnection
    {
        public Enigma2WebIfHttpConnection()
        {
            this.ConnectionSettings = new Enigma2WebIfHttpConnectionSettings();
        }

        #region IConnection

        private IConnectionSettings connectionSettings;

        /// <summary>
        /// The connections settings
        /// </summary>
        public IConnectionSettings ConnectionSettings
        {
            get { return connectionSettings; }
            set { connectionSettings = value; }
        }

        #endregion IConnection
    }
}
