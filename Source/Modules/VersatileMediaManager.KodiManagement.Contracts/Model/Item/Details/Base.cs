using Newtonsoft.Json;
using Prism.Mvvm;

namespace VersatileMediaManager.KodiManagement.Contracts.Model.Item.Details
{
    public class Base : BindableBase
    {
        private string label;

        /// <summary>
        /// Label
        /// </summary>
        [JsonProperty("label")]
        public string Label
        {
            get { return label; }
            set { this.SetProperty<string>(ref this.label, value); }
        }
    }
}