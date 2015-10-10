using Newtonsoft.Json;
using Prism.Mvvm;

namespace VersatileMediaManager.KodiManagement.Contracts.Model.List
{
    public class LimitsReturned : BindableBase
    {
        [JsonProperty("start")]
        public int Start { get; set; }

        [JsonProperty("end")]
        public int End { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }
    }
}