using Newtonsoft.Json;
using Prism.Mvvm;

namespace VersatileMediaManager.KodiManagement.Contracts.Model
{
    public class JsonRpcApiVersion : BindableBase
    {
        [JsonProperty("major")]
        public int Major { get; set; }

        [JsonProperty("minor")]
        public int Minor { get; set; }

        [JsonProperty("patch")]
        public int Patch { get; set; }
    }
}