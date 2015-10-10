using System;
using System.Xml.Linq;
using VersatileMediaManager.Communication.Interfaces;

namespace VersatileMediaManager.Communication.Connections
{
    internal class KodiJsonRpcHttpConnectionSettings : ConnectionSettings
    {
        /// <summary>
        /// CTOR
        /// </summary>
        public KodiJsonRpcHttpConnectionSettings() :
            base()
        {
        }

        /// <summary>
        /// JsonRpcHttpConnection settings
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="host">The host</param>
        /// <param name="port">The port</param>
        /// <param name="userName">The user name</param>
        /// <param name="password">The password</param>
        /// <param name="timeout">The timeout</param>
        public KodiJsonRpcHttpConnectionSettings(string name, string host, int port, string userName, string password, int timeout = 10000) :
            base(name, host, port, userName, password, timeout)
        {
        }

        /// <summary>
        /// Create connection from XML
        /// </summary>
        /// <param name="settings"></param>
        public KodiJsonRpcHttpConnectionSettings(XElement settings) :
            base(settings)
        {
        }

        /// <summary>
        /// The connection kind
        /// </summary>
        public override ConnectionKindsEnum ConnectionKind
        {
            get
            {
                return ConnectionKindsEnum.KodiMediaPlayer;
            }
        }

        /// <summary>
        /// The connection type
        /// </summary>
        public override ConnectionTypesEnum ConnectionType
        {
            get
            {
                return ConnectionTypesEnum.JsonRpcHttp;
            }
        }

        public override string URIString
        {
            get
            {
                return String.Format("http://{0}:{1}/jsonrpc", this.Host, this.Port);
            }
        }
    }
}