namespace VersatileMediaManager.Communication.Interfaces
{
    /// <summary>
    /// Interface for a connection
    /// </summary>
    public interface IConnection
    {
        IConnectionSettings ConnectionSettings { get; }
    }
}