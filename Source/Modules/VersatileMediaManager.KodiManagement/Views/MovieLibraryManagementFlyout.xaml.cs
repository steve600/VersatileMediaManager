using MahApps.Metro.Controls;
using VersatileMediaManager.Infrastructure.Contracts.Constants;
using VersatileMediaManager.Infrastructure.Contracts.Interfaces;

namespace VersatileMediaManager.KodiManagement.Views
{
    /// <summary>
    /// Interaktionslogik für KodiMovieLibraryManagementFlyout.xaml
    /// </summary>
    public partial class MovieLibraryManagementFlyout : Flyout, IFlyoutView
    {
        public MovieLibraryManagementFlyout()
        {
            InitializeComponent();
            this.DataContext = new ViewModels.MovieLibraryManagementFlyoutViewModel();
        }

        /// <summary>
        /// The flyout name
        /// </summary>
        public string FlyoutName
        {
            get
            {
                return FlyoutNames.KodiMovieLibraryManagementFlyout;
            }
        }
    }
}