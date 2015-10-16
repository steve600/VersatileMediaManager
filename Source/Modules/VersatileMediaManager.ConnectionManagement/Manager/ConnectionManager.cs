using Microsoft.Practices.Unity;
using Prism.Commands;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using System.Xml.Linq;
using VersatileMediaManager.Communication.Interfaces;
using VersatileMediaManager.ConnectionManagement.Contracts.Events;
using VersatileMediaManager.Infrastructure.Contracts.Constants;
using VersatileMediaManager.Infrastructure.Contracts.Events;
using VersatileMediaManager.Infrastructure.Contracts.Interfaces;

namespace VersatileMediaManager.ConnectionManagement.Manager
{
    public class ConnectionManager : IConnectionManager
    {
        #region Members and Constants

        private IConnectionFactory connectionFactory = null;
        private IEventAggregator eventAggregator = null;
        private IUnityContainer unityContainer = null;

        #endregion Members and Constants

        /// <summary>
        /// CTOR
        /// </summary>
        public ConnectionManager(IUnityContainer unityContainer, IConnectionFactory connectionFactory, IEventAggregator eventAggregator)
        {
            this.unityContainer = unityContainer;
            this.connectionFactory = connectionFactory;
            this.eventAggregator = eventAggregator;

            // Register commands
            Infrastructure.ApplicationCommands.OpenConnectionCommand.RegisterCommand(new DelegateCommand<IConnection>(OpenConnection, CanOpenConnection));

            // Read config file
            this.ReadConfigFile();
        }

        #region Commands

        public ICommand OpenConnectionCommand { get; private set; }

        /// <summary>
        /// Open connection
        /// </summary>
        /// <param name="connection"></param>
        private void OpenConnection(IConnection connection)
        {
            if (connection != null)
            {
                this.ActiveConnection = connection;

                switch (connection.ConnectionSettings.ConnectionKind)
                {
                    case ConnectionKindsEnum.KodiMediaPlayer:
                        Infrastructure.ApplicationCommands.ShowFlyoutCommand.Execute(FlyoutNames.KodiManagementFlyout);
                        break;
                    case ConnectionKindsEnum.Enigma2WebInterface:
                        Infrastructure.ApplicationCommands.ShowFlyoutCommand.Execute(FlyoutNames.PvrManagementFlyout);
                        break;
                }
            }
        }

        private bool CanOpenConnection(IConnection connection)
        {
            return true;
        }

        #endregion Commands

        #region Methods

        /// <summary>
        /// Read config file
        /// </summary>
        private void ReadConfigFile()
        {
            if (!System.IO.File.Exists(FileAndFolderConstants.ConnectionSettingsConfigFile))
            {
                this.CreateSettingsFile();
            }

            try
            {
                XElement xmlDoc = XElement.Load(FileAndFolderConstants.ConnectionSettingsConfigFile);

                foreach (var c in xmlDoc.Descendants("Connection"))
                {
                    ConnectionKindsEnum connectionKind;
                    Enum.TryParse<ConnectionKindsEnum>(c.Attribute("ConnectionKind")?.Value ?? string.Empty, out connectionKind);

                    ConnectionTypesEnum connectionType;
                    Enum.TryParse<ConnectionTypesEnum>(c.Attribute("ConnectionType")?.Value ?? string.Empty, out connectionType);

                    // Create connection
                    IConnection connection = this.CreateConnection(connectionKind, connectionType);

                    if (connection != null)
                    {
                        connection.ConnectionSettings.Name = c.Attribute("Name")?.Value ?? string.Empty;
                        connection.ConnectionSettings.Host = c.Attribute("Host")?.Value ?? string.Empty;
                        connection.ConnectionSettings.Port = Convert.ToInt32(c.Attribute("Port")?.Value ?? "0");
                        connection.ConnectionSettings.UserName = c.Attribute("UserName")?.Value ?? string.Empty;
                        connection.ConnectionSettings.Password = c.Attribute("Password")?.Value ?? string.Empty;
                        connection.ConnectionSettings.Timeout = Convert.ToInt32(c.Attribute("Timeout")?.Value ?? "10000");
                    }

                    this.Connections.Add(connection);
                }
            }
            catch (Exception ex)
            {
                // Extended properties
                Dictionary<string, object> extProps = new Dictionary<string, object>();
                extProps.Add("File-Path", FileAndFolderConstants.ConnectionSettingsConfigFile);
                // Log-Exception
                this.unityContainer.Resolve<ILoggingService>(ServiceNames.LoggingService).Write(ex, LoggingCategories.ConnectionManagementModule, 1, 1000, System.Diagnostics.TraceEventType.Error, "ConnectionManager :: Failed to read config file", extProps);
                // TODO: Show-Exeption
            }
        }

