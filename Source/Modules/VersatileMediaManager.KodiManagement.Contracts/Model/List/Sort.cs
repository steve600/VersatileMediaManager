using Newtonsoft.Json;

namespace VersatileMediaManager.KodiManagement.Contracts.Model.List
{
    public class Sort
    {
        private string order = "ascending";

        [JsonProperty("order")]
        public string Order
        {
            get { return order; }
            set { order = value; }
        }

        private bool ignoreArticle = false;

        [JsonProperty("ignorearticle")]
        public bool IgnoreArticle
        {
            get { return ignoreArticle; }
            set { ignoreArticle = value; }
        }

        private string method = "none";

        [JsonProperty("method")]
        public string Method
        {
            get { return method; }
            set { method = value; }
        }
    }
}