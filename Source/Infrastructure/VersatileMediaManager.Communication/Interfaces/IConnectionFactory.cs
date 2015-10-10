namespace VersatileMediaManager.Communication.Interfaces
{
    /// <summary>
    /// Interface for a connection factory
    /// </summary>
    public interface IConnectionFactory
    {
        IConnection GetConnection(ConnectionKindsEnum connectionKind, ConnectionTypesEnum connectionType);
    }
}