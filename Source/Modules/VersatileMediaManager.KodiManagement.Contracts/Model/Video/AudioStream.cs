using Newtonsoft.Json;

namespace VersatileMediaManager.KodiManagement.Contracts.Model.Video
{
    public class AudioStream
    {
        private int channels;

        [JsonProperty("channels")]
        public int Channels
        {
            get { return channels; }
            set { channels = value; }
        }

        private string codec;

        [JsonProperty("codec")]
        public string Codec
        {
            get { return codec; }
            set { codec = value; }
        }

        private string language;

        [JsonProperty("language")]
        public string Language
        {
            get { return language; }
            set { language = value; }
        }
    }
}