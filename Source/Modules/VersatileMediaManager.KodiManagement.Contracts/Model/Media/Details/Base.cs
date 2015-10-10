using Newtonsoft.Json;
using Prism.Mvvm;

namespace VersatileMediaManager.KodiManagement.Contracts.Model.Media.Details
{
    public class Base : BindableBase
    {
        private string fanart;

        /// <summary>
        /// Fanart
        /// </summary>
        [JsonProperty("fanart")]
        public string Fanart
        {
            get { return fanart; }
            set { base.SetProperty<string>(ref this.fanart, value); }
        }

        private string thumbnail;

        /// <summary>
        /// Thumbnail
        /// </summary>
        [JsonProperty("thumbnail")]
        public string Thumbnail
        {
            get { return thumbnail; }
            set { base.SetProperty<string>(ref this.thumbnail, value); }
        }
    }
}