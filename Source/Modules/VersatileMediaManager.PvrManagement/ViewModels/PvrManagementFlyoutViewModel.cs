using VersatileMediaManager.Communication.Interfaces;
using VersatileMediaManager.Infrastructure.Base;
using VersatileMediaManager.Infrastructure.Contracts.Constants;
using Microsoft.Practices.Unity;
using VersatileMediaManager.Communication.Enigma2;
using VersatileMediaManager.PvrManagement.Contracts.Model.Enigma2;
using System.Xml.Serialization;
using System.IO;
using VersatileMediaManager.PvrManagement.Contracts.Interfaces;
using Prism.Commands;
using System.Linq;
using System;

namespace VersatileMediaManager.PvrManagement.ViewModels
{
    public class PvrManagementFlyoutViewModel : VersatileMediaManagerViewModelBase
    {
        #region Members and Constants

        private IEnigma2WebInterfaceQueuingService webInterfaceQueuingService = null;

        #endregion Members and Constants

        public PvrManagementFlyoutViewModel()
        {
            this.webInterfaceQueuingService = this.UnityContainer.Resolve<IEnigma2WebInterfaceQueuingService>(ServiceNames.Enigma2WebInterfaceQueuingService);
        }

        /// <summary>
        /// Load movie data
        /// </summary>
        private void LoadData()
        {
            this.DeviceInfo = this.webInterfaceQueuingService.GetDeviceInfo();
            this.TimerList = this.webInterfaceQueuingService.GetTimerList();
        }

        #region Properties

        private bool isOpen;

        /// <summary>
        /// IsOpen flag
        /// </summary>
        public bool IsOpen
        {
            get { return isOpen; }
            set
            {
                if (this.SetProperty<bool>(ref this.isOpen, value))
                {
                    if (this.IsOpen)
                    {
                        this.LoadData();
                        OnPropertyChanged(() => this.ActiveConnection);
                    }
                }
            }
        }

        /// <summary>
        /// Active connection
        /// </summary>
        public IConnection ActiveConnection
        {
            get
            {
                return this.UnityContainer.Resolve<IConnectionManager>(GlobalConstants.ConnectionManager)?.ActiveConnection;
            }
        }

        private DeviceInfo deviceInfo;

        /// <summary>
        /// Device info
        /// </summary>
        public DeviceInfo DeviceInfo
        {
            get { return deviceInfo; }
            set { SetProperty<DeviceInfo>(ref this.deviceInfo, value); }
        }

        private TimerList timerList;

        /// <summary>
        /// List with timer entries
        /// </summary>
        public TimerList TimerList
        {
            get { return timerList; }
            set { SetProperty<TimerList>(ref this.timerList, value); }
        }

        #endregion Properties
    }
}
