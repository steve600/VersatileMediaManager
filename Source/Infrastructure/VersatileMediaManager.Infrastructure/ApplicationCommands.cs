using Prism.Commands;

namespace VersatileMediaManager.Infrastructure
{
    /// <summary>
    /// Class with global application commands
    /// </summary>
    public static class ApplicationCommands
    {
        /// <summary>
        /// Show flyout command
        /// </summary>
        public static CompositeCommand ShowFlyoutCommand = new CompositeCommand();

        /// <summary>
        /// Open connection commands
        /// </summary>
        public static CompositeCommand OpenConnectionCommand = new CompositeCommand();

        /// <summary>
        /// Show project on GitHub
        /// </summary>
        public static DelegateCommand ShowOnGitHubCommand = new DelegateCommand(ShowOnGitHub);

        /// <summary>
        /// Show application info
        /// </summary>
        public static CompositeCommand ShowApplicationInfoCommand = new CompositeCommand();

        /// <summary>
        /// Show application help
        /// </summary>
        public static CompositeCommand ShowApplicationHelpCommand = new CompositeCommand();

        /// <summary>
        /// Show on GitHub
        /// </summary>
        private static void ShowOnGitHub()
        {
            System.Diagnostics.Process.Start("https://github.com/steve600/VersatileMediaManager");
        }
    }

    public interface IApplicationCommands
    {
        CompositeCommand ShowFlyoutCommand { get; }
        CompositeCommand OpenConnectionCommand { get; }
        DelegateCommand ShowOnGitHubCommand { get; }
        CompositeCommand ShowApplicationInfoCommand { get; }
        CompositeCommand ShowApplicationHelpCommand { get; }
    }

    public class ApplicationCommandsProxy : IApplicationCommands
    {
        /// <summary>
        /// Show flyout command
        /// </summary>
        public CompositeCommand ShowFlyoutCommand
        {
            get { return ApplicationCommands.ShowFlyoutCommand; }
        }

        /// <summary>
        /// Show flyout command
        /// </summary>
        public CompositeCommand OpenConnectionCommand
        {
            get { return ApplicationCommands.OpenConnectionCommand; }
        }

        /// <summary>
        /// Show project on GitHub
        /// </summary>
        public DelegateCommand ShowOnGitHubCommand
        {
            get { return ApplicationCommands.ShowOnGitHubCommand; }
        }

        /// <summary>
        /// Show application info command
        /// </summary>
        public CompositeCommand ShowApplicationInfoCommand
        {
            get { return ApplicationCommands.ShowApplicationInfoCommand; }
        }

        /// <summary>
        /// Show application help command
        /// </summary>
        public CompositeCommand ShowApplicationHelpCommand
        {
            get { return ApplicationCommands.ShowApplicationHelpCommand; }
        }
    }
}