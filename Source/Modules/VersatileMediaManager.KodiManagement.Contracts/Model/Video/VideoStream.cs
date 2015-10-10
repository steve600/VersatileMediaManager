using Newtonsoft.Json;

namespace VersatileMediaManager.KodiManagement.Contracts.Model.Video
{
    public class VideoStream
    {
        private string aspect;

        [JsonProperty("aspect")]
        public string Aspect
        {
            get { return aspect; }
            set { aspect = value; }
        }

        private string codec;

        [JsonProperty("codec")]
        public string Codec
        {
            get { return codec; }
            set { codec = value; }
        }

        private int duration;

        [JsonProperty("duration")]
        public int Duration
        {
            get { return duration; }
            set { duration = value; }
        }

        private int height;

        [JsonProperty("height")]
        public int Height
        {
            get { return height; }
            set { height = value; }
        }

        private int width;

        [JsonProperty("width")]
        public int Width
        {
            get { return width; }
            set { width = value; }
        }
    }
}