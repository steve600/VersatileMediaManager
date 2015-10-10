using Microsoft.Practices.Unity;
using System.Collections.ObjectModel;
using VersatileMediaManager.Infrastructure.Base;
using VersatileMediaManager.Infrastructure.Contracts.Constants;
using VersatileMediaManager.Infrastructure.Contracts.Interfaces;
using VersatileMediaManager.KodiManagement.Contracts.Interfaces;
using VersatileMediaManager.KodiManagement.Contracts.Model.Video.Details;

namespace VersatileMediaManager.KodiManagement.ViewModels
{
    public class MovieLibraryManagementFlyoutViewModel : VersatileMediaManagerFlyoutViewModel, IFlyoutViewModel
    {
        #region Members and Constants

        private IKodiMovieLibraryManagementService movieManagementService = null;

        #endregion Members and Constants

        #region CTOR

        /// <summary>
        /// Standard CTOR
        /// </summary>
        public MovieLibraryManagementFlyoutViewModel()
        {
            this.movieManagementService = UnityContainer.Resolve<IKodiMovieLibraryManagementService>(ServiceNames.KodiMovieLibraryManagementJsonService);

            // Select all movies
            //this.Movies = movieManagementService.GetAllMovies();
        }

        #endregion CTOR

        /// <summary>
        /// Load movie data
        /// </summary>
        private void LoadData()
        {
            this.Movies = new ObservableCollection<Movie>(this.movieManagementService.GetAllMovies());
        }

        #region Properties

        private bool isOpen;

        /// <summary>
        /// IsOpen flag
        /// </summary>
        public bool IsOpen
        {
            get { return isOpen; }
            set
            {
                if (this.SetProperty<bool>(ref this.isOpen, value))
                {
                    if (this.IsOpen)
                    {
                        this.LoadData();
                    }
                }
            }
        }

        private ObservableCollection<Movie> movies = new ObservableCollection<Movie>();

        /// <summary>
        /// List with movies
        /// </summary>
        public ObservableCollection<Movie> Movies
        {
            get { return movies; }
            set { this.SetProperty<ObservableCollection<Movie>>(ref this.movies, value); }
        }

        #endregion Properties
    }
}