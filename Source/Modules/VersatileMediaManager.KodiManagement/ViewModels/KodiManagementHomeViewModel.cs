using Microsoft.Practices.Unity;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using VersatileMediaManager.Communication.Interfaces;
using VersatileMediaManager.ConnectionManagement.Contracts.Events;
using VersatileMediaManager.Infrastructure.Base;
using VersatileMediaManager.Infrastructure.Contracts.Constants;

namespace VersatileMediaManager.KodiManagement.ViewModels
{
    public class KodiManagementHomeViewModel : VersatileMediaManagerViewModelBase
    {
        #region Members and Constants

        private IConnectionManager connectionManager = null;

        #endregion Members and Constants

        #region CTOR

        /// <summary>
        /// CTOR
        /// </summary>
        public KodiManagementHomeViewModel()
        {
            // Get connectionSettings manager
            this.connectionManager = this.UnityContainer.Resolve<IConnectionManager>(GlobalConstants.ConnectionManager);

            // Register to events
            this.EventAggregator.GetEvent<ConnectionsUpdatedEvent>().Subscribe(this.ConnectionsUpdatedEventHandler);
        }

        #endregion CTOR

        #region Event-Handler

        /// <summary>
        /// Connection added event handler
        /// </summary>
        /// <param name="args"></param>
        private void ConnectionsUpdatedEventHandler(ConnectionsUpdatedEventArgs args)
        {
            this.OnPropertyChanged(() => this.Connections);
        }

        #endregion Event-Handler

        #region Properties

        /// <summary>
        /// List with connections
        /// </summary>
        public IList<IConnection> Connections
        {
            get
            {
                return this.connectionManager.Connections.Where(c => c.ConnectionSettings.ConnectionKind == ConnectionKindsEnum.KodiMediaPlayer).ToList();
            }
        }

        #endregion Properties
    }
}