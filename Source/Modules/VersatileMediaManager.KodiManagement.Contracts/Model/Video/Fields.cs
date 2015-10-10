namespace VersatileMediaManager.KodiManagement.Contracts.Model.Video
{
    /// <summary>
    /// Contains field definitions.
    /// </summary>
    public static class Fields
    {
        /// <summary>
        /// Returns all requestable fields for movie requests (Video.Fields.Movie)
        /// </summary>
        public static string[] Movie
        {
            get
            {
                return new[]
                {
                  "title",
                  "genre",
                  "year",
                  "rating",
                  "director",
                  "trailer",
                  "tagline",
                  "plot",
                  "plotoutline",
                  "originaltitle",
                  "lastplayed",
                  "playcount",
                  "writer",
                  "studio",
                  "mpaa",
                  "cast",
                  "country",
                  "imdbnumber",
                  "runtime",
                  "set",
                  "showlink",
                  "streamdetails",
                  "top250",
                  "votes",
                  "fanart",
                  "thumbnail",
                  "file",
                  "sorttitle",
                  "resume",
                  "setid",
                  "dateadded",
                  "tag",
                  "art"
               };
            }
        }
    }
}