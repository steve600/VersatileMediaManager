using Newtonsoft.Json;
using Prism.Mvvm;
using VersatileMediaManager.KodiManagement.Contracts.Model.Media;

namespace VersatileMediaManager.KodiManagement.Contracts.Model.Video.Details
{
    public class Base : BindableBase
    {
        private int? playcount;

        [JsonProperty("playcount")]
        public int? Playcount
        {
            get { return playcount; }
            set { base.SetProperty<int?>(ref this.playcount, value); }
        }

        private Artwork art;

        [JsonProperty("art")]
        public Artwork Art
        {
            get { return art; }
            set { base.SetProperty<Artwork>(ref this.art, value); }
        }
    }
}