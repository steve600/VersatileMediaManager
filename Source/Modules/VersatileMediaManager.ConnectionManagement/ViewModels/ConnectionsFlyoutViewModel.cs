using Microsoft.Practices.Unity;
using Prism.Commands;
using System.Collections.ObjectModel;
using System.Windows.Input;
using VersatileMediaManager.Communication.Interfaces;
using VersatileMediaManager.Infrastructure.Base;
using VersatileMediaManager.Infrastructure.Contracts.Constants;

namespace VersatileMediaManager.ConnectionManagement.ViewModels
{
    public class ConnectionsFlyoutViewModel : VersatileMediaManagerViewModelBase
    {
        #region Members and Constants

        private IConnectionManager connectionManager = null;

        #endregion Members and Constants

        #region CTOR

        /// <summary>
        /// CTOR
        /// </summary>
        public ConnectionsFlyoutViewModel()
        {
            // Intitialize commands
            this.InitializeCommands();

            // Connection manager
            this.connectionManager = this.UnityContainer.Resolve<IConnectionManager>(GlobalConstants.ConnectionManager);
        }

        #endregion CTOR

        #region Commands

        /// <summary>
        /// Initialize commands
        /// </summary>
        private void InitializeCommands()
        {
            this.ShowAddConnectionDialogCommand = new DelegateCommand(this.ShowAddConnectionDialog, this.ShowAddConnectionDialogCanExecute);
            this.DeleteConnectionCommand = new DelegateCommand(this.DeleteConnection, this.DeleteConnectionCanExecute);
        }

        /// <summary>
        /// Check can execute of a command changed
        /// </summary>
        private void CheckRaiseCanExecuteChanged()
        {
            ((DelegateCommand)this.DeleteConnectionCommand).RaiseCanExecuteChanged();
        }

        /// <summary>
        /// Show add connection popup command
        /// </summary>
        public ICommand ShowAddConnectionDialogCommand { get; private set; }

        /// <summary>
        /// Checks if add connection can be executed
        /// </summary>
        /// <returns></returns>
        private bool ShowAddConnectionDialogCanExecute()
        {
            return true;
        }

        /// <summary>
        /// Show add connection popup
        /// </summary>
        private void ShowAddConnectionDialog()
        {
            var view = new Views.AddConnection();

            this.RegionManager.AddToRegion(RegionNames.DialogPopupRegion, view);
            this.RegionManager.Regions[RegionNames.DialogPopupRegion].Activate(view);
        }

        /// <summary>
        /// Delete connection command
        /// </summary>
        public ICommand DeleteConnectionCommand { get; private set; }

        /// <summary>
        /// Checks if delete connection can be executed
        /// </summary>
        /// <returns></returns>
        private bool DeleteConnectionCanExecute()
        {
            return this.SelectedConnection != null;
        }

        /// <summary>
        /// Delete a connection
        /// </summary>
        private void DeleteConnection()
        {
            this.connectionManager.DeleteConnection(this.SelectedConnection);
        }

        #endregion Commands

        #region Properties

        /// <summary>
        /// List with connections
        /// </summary>
        public ObservableCollection<IConnection> Connections
        {
            get
            {
                return this.connectionManager.Connections;
            }
        }

        private IConnection selectedConnection;

        /// <summary>
        /// The selected connection
        /// </summary>
        public IConnection SelectedConnection
        {
            get { return selectedConnection; }
            set
            {
                if (this.SetProperty<IConnection>(ref this.selectedConnection, value))
                {
                    this.CheckRaiseCanExecuteChanged();
                }
            }
        }

        #endregion Properties
    }
}