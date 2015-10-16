using VersatileMediaManager.Communication.Interfaces;
using VersatileMediaManager.Infrastructure.Base;
using VersatileMediaManager.Infrastructure.Contracts.Constants;
using Microsoft.Practices.Unity;
using VersatileMediaManager.Communication.Enigma2;
using VersatileMediaManager.PvrManagement.Contracts.Model.Enigma2;
using System.Xml.Serialization;
using System.IO;
using VersatileMediaManager.PvrManagement.Contracts.Interfaces;

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

            //this.connectionManager = this.UnityContainer.Resolve<IConnectionManager>(GlobalConstants.ConnectionManager);

            //Enigma2WebInterfaceDataAdapter<DeviceInfo> da = new Enigma2WebInterfaceDataAdapter<DeviceInfo>(this.connectionManager.ActiveConnection);

            //DeviceInfo test = da.Execute(Enigma2WebInterfacesMethods.GetTimerList);

            //System.Diagnostics.Debug.WriteLine(test);

        }

        /// <summary>
        /// Load movie data
        /// </summary>
        private void LoadData()
        {
            this.DeviceInfo = this.webInterfaceQueuingService.GetDeviceInfo();
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
                    }
                }
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


        #endregion Properties
    }
}
