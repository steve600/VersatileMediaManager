using Newtonsoft.Json;

namespace VersatileMediaManager.Communication.JsonRpc
{
    public class JsonRpcRequest
    {
        public JsonRpcRequest()
        {
        }

        /// <summary>
        /// JSON-RPC Version
        /// </summary>
        [JsonProperty("jsonrpc", Required = Required.Always)]
        public string JsonRPC { get { return "2.0"; } }

        /// <summary>
        /// The id of the call
        /// </summary>
        [JsonProperty("id", Required = Required.Always)]
        public int Id { get; set; }

        /// <summary>
        /// The rpc method.
        /// </summary>
        [JsonProperty("method", Required = Required.Always)]
        public string Method { get; set; }

        /// <summary>
        /// Any parameters, optional.
        /// </summary>
        [JsonProperty("params")]
        public object Params { get; set; }

        /// <summary>
        /// ToString-Method
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}