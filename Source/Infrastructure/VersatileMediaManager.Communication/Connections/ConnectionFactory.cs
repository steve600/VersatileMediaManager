using VersatileMediaManager.Communication.Interfaces;

namespace VersatileMediaManager.Communication.Connections
{
    /// <summary>
    /// Factory for creating the different connection types
    /// </summary>
    public class ConnectionFactory : IConnectionFactory
    {
        public IConnection GetConnection(ConnectionKindsEnum connectionKind, ConnectionTypesEnum connectionType)
        {
            IConnection result = null;

            if (connectionKind == ConnectionKindsEnum.KodiMediaPlayer && connectionType == ConnectionTypesEnum.JsonRpcHttp)
            {
                result = new KodiJsonRpcHttpConnection();
            }

            if (connectionKind == ConnectionKindsEnum.Enigma2WebInterface || 
                (connectionKind == ConnectionKindsEnum.Enigma2WebInterface && connectionType == ConnectionTypesEnum.Http))
            {
                result = new Enigma2WebIfHttpConnection();
            }

            return result;
        }
    }
}