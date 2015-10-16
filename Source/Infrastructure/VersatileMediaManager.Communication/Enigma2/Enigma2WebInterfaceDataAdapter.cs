using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using VersatileMediaManager.Communication.Interfaces;

namespace VersatileMediaManager.Communication.Enigma2
{
    public enum Enigma2WebInterfacesMethods
    {
        GetDeviceInfo,
        GetTimerList,
        AddTimer,
        DeleteTimer
    }

    public class Enigma2WebInterfaceDataAdapter<T> : IDataAdapter<T, Enigma2WebInterfacesMethods, string, object, IDictionary<string, object>>, IDisposable
    {
        #region CTOR

        
        #region CTOR

        /// <summary>
        /// CTOR
        /// </summary>
        private Enigma2WebInterfaceDataAdapter()
        {
        }

        /// <summary>
        /// CTOR
        /// </summary>
        /// <param name="connection">The connection</param>
        public Enigma2WebInterfaceDataAdapter(IConnection connection)
        {
            this.Connection = connection;
        }

        #endregion CTOR

        #endregion CTOR

        public T Execute(Enigma2WebInterfacesMethods method)
        {
            T result = default(T);

            try
            {
                var uri = this.GetPostUri(method);
                
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
                
                request.KeepAlive = false;
                request.Method = "POST";
                //request.Timeout = this.Connection.ConnectionSettings.Timeout;

                using (WebResponse response = request.GetResponse())
                {
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        using (StreamReader responseReader = new StreamReader(responseStream, Encoding.UTF8))
                        {
                            //string resultString = responseReader.ReadToEnd();

                            // Deserialize XML
                            XmlSerializer xSerializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
                            
                            result = (T)xSerializer.Deserialize(responseReader);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                //string exceptionMessage = String.Format(@"Error while calling \\n\\n JSON RPC method {0} \\n\\n with parameters \\n\\n {1}", jsonRequest.Method, jsonRequest.Params);
                //throw new JsonRpcCommunicationException(exceptionMessage, ex);
            }

            return result;
        }

        public T Execute(string uri, IDictionary<string, object> t5)
        {
            throw new NotImplementedException();
        }

        public T Execute(string t3, object t4)
        {
            throw new NotImplementedException();
        }

        #region Properties

        private IConnection connection = null;

        /// <summary>
        /// The connection
        /// </summary>
        public IConnection Connection
        {
            get
            {
                return this.connection;
            }
            private set
            {
                this.connection = value;
            }
        }

        private string GetPostUri(Enigma2WebInterfacesMethods method)
        {
            string result = string.Empty;

            switch(method)
            {
                case Enigma2WebInterfacesMethods.GetDeviceInfo:
                    result = this.Connection.ConnectionSettings.URIString + "/web/deviceinfo";
                    break;
                case Enigma2WebInterfacesMethods.GetTimerList:
                    result = this.Connection.ConnectionSettings.URIString + "/web/timerlist";
                    break;
                default:
                    result = string.Empty;
                    break;

            }

            return result;
        }

        #region IDisposable Support

        private bool disposedValue = false; // Dient zur Erkennung redundanter Aufrufe.

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: verwalteten Zustand (verwaltete Objekte) entsorgen.
                }

                // TODO: nicht verwaltete Ressourcen (nicht verwaltete Objekte) freigeben und Finalizer weiter unten überschreiben.
                // TODO: große Felder auf Null setzen.

                disposedValue = true;
            }
        }

        // TODO: Finalizer nur überschreiben, wenn Dispose(bool disposing) weiter oben Code für die Freigabe nicht verwalteter Ressourcen enthält.
        // ~Enigma2WebInterfaceDataAdapter() {
        //   // Ändern Sie diesen Code nicht. Fügen Sie Bereinigungscode in Dispose(bool disposing) weiter oben ein.
        //   Dispose(false);
        // }

        // Dieser Code wird hinzugefügt, um das Dispose-Muster richtig zu implementieren.
        public void Dispose()
        {
            // Ändern Sie diesen Code nicht. Fügen Sie Bereinigungscode in Dispose(bool disposing) weiter oben ein.
            Dispose(true);
            // TODO: Auskommentierung der folgenden Zeile aufheben, wenn der Finalizer weiter oben überschrieben wird.
            // GC.SuppressFinalize(this);
        }

        #endregion

        #endregion Properties
    }
}
