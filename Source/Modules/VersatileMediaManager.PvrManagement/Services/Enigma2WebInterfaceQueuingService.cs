using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VersatileMediaManager.Communication.Enigma2;
using VersatileMediaManager.Communication.Interfaces;
using VersatileMediaManager.Infrastructure.Contracts.Constants;
using VersatileMediaManager.PvrManagement.Contracts.Interfaces;
using VersatileMediaManager.PvrManagement.Contracts.Model.Enigma2;

namespace VersatileMediaManager.PvrManagement.Services
{
    public class Enigma2WebInterfaceQueuingService : IEnigma2WebInterfaceQueuingService
    {
        private IConnectionManager connectionManager = null;

        #region CTOR

        /// <summary>
        /// CTOR
        /// </summary>
        /// <param name="connectionManager"></param>
        public Enigma2WebInterfaceQueuingService(IUnityContainer unityContainer)
        {
            this.connectionManager = unityContainer.Resolve<IConnectionManager>(GlobalConstants.ConnectionManager);
        }

        #endregion CTOR

        /// <summary>
        /// Get device info
        /// </summary>
        /// <returns></returns>
        public DeviceInfo GetDeviceInfo()
        {
            DeviceInfo result = null;

            using (var da = new Enigma2WebInterfaceDataAdapter<DeviceInfo>(this.connectionManager.ActiveConnection))
            {
                try
                {
                    result = da.Execute(Enigma2WebInterfacesMethods.GetDeviceInfo);
                }
                catch (Exception ex)
                {
                    // TODO
                }
            }

            return result;
        }
    }
}
