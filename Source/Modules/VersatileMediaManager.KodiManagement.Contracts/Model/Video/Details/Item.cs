using Newtonsoft.Json;
using System;

namespace VersatileMediaManager.KodiManagement.Contracts.Model.Video.Details
{
    public class Item : Media
    {
        private DateTimeOffset? dateAdded;

        [JsonProperty("dateadded")]
        public DateTimeOffset? DateAdded
        {
            get { return dateAdded; }
            set { this.SetProperty<DateTimeOffset?>(ref this.dateAdded, value); }
        }

        private string file;

        [JsonProperty("file")]
        public string File
        {
            get { return file; }
            set { this.SetProperty<string>(ref this.file, value); }
        }

        [JsonProperty("lastplayed")]
        private DateTimeOffset? lastPlayed;

        public DateTimeOffset? LastPlayed
        {
            get { return lastPlayed; }
            set { this.SetProperty<DateTimeOffset?>(ref this.lastPlayed, value); }
        }

        private string plot;

        [JsonProperty("plot")]
        public string Plot
        {
            get { return plot; }
            set { this.SetProperty<string>(ref this.plot, value); }
        }
    }
}