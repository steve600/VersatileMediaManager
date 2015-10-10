using Newtonsoft.Json;
using Prism.Mvvm;

namespace VersatileMediaManager.KodiManagement.Contracts.Model.Video
{
    public class Cast : BindableBase
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("role")]
        public string Role { get; set; }

        [JsonProperty("thumbnail")]
        public string Thumbnail { get; set; }
    }
}