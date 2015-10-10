using Newtonsoft.Json;
using VersatileMediaManager.KodiManagement.Contracts.Model.List;
using VersatileMediaManager.KodiManagement.Contracts.Model.Video.Details;

namespace VersatileMediaManager.KodiManagement.Contracts.Model.JsonResults
{
    public class MovieResult
    {
        [JsonProperty("limits")]
        public LimitsReturned Limits { get; set; }

        [JsonProperty("movies")]
        public Movie[] Movies { get; set; }
    }
}