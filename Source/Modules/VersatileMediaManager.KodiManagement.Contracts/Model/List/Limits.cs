using Newtonsoft.Json;
using Prism.Mvvm;

namespace VersatileMediaManager.KodiManagement.Contracts.Model.List
{
    public class Limits : BindableBase
    {
        public Limits(int start = 0, int end = -1)
        {
            Start = start;
            End = end;
        }

        private int start;

        [JsonProperty("start")]
        public int Start
        {
            get { return this.start; }
            set { this.SetProperty<int>(ref start, value); }
        }

        private int end;

        [JsonProperty("end")]
        public int End
        {
            get { return this.end; }
            set { this.SetProperty<int>(ref this.end, value); }
        }
    }
}