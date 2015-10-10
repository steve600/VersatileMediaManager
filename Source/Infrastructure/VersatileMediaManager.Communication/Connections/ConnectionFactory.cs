using VersatileMediaManager.Communication.Interfaces;

namespace VersatileMediaManager.Communication.Connections
{
    public class ConnectionFactory : IConnectionFactory
    {
        public IConnection GetConnection(ConnectionKindsEnum connectionKind, ConnectionTypesEnum connectionType)
        {
            IConnection result = null;

            if (connectionKind == ConnectionKindsEnum.KodiMediaPlayer && connectionType == ConnectionTypesEnum.JsonRpcHttp)
            {
                result = new KodiJsonRpcHttpConnection();
            }

            return result;
        }
    }
}