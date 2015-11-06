using Microsoft.Practices.Unity;
using Prism.Commands;
using System.Windows.Input;
using VersatileMediaManager.Infrastructure;
using VersatileMediaManager.Infrastructure.Base;
using VersatileMediaManager.Infrastructure.Contracts.Constants;
using VersatileMediaManager.Infrastructure.Contracts.Interfaces;

namespace VersatileMediaManager.HelpAndInfo.ViewModels
{
    public class ShellTitlebarRightWindowCommandsViewModel : VersatileMediaManagerViewModelBase
    {
        /// <summary>
        /// CTOR
        /// </summary>
        public ShellTitlebarRightWindowCommandsViewModel(IApplicationCommands applicationCommands)
        {
            this.ShowApplicationHelpCommand = new DelegateCommand(this.ShowApplicationHelp);
            this.ShowApplicationInfoCommand = new DelegateCommand(this.ShowApplicationInfo);

            applicationCommands.ShowApplicationHelpCommand.RegisterCommand(this.ShowApplicationHelpCommand);
            applicationCommands.ShowApplicationInfoCommand.RegisterCommand(this.ShowApplicationInfoCommand);
        }

        #region Commands

        /// <summary>
        /// Show help command
        /// </summary>
        public ICommand ShowApplicationHelpCommand { get; private set; }

        /// <summary>
        /// Show info command
        /// </summary>
        public ICommand ShowApplicationInfoCommand { get; private set; }

        private void ShowApplicationHelp()
        {
            this.UnityContainer.Resolve<IMessageDisplayService>(ServiceNames.MetroMessageDisplayService).ShowMessage("Not implemented", "Not yet implemented");
        }

        /// <summary>
        /// Show application information
        /// </summary>
        private void ShowApplicationInfo()
        {
            //var view = new Views.SystemInfo();

            //this.RegionManager.AddToRegion(RegionNames.DialogPopupRegion, view);
            //this.RegionManager.Regions[RegionNames.DialogPopupRegion].Activate(view);
            this.RegionManager.RequestNavigate(RegionNames.DialogPopupRegion, ViewNames.SystemInformationView);
        }

        #endregion Commands
    }
}