        /// <summary>
        /// Create settings file
        /// </summary>
        private void CreateSettingsFile()
        {
            try
            {
                // Create new XML-File
                XDocument xdoc = new XDocument(new XDeclaration("1.0", "UTF-8", "yes"),
                    new XComment("Connection-Settings"),
                    new XElement("Connections"));

                xdoc.Save(FileAndFolderConstants.ConnectionSettingsConfigFile);
            }
            catch (Exception ex)
            {
                // Extended properties
                Dictionary<string, object> extProps = new Dictionary<string, object>();
                extProps.Add("File-Path", FileAndFolderConstants.ConnectionSettingsConfigFile);
                // Log-Exception
                this.unityContainer.Resolve<ILoggingService>(ServiceNames.LoggingService).Write(ex, LoggingCategories.ConnectionManagementModule, 1, 1000, System.Diagnostics.TraceEventType.Error, "ConnectionManager :: Failed to create config file", extProps);
                // TODO: Show-Exeption
            }
        }

        /// <summary>
        /// Add connection to config
        /// </summary>
        /// <param name="connection"></param>
        private bool AddConnectionToConfig(IConnection connection)
        {
            bool result = true;

            try
            {
                XDocument xmlDoc = XDocument.Load(FileAndFolderConstants.ConnectionSettingsConfigFile);

                xmlDoc.Element("Connections").Add(connection.ConnectionSettings.ToXml());

                xmlDoc.Save(FileAndFolderConstants.ConnectionSettingsConfigFile);
            }
            catch (Exception ex)
            {
                // Extended properties
                Dictionary<string, object> extProps = new Dictionary<string, object>();
                extProps.Add("Connection", connection);
                // Log-Exception
                this.unityContainer.Resolve<ILoggingService>(ServiceNames.LoggingService).Write(ex, LoggingCategories.ConnectionManagementModule, 1, 1000, System.Diagnostics.TraceEventType.Error, "ConnectionManager :: Failed to add a connection", extProps);
                // TODO: Show-Exeption

                result = false;
            }

            return result;
        }

        /// <summary>
        /// Delete connection from config
        /// </summary>
        /// <param name="connection"></param>
        private bool DeleteConnectionFromConfig(IConnection connection)
        {
            bool result = true;

            try
            {
                XDocument xmlDoc = XDocument.Load(FileAndFolderConstants.ConnectionSettingsConfigFile);

                var configEntry = (from c in xmlDoc.Element("Connections").Elements()
                                   where c.Attribute("Name").Value == connection.ConnectionSettings.Name &&
                                         c.Attribute("Host").Value == connection.ConnectionSettings.Host &&
                                         Convert.ToInt32(c.Attribute("Port").Value) == connection.ConnectionSettings.Port
                                   select c).FirstOrDefault();

                if (configEntry != null)
                {
                    configEntry.Remove();

                    xmlDoc.Save(FileAndFolderConstants.ConnectionSettingsConfigFile);
                }
            }
            catch (Exception ex)
            {
                // Extended properties
                Dictionary<string, object> extProps = new Dictionary<string, object>();
                extProps.Add("Connection", connection);
                // Log-Exception
                this.unityContainer.Resolve<ILoggingService>(ServiceNames.LoggingService).Write(ex, LoggingCategories.ConnectionManagementModule, 1, 1000, System.Diagnostics.TraceEventType.Error, "ConnectionManager :: Failed to delete a connection", extProps);
                // TODO: Show-Exeption

                result = false;
            }

            return result;
        }

