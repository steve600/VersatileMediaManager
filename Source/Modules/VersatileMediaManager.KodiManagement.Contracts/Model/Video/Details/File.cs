using Newtonsoft.Json;

namespace VersatileMediaManager.KodiManagement.Contracts.Model.Video.Details
{
    public class File : Item
    {
        private Streams streamdetails;

        [JsonProperty("streamdetails")]
        public Streams Streamdetails
        {
            get { return streamdetails; }
            set { this.SetProperty<Streams>(ref this.streamdetails, value); }
        }

        private string[] director;

        [JsonProperty("director")]
        public string[] Director
        {
            get { return director; }
            set { this.SetProperty<string[]>(ref this.director, value); }
        }

        private Resume resume;

        [JsonProperty("resume")]
        public Resume Resume
        {
            get { return resume; }
            set { this.SetProperty<Resume>(ref this.resume, value); }
        }

        private int runtime;

        [JsonProperty("runtime")]
        public int Runtime
        {
            get { return runtime; }
            set { this.SetProperty<int>(ref this.runtime, value); }
        }
    }
}