using VersatileMediaManager.Communication.Interfaces;

namespace VersatileMediaManager.Communication.Connections
{
    /// <summary>
    /// Kodi JsonRPC-Connection
    /// </summary>
    public class KodiJsonRpcHttpConnection : IConnection
    {
        public KodiJsonRpcHttpConnection()
        {
            this.ConnectionSettings = new KodiJsonRpcHttpConnectionSettings();
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