        #endregion Methods

        #region Event-Handler

        #endregion Event-Handler

        #region Properties

        private IConnection activeConnection;

        /// <summary>
        /// The active connectionSettings
        /// </summary>
        public IConnection ActiveConnection
        {
            get { return activeConnection; }
            set { activeConnection = value; }
        }

        private ObservableCollection<IConnection> connections = new ObservableCollection<IConnection>();

        /// <summary>
        /// List with connections
        /// </summary>
        public ObservableCollection<IConnection> Connections
        {
            get { return connections; }
            set { connections = value; }
        }

        /// <summary>
        /// List with connections
        /// </summary>
        public ObservableCollection<IConnection> KodiConnections
        {
            get { return new ObservableCollection<IConnection>(this.Connections.Where(c => c.ConnectionSettings.ConnectionKind == ConnectionKindsEnum.KodiMediaPlayer)); }
        }

        /// <summary>
        /// Create connection
        /// </summary>
        /// <param name="connectionKind"></param>
        /// <param name="connectionType"></param>
        /// <returns></returns>
        public IConnection CreateConnection(ConnectionKindsEnum connectionKind, ConnectionTypesEnum connectionType)
        {
            return this.connectionFactory.GetConnection(connectionKind, connectionType);
        }

        /// <summary>
        /// Add connection
        /// </summary>
        /// <param name="connection"></param>
        /// <returns></returns>
        public bool AddConnection(IConnection connection)
        {
            bool result = true;
            string statusBarMessage = string.Empty;

            // Add connection
            this.Connections.Add(connection);
            result = this.AddConnectionToConfig(connection);

            if (result)
            {
                this.eventAggregator.GetEvent<ConnectionsUpdatedEvent>().Publish(new ConnectionsUpdatedEventArgs());
                statusBarMessage = this.unityContainer.Resolve<ILocalizerService>(ServiceNames.LocalizerService).GetLocalizedString("VersatileMediaManager.ConnectionManagement:Resources:ConnectionManagementConnectionAddedSuccessfullStatusBarMessage");
            }
            else
                statusBarMessage = this.unityContainer.Resolve<ILocalizerService>(ServiceNames.LocalizerService).GetLocalizedString("VersatileMediaManager.ConnectionManagement:Resources:ConnectionManagementConnectionAddedFailedStatusBarMessage");

            // Update status bar
            this.eventAggregator.GetEvent<UpdateStatusBarMessageEvent>().Publish(String.Format(statusBarMessage, connection?.ConnectionSettings?.Name));

            return result;
        }

        /// <summary>
        /// Delete connection
        /// </summary>
        /// <param name="connection"></param>
        /// <returns></returns>
        public bool DeleteConnection(IConnection connection)
        {
            bool result = true;
            string statusBarMessage = string.Empty;

            // Delete connection
            this.Connections.Remove(connection);
            result = this.DeleteConnectionFromConfig(connection);

            if (result)
            {
                this.eventAggregator.GetEvent<ConnectionsUpdatedEvent>().Publish(new ConnectionsUpdatedEventArgs());
                statusBarMessage = this.unityContainer.Resolve<ILocalizerService>(ServiceNames.LocalizerService).GetLocalizedString("VersatileMediaManager.ConnectionManagement:Resources:ConnectionManagementConnectionDeletedSuccessfullStatusBarMessage");
            }
            else
                statusBarMessage = this.unityContainer.Resolve<ILocalizerService>(ServiceNames.LocalizerService).GetLocalizedString("VersatileMediaManager.ConnectionManagement:Resources:ConnectionManagementConnectionDeletedFailedStatusBarMessage");

            // Update status bar
            this.eventAggregator.GetEvent<UpdateStatusBarMessageEvent>().Publish(String.Format(statusBarMessage, connection?.ConnectionSettings?.Name));

            return result;
        }

        #endregion Properties
    }
}