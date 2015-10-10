using Newtonsoft.Json;

namespace VersatileMediaManager.KodiManagement.Contracts.Model.Video.Details
{
    public class Media : Base
    {
        private string title = string.Empty;

        [JsonProperty("title")]
        public string Title
        {
            get { return this.title; }
            set { this.SetProperty<string>(ref this.title, value); }
        }
    }
}