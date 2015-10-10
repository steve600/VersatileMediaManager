using System.Collections.ObjectModel;

namespace VersatileMediaManager.Communication.Interfaces
{
    public interface IConnectionManager
    {
        /// <summary>
        /// The active connection
        /// </summary>
        IConnection ActiveConnection { get; set; }

        /// <summary>
        /// List with available connections
        /// </summary>
        ObservableCollection<IConnection> Connections { get; }

        /// <summary>
        /// Create a connection
        /// </summary>
        /// <param name="connectionKind">The connection kind</param>
        /// <param name="connectionType">The connection type</param>
        /// <returns></returns>
        IConnection CreateConnection(ConnectionKindsEnum connectionKind, ConnectionTypesEnum connectionType);

        /// <summary>
        /// Add a new connection
        /// </summary>
        /// <param name="connection">The new connection</param>
        /// <returns></returns>
        bool AddConnection(IConnection connection);

        /// <summary>
        /// Delete an existing connection
        /// </summary>
        /// <param name="connection">The connection</param>
        /// <returns></returns>
        bool DeleteConnection(IConnection connection);
    }
}