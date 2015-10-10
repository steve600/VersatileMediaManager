using System.Xml.Linq;

namespace VersatileMediaManager.Communication.Interfaces
{
    /// <summary>
    /// The connection kind
    /// </summary>
    public enum ConnectionKindsEnum
    {
        KodiMediaPlayer
    }

    /// <summary>
    /// The connection type
    /// </summary>
    public enum ConnectionTypesEnum
    {
        JsonRpcHttp
    }

    /// <summary>
    /// Interface for the connection settings
    /// </summary>
    public interface IConnectionSettings
    {
        /// <summary>
        /// ToXml-Method
        /// </summary>
        /// <returns></returns>
        XElement ToXml();

        /// <summary>
        /// Connection kind
        /// </summary>
        ConnectionKindsEnum ConnectionKind { get; }

        /// <summary>
        /// Connection type
        /// </summary>
        ConnectionTypesEnum ConnectionType { get; }

        /// <summary>
        /// The URI-String
        /// </summary>
        string URIString { get; }

        /// <summary>
        /// Connection name
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// The host
        /// </summary>
        string Host { get; set; }

        /// <summary>
        /// The port
        /// </summary>
        int Port { get; set; }

        /// <summary>
        /// The user name
        /// </summary>
        string UserName { get; set; }

        /// <summary>
        /// The passwort
        /// </summary>
        string Password { get; set; }

        /// <summary>
        /// Timeout
        /// </summary>
        int Timeout { get; set; }
    }
}