using Newtonsoft.Json;
using Prism.Mvvm;

namespace VersatileMediaManager.KodiManagement.Contracts.Model.Video
{
    public class Streams : BindableBase
    {
        private AudioStream[] audio;

        [JsonProperty("audio")]
        public AudioStream[] Audio
        {
            get { return audio; }
            set { this.SetProperty<AudioStream[]>(ref this.audio, value); }
        }

        private VideoStream[] video;

        [JsonProperty("video")]
        public VideoStream[] Video
        {
            get { return video; }
            set { this.SetProperty<VideoStream[]>(ref this.video, value); }
        }

        private SubtitleStream[] subtitle;

        [JsonProperty("subtitle")]
        public SubtitleStream[] Subtitle
        {
            get { return subtitle; }
            set { this.SetProperty<SubtitleStream[]>(ref this.subtitle, value); }
        }
    }
}