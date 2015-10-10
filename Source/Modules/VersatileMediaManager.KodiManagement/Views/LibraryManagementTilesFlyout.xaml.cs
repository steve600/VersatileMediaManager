using MahApps.Metro.Controls;
using VersatileMediaManager.Infrastructure.Contracts.Constants;
using VersatileMediaManager.Infrastructure.Contracts.Interfaces;

namespace VersatileMediaManager.KodiManagement.Views
{
    /// <summary>
    /// Interaktionslogik für LibraryManagementTilesFyout.xaml
    /// </summary>
    public partial class LibraryManagementTilesFyout : Flyout, IFlyoutView
    {
        public LibraryManagementTilesFyout()
        {
            InitializeComponent();
            this.DataContext = new ViewModels.LibraryManagementTilesViewModel();
        }

        /// <summary>
        /// The flyout name
        /// </summary>
        public string FlyoutName
        {
            get
            {
                return FlyoutNames.KodiManagementFlyout;
            }
        }
    }
}