using Newtonsoft.Json;
using Prism.Mvvm;

namespace VersatileMediaManager.KodiManagement.Contracts.Model.Video
{
    public class Resume : BindableBase
    {
        private int position;

        [JsonProperty("position")]
        public int Position
        {
            get { return position; }
            set { this.SetProperty<int>(ref this.position, value); }
        }

        private int total;

        [JsonProperty("total")]
        public int Total
        {
            get { return total; }
            set { this.SetProperty<int>(ref this.total, value); }
        }
    }
}