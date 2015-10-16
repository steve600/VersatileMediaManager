using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using VersatileMediaManager.Communication.Interfaces;

namespace VersatileMediaManager.Communication.Connections
{
    internal class Enigma2WebIfHttpConnectionSettings : ConnectionSettings
    {
        /// <summary>
        /// CTOR
        /// </summary>
        public Enigma2WebIfHttpConnectionSettings() :
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
        public Enigma2WebIfHttpConnectionSettings(string name, string host, int port, string userName, string password, int timeout = 10000) :
            base(name, host, port, userName, password, timeout)
        {
        }

        /// <summary>
        /// Create connection from XML
        /// </summary>
        /// <param name="settings"></param>
        public Enigma2WebIfHttpConnectionSettings(XElement settings) :
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
                return ConnectionKindsEnum.Enigma2WebInterface;
            }
        }

        /// <summary>
        /// The connection type
        /// </summary>
        public override ConnectionTypesEnum ConnectionType
        {
            get
            {
                return ConnectionTypesEnum.Http;
            }
        }

        public override string URIString
        {
            get
            {
                return String.Format("http://{0}", this.Host);
            }
        }
    }
}
