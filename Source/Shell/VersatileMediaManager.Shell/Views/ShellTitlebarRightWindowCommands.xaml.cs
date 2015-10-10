using System.Windows.Controls;

namespace VersatileMediaManager.Shell.Views
{
    /// <summary>
    /// Interaktionslogik für ShellTitlebarRightWindowCommands.xaml
    /// </summary>
    public partial class ShellTitlebarRightWindowCommands : StackPanel
    {
        public ShellTitlebarRightWindowCommands()
        {
            InitializeComponent();
            this.DataContext = new ViewModels.ShellTitlebarRightWindowCommandsViewModel();
        }
    }
}