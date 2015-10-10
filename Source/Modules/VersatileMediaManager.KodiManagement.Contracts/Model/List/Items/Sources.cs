using Newtonsoft.Json;
using Prism.Mvvm;

namespace VersatileMediaManager.KodiManagement.Contracts.Model.List.Items
{
    public class Sources : BindableBase
    {
        private string file;

        [JsonProperty("file")]
        public string File
        {
            get { return this.file; }
            set { this.SetProperty<string>(ref file, value); }
        }

        private string label;

        [JsonProperty("label")]
        public string Label
        {
            get { return this.label; }
            set { this.SetProperty<string>(ref this.label, value); }
        }
    }
}