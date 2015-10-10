using Newtonsoft.Json;
using Prism.Mvvm;

namespace VersatileMediaManager.KodiManagement.Contracts.Model.Library.Details
{
    public class Genre : BindableBase
    {
        private int genreId;

        /// <summary>
        /// GenreId
        /// </summary>
        [JsonProperty("genreid")]
        public int GenreId
        {
            get { return genreId; }
            set { base.SetProperty<int>(ref this.genreId, value); }
        }

        private string thumbnail;

        /// <summary>
        /// Thumbnail
        /// </summary>
        [JsonProperty("thumbnail")]
        public string Thumbnail
        {
            get { return thumbnail; }
            set { base.SetProperty<string>(ref this.thumbnail, value); }
        }

        private string title;

        /// <summary>
        /// Title
        /// </summary>
        [JsonProperty("title")]
        public string Title
        {
            get { return title; }
            set { base.SetProperty<string>(ref this.title, value); }
        }

        #region Interface IIsSelectable

        private bool isSelected = false;

        [JsonIgnoreAttribute]
        public bool IsSelected
        {
            get
            {
                return this.isSelected;
            }
            set
            {
                this.SetProperty<bool>(ref this.isSelected, value);
            }
        }

        #endregion Interface IIsSelectable
    }
}