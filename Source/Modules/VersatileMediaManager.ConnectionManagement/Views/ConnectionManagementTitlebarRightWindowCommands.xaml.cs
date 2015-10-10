using System.Windows.Controls;

namespace VersatileMediaManager.ConnectionManagement.Views
{
    /// <summary>
    /// Interaktionslogik für ConnectionManagementTitlebarRightWindowCommands.xaml
    /// </summary>
    public partial class ConnectionManagementTitlebarRightWindowCommands : StackPanel
    {
        public ConnectionManagementTitlebarRightWindowCommands()
        {
            InitializeComponent();
            this.DataContext = new ViewModels.ConnectionManagementTitlebarRightWindowCommandsViewModel();
        }
    }
}