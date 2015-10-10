using Microsoft.Practices.Unity;
using Prism.Commands;
using System.Windows.Input;
using VersatileMediaManager.Communication.Interfaces;
using VersatileMediaManager.ConnectionManagement.Contracts.Events;
using VersatileMediaManager.Infrastructure.Base;
using VersatileMediaManager.Infrastructure.Contracts.Constants;

namespace VersatileMediaManager.ConnectionManagement.ViewModels
{
    public class AddConnectionViewModel : VersatileMediaManagerPopupViewModel
    {
        #region Members and Constants

        private IConnectionManager connectionManager = null;

        #endregion Members and Constants

        #region CTOR

        /// <summary>
        /// CTOR
        /// </summary>
        public AddConnectionViewModel()
        {
            // Initialize commands
            this.InitializeCommands();

            this.connectionManager = UnityContainer.Resolve<IConnectionManager>(GlobalConstants.ConnectionManager);

            this.ConnectionKind = ConnectionKindsEnum.KodiMediaPlayer;
            this.ConnectionType = ConnectionTypesEnum.JsonRpcHttp;
        }

        #endregion CTOR

        #region Commands

        /// <summary>
        /// Initialize commands
        /// </summary>
        private void InitializeCommands()
        {
            this.AddConnectionCommand = new DelegateCommand(this.AddConnection, this.CanAddConnection);
        }

        /// <summary>
        /// Add connection command
        /// </summary>
        public ICommand AddConnectionCommand { get; private set; }

        /// <summary>
        /// Add connection can execute
        /// </summary>
        /// <returns></returns>
        private bool CanAddConnection()
        {
            return true;
        }

        /// <summary>
        /// Add connection
        /// </summary>
        private void AddConnection()
        {
            // Add connection
            this.connectionManager.AddConnection(this.NewConnection);

            // Close popup
            this.ClosePopupCommand.Execute(null);
        }

        #endregion Commands

        /// <summary>
        /// Get connection
        /// </summary>
        private void GetConnection()
        {
            if (this.ConnectionKind != null && this.ConnectionType != null)
            {
                var connection = this.connectionManager.CreateConnection(this.ConnectionKind.Value, this.ConnectionType.Value);

                // Apply settings for the new connection
                this.ConnectionKind = connection.ConnectionSettings.ConnectionKind;
                this.ConnectionType = connection.ConnectionSettings.ConnectionType;
                connection.ConnectionSettings.Name = this.NewConnection?.ConnectionSettings.Name ?? string.Empty;
                connection.ConnectionSettings.Host = this.NewConnection?.ConnectionSettings.Host ?? string.Empty;
                connection.ConnectionSettings.Port = this.NewConnection?.ConnectionSettings.Port ?? default(int);
                connection.ConnectionSettings.UserName = this.NewConnection?.ConnectionSettings.UserName ?? string.Empty;
                connection.ConnectionSettings.Password = this.NewConnection?.ConnectionSettings.Password ?? string.Empty;
                connection.ConnectionSettings.Timeout = this.NewConnection?.ConnectionSettings.Timeout ?? 10000;

                this.NewConnection = connection;
            }
        }

        #region Properties

        private IConnection newConnection;

        /// <summary>
        /// The new connection
        /// </summary>
        public IConnection NewConnection
        {
            get { return newConnection; }
            set { this.SetProperty<IConnection>(ref this.newConnection, value); }
        }

        /// <summary>
        /// Title
        /// </summary>
        public override string Title
        {
            get
            {
                return "Verbindung hinzufügen";
            }
        }

        private ConnectionKindsEnum? connectionKind = null;

        /// <summary>
        /// Connection kind
        /// </summary>
        public ConnectionKindsEnum? ConnectionKind
        {
            get { return connectionKind; }
            set
            {
                if (this.SetProperty<ConnectionKindsEnum?>(ref this.connectionKind, value))
                {
                    this.GetConnection();
                }
            }
        }

        private ConnectionTypesEnum? connectionType = null;

        /// <summary>
        /// The connection type
        /// </summary>
        public ConnectionTypesEnum? ConnectionType
        {
            get { return connectionType; }
            set
            {
                if (this.SetProperty<ConnectionTypesEnum?>(ref this.connectionType, value))
                {
                    this.GetConnection();
                }
            }
        }

        #endregion Properties
    }
}