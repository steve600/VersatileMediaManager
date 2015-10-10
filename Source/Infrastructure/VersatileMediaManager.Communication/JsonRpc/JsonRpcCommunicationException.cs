using System;
using System.Runtime.Serialization;

namespace VersatileMediaManager.Communication.JsonRpc
{
    [Serializable]
    public class JsonRpcCommunicationException : Exception
    {
        public JsonRpcCommunicationException()
            : base()
        { }

        public JsonRpcCommunicationException(string message)
            : base(message)
        { }

        public JsonRpcCommunicationException(string format, params object[] args)
            : base(string.Format(format, args))
        { }

        public JsonRpcCommunicationException(string message, Exception innerException)
            : base(message, innerException)
        { }

        public JsonRpcCommunicationException(string format, Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException)
        { }

        protected JsonRpcCommunicationException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        { }
    }
}