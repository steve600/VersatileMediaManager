using MahApps.Metro.Controls;
using VersatileMediaManager.Infrastructure.Contracts.Constants;
using VersatileMediaManager.Infrastructure.Contracts.Interfaces;

namespace VersatileMediaManager.Shell.Views
{
    /// <summary>
    /// Interaktionslogik für ShellSettingsFlyout.xaml
    /// </summary>
    public partial class ShellSettingsFlyout : Flyout, IFlyoutView
    {
        public ShellSettingsFlyout()
        {
            InitializeComponent();
        }

        public string FlyoutName
        {
            get
            {
                return FlyoutNames.ShellSettingsFlyout;
            }
        }
    }
}