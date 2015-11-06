using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net;
using System.Text;
using VersatileMediaManager.Communication.Interfaces;

namespace VersatileMediaManager.Communication.JsonRpc
{
    public class JsonRpcDataAdapter<T> : IDataAdapter<T, JsonRpcRequest, string, object, object[]>
    {
        #region Members and Constants

        private const int CallIdMaximum = 100000;
        private static int callId = 0;
        public Uri uri = null;

        #endregion Members and Constants

        #region CTOR

        private JsonRpcDataAdapter()
        {
        }

        /// <summary>
        /// CTOR
        /// </summary>
        /// <param name="connection"></param>
        public JsonRpcDataAdapter(IConnection connection)
        {
            this.Connection = connection;

            this.uri = new Uri(this.Connection.ConnectionSettings.URIString);
        }

        #endregion CTOR

        /// <summary>
        /// Execute JSON RPC call
        /// </summary>
        /// <param name="jsonRequest">The JSON RPC request</param>
        /// <returns></returns>
        public T Execute(JsonRpcRequest jsonRequest)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(this.uri);
                request.ContentType = "application/json";
                if (!String.IsNullOrEmpty(this.Connection.ConnectionSettings.UserName))
                    request.Credentials = new NetworkCredential(this.Connection.ConnectionSettings.UserName, this.Connection.ConnectionSettings.Password);
                request.KeepAlive = false;
                request.Method = "POST";
                request.Timeout = this.Connection.ConnectionSettings.Timeout;

                using (Stream requestStream = request.GetRequestStream())
                {
                    using (StreamWriter requestWriter = new StreamWriter(requestStream, Encoding.ASCII))
                    {
                        if (callId >= CallIdMaximum)
                        {
                            callId = 0;
                        }
                        callId += 1;

                        jsonRequest.Id = callId;

                        //this.LogMessage("JSON RPC call: " + call.ToString());
                        requestWriter.Write(Newtonsoft.Json.JsonConvert.SerializeObject(jsonRequest));
                    }
                }

                using (WebResponse response = request.GetResponse())
                {
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        using (StreamReader responseReader = new StreamReader(responseStream, Encoding.UTF8))
                        {
                            //return this.parseResponse(responseReader);
                            var json = JObject.Parse(responseReader.ReadToEnd()).ToObject<JsonRpcResponse>();

                            var serializer = new JsonSerializer
                            {
                                ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor
                            };

                            if (json.Error == null)
                            {
                                var result = JObject.Parse(json.Result.ToString()).ToObject<T>();
                                return result;
                            }
                            else
                            {
                                throw json.Error;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string exceptionMessage = String.Format(@"Error while calling \\n\\n JSON RPC method {0} \\n\\n with parameters \\n\\n {1}", jsonRequest.Method, jsonRequest.Params);
                throw new JsonRpcCommunicationException(exceptionMessage, ex);
            }
        }

        /// <summary>
        /// Execute JSON RPC call
        /// </summary>
        /// <param name="method">The method</param>
        /// <param name="args">The params</param>
        /// <returns></returns>
        public T Execute(string method, object[] args)
        {
            var req = new JsonRpcRequest()
            {
                Method = method,
                Params = args
            };

            return Execute(req);
        }

        /// <summary>
        /// Execute JSON RPC call
        /// </summary>
        /// <param name="method">The method</param>
        /// <param name="arg">The param</param>
        /// <returns></returns>
        public T Execute(string method, object arg)
        {
            var req = new JsonRpcRequest()
            {
                Method = method,
                Params = new object[] { arg }
            };

            return Execute(req);
        }

        /// <summary>
        /// Execute JSON RPC call
        /// </summary>
        /// <param name="method">The method</param>
        /// <param name="arg">The param</param>
        /// <returns></returns>
        public T Execute(JsonRpcRequest request, string method)
        {
            throw new NotImplementedException();
        }

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
    }
}