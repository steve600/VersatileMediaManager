using Newtonsoft.Json;

namespace VersatileMediaManager.KodiManagement.Contracts.Model.Video
{
    public class SubtitleStream
    {
        private string language;

        [JsonProperty("language")]
        public string Language
        {
            get { return language; }
            set { language = value; }
        }
    }
}