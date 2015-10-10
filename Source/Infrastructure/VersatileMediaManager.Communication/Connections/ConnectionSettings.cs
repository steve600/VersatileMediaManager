using System;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using VersatileMediaManager.Communication.Interfaces;

namespace VersatileMediaManager.Communication.Connections
{
    public abstract class ConnectionSettings : IConnectionSettings
    {
        /// <summary>
        /// CTOR
        /// </summary>
        public ConnectionSettings()
        {
        }

        /// <summary>
        /// CTOR
        /// </summary>
        /// <param name="name">The connection name</param>
        /// <param name="host">The host</param>
        /// <param name="port">The port</param>
        /// <param name="userName">The user name.</param>
        /// <param name="password">The password</param>
        /// <param name="timeout">Timeout</param>
        public ConnectionSettings(string name, string host, int port, string userName, string password, int timeout = 10000)
        {
            this.Name = name;
            this.Host = host;
            this.Port = port;
            this.UserName = userName;
            this.Password = password;
            this.Timeout = timeout;
        }

        /// <summary>
        /// Create from XElement
        /// </summary>
        /// <param name="settings"></param>
        public ConnectionSettings(XElement settings)
        {
            this.Name = settings.Attribute("Name")?.Value;
            this.Host = settings.Attribute("Host")?.Value;
            this.Port = (settings.Attribute("Timeout")?.Value != null) ? Convert.ToInt32(settings.Attribute("Timeout")?.Value) : default(int);
            this.UserName = settings.Attribute("UserName")?.Value;
            this.Password = settings.Attribute("Password")?.Value;
            this.Timeout = (settings.Attribute("Timeout")?.Value != null) ? Convert.ToInt32(settings.Attribute("Timeout")?.Value) : 10000;
        }

        /// <summary>
        /// ToXml-Method
        /// </summary>
        /// <returns></returns>
        public virtual XElement ToXml()
        {
            return new XElement("Connection",
                        new XAttribute("ConnectionKind", this.ConnectionKind),
                        new XAttribute("ConnectionType", this.ConnectionType),
                        new XAttribute("Name", this.Name),
                        new XAttribute("Host", this.Host),
                        new XAttribute("Port", this.Port),
                        new XAttribute("UserName", this.UserName),
                        new XAttribute("Password", this.Password),
                        new XAttribute("Timeout", this.Timeout));
        }

        /// <summary>
        /// The connection kind
        /// </summary>
        public abstract ConnectionKindsEnum ConnectionKind { get; }

        /// <summary>
        /// The connection type
        /// </summary>
        public abstract ConnectionTypesEnum ConnectionType { get; }

        /// <summary>
        /// The URI-String
        /// </summary>
        public abstract string URIString { get; }

        /// <summary>
        /// Host
        /// </summary>
        [XmlAttribute("Host")]
        public string Host { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        [XmlAttribute("Name")]
        public string Name { get; set; }

        /// <summary>
        /// UserName
        /// </summary>
        [XmlAttribute("UserName")]
        public string UserName { get; set; }

        /// <summary>
        /// Password
        /// </summary>
        [XmlAttribute("Password")]
        public string Password { get; set; }

        /// <summary>
        /// The port
        /// </summary>
        [XmlAttribute("Port", DataType = "Int32")]
        public int Port { get; set; }

        /// <summary>
        /// Timeout
        /// </summary>
        [XmlAttribute("Timeout", DataType = "Int32")]
        public int Timeout { get; set; }
    }
}