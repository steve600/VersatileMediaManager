using Newtonsoft.Json;
using Prism.Mvvm;

namespace VersatileMediaManager.KodiManagement.Contracts.Model.Media
{
    public class Artwork : BindableBase
    {
        private string banner;

        /// <summary>
        /// Banner
        /// </summary>
        [JsonProperty("banner")]
        public string Banner
        {
            get { return banner; }
            set { this.SetProperty<string>(ref this.banner, value); }
        }

        private string poster;

        /// <summary>
        /// Poster
        /// </summary>
        [JsonProperty("poster")]
        public string Poster
        {
            get { return poster; }
            set { this.SetProperty<string>(ref this.poster, value); }
        }

        private string fanArt;

        /// <summary>
        /// Fanart
        /// </summary>
        [JsonProperty("fanart")]
        public string FanArt
        {
            get { return fanArt; }
            set { this.SetProperty<string>(ref this.fanArt, value); }
        }

        private string thumbnail;

        /// <summary>
        /// Thumbnail
        /// </summary>
        [JsonProperty("thumb")]
        public string Thumbnail
        {
            get { return thumbnail; }
            set { this.SetProperty<string>(ref this.thumbnail, value); }
        }
    }
}