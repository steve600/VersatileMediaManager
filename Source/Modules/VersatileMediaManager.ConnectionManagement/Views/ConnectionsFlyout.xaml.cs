using MahApps.Metro.Controls;
using VersatileMediaManager.Infrastructure.Contracts.Constants;
using VersatileMediaManager.Infrastructure.Contracts.Interfaces;

namespace VersatileMediaManager.ConnectionManagement.Views
{
    /// <summary>
    /// Interaktionslogik für ConnectionsFlyout.xaml
    /// </summary>
    public partial class ConnectionsFlyout : Flyout, IFlyoutView
    {
        public ConnectionsFlyout()
        {
            InitializeComponent();
        }

        public string FlyoutName
        {
            get
            {
                return FlyoutNames.ConnectionFlyout;
            }
        }
    }
}