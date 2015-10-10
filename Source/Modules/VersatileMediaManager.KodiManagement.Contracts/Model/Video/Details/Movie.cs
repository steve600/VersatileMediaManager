using Newtonsoft.Json;

namespace VersatileMediaManager.KodiManagement.Contracts.Model.Video.Details
{
    public class Movie : File
    {
        private string plotOutline = string.Empty;

        [JsonProperty("plotoutline")]
        public string PlotOutline
        {
            get { return this.plotOutline; }
            set { this.SetProperty<string>(ref this.plotOutline, value); }
        }

        private string sortTitle = string.Empty;

        [JsonProperty("sorttitle")]
        public string SortTitle
        {
            get { return this.sortTitle; }
            set { this.SetProperty<string>(ref this.sortTitle, value); }
        }

        private int movieId;

        [JsonProperty("movieid")]
        public int MovieId
        {
            get { return this.movieId; }
            set { this.SetProperty<int>(ref this.movieId, value); }
        }

        private Cast[] cast = null;

        [JsonProperty("cast")]
        public Cast[] Cast
        {
            get { return this.cast; }
            set { this.SetProperty<Cast[]>(ref this.cast, value); }
        }

        private string votes = string.Empty;

        [JsonProperty("votes")]
        public string Votes
        {
            get { return this.votes; }
            set { this.SetProperty<string>(ref this.votes, value); }
        }

        [JsonProperty("showlink")]
        public string[] ShowLink { get; set; }

        private int? top250 = null;

        [JsonProperty("top250")]
        public int? Top250
        {
            get { return this.top250; }
            set { this.SetProperty<int?>(ref this.top250, value); }
        }

        private string trailer = string.Empty;

        [JsonProperty("trailer")]
        public string Trailer
        {
            get { return this.trailer; }
            set { this.SetProperty<string>(ref this.trailer, value); }
        }

        private int? year = null;

        [JsonProperty("year")]
        public int? Year
        {
            get { return this.year; }
            set { this.SetProperty<int?>(ref this.year, value); }
        }

        private string[] country;

        [JsonProperty("country")]
        public string[] Country
        {
            get { return this.country; }
            set { this.SetProperty<string[]>(ref this.country, value); }
        }

        private string[] studio;

        [JsonProperty("studio")]
        public string[] Studio
        {
            get { return this.studio; }
            set { this.SetProperty<string[]>(ref this.studio, value); }
        }

        private string set = string.Empty;

        [JsonProperty("set")]
        public string Set
        {
            get { return this.set; }
            set { this.SetProperty<string>(ref this.set, value); }
        }

        private string[] genre = null;

        [JsonProperty("genre")]
        public string[] Genre
        {
            get { return this.genre; }
            set { this.SetProperty<string[]>(ref this.genre, value); }
        }

        private string mpaa = string.Empty;

        [JsonProperty("mpaa")]
        public string MPAA
        {
            get { return this.mpaa; }
            set { this.SetProperty<string>(ref this.mpaa, value); }
        }

        private int? setId = null;

        [JsonProperty("setid")]
        public int? SetId
        {
            get { return this.setId; }
            set { this.SetProperty<int?>(ref this.setId, value); }
        }

        private decimal rating;

        [JsonProperty("rating")]
        public decimal Rating
        {
            get { return this.rating; }
            set { this.SetProperty<decimal>(ref this.rating, value); }
        }

        private string[] tag = null;

        [JsonProperty("tag")]
        public string[] Tag
        {
            get { return this.tag; }
            set { this.SetProperty<string[]>(ref this.tag, value); }
        }

        private string tagLine = string.Empty;

        [JsonProperty("tagline")]
        public string TagLine
        {
            get { return this.tagLine; }
            set { this.SetProperty<string>(ref this.tagLine, value); }
        }

        private string[] writer = null;

        [JsonProperty("writer")]
        public string[] Writer
        {
            get { return this.writer; }
            set { this.SetProperty<string[]>(ref this.writer, value); }
        }

        private string originalTitle = string.Empty;

        [JsonProperty("originaltitle")]
        public string OriginalTitle
        {
            get { return this.originalTitle; }
            set { this.SetProperty<string>(ref this.originalTitle, value); }
        }

        private string imdbNumber = string.Empty;

        [JsonProperty("imdbnumber")]
        public string ImdbNumber
        {
            get { return this.imdbNumber; }
            set { this.SetProperty<string>(ref this.imdbNumber, value); }
        }
    }
}