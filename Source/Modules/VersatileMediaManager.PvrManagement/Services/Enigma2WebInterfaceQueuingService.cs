using Microsoft.Practices.Unity;
using Prism.Commands;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VersatileMediaManager.Communication.Enigma2;
using VersatileMediaManager.Communication.Interfaces;
using VersatileMediaManager.Infrastructure.Contracts.Constants;
using VersatileMediaManager.PvrManagement.Contracts.Interfaces;
using VersatileMediaManager.PvrManagement.Contracts.Model.Enigma2;

namespace VersatileMediaManager.PvrManagement.Services
{
    public class Enigma2WebInterfaceQueuingService : IEnigma2WebInterfaceQueuingService
    {
        #region Members and Constants

        private IConnectionManager connectionManager = null;
        private IUnityContainer unityContainer = null;

        #endregion Members and Constants

        #region CTOR

        /// <summary>
        /// CTOR
        /// </summary>
        /// <param name="connectionManager"></param>
        public Enigma2WebInterfaceQueuingService(IUnityContainer unityContainer, IPvrManagementCommands pvrManagementCommands)
        {
            this.unityContainer = unityContainer;

            this.connectionManager = this.unityContainer.Resolve<IConnectionManager>(GlobalConstants.ConnectionManager);

            // Commands
            this.AddTimerCommand = new DelegateCommand<Timer>(AddTimerEntry, CanAddTimerEntry);
            pvrManagementCommands.AddTimerCommand.RegisterCommand(this.AddTimerCommand);
        }

        #endregion CTOR

        #region Commands

        public ICommand AddTimerCommand { get; private set; }

        public void AddTimerEntry(Timer timer)
        {
            this.unityContainer.Resolve<IRegionManager>().RequestNavigate(RegionNames.DialogPopupRegion, ViewNames.AddTimerView);
        }

        public bool CanAddTimerEntry(Timer timer)
        {
            return true;
        }

        #endregion Commands

        #region Device-Info

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

        #endregion Device-Info

        #region Locations

        /// <summary>
        /// Get list of locations, e.g. /hdd/movie
        /// </summary>
        /// <returns></returns>
        public LocationList GetLocationList()
        {
            LocationList result = null;

            using (var da = new Enigma2WebInterfaceDataAdapter<LocationList>(this.connectionManager.ActiveConnection))
            {
                try
                {
                    result = da.Execute(Enigma2WebInterfacesMethods.GetLocationList);
                }
                catch (Exception ex)
                {
                    // TODO: Exception-Handling
                }
            }

            return result;
        }

        /// <summary>
        /// Get current location, e.g. /hdd/movie
        /// </summary>
        /// <returns></returns>
        public Location GetCurrentLocation()
        {
            throw new NotImplementedException();
        }

        #endregion Locations

        #region Service / Bouquets

        /// <summary>
        /// Get list with services
        /// </summary>
        /// <returns></returns>
        public ServiceList GetServiceList()
        {
            ServiceList result = null;

            using (var da = new Enigma2WebInterfaceDataAdapter<ServiceList>(this.connectionManager.ActiveConnection))
            {
                try
                {
                    result = da.Execute(Enigma2WebInterfacesMethods.GetServiceList);
                }
                catch (Exception ex)
                {
                    // TODO: Exception-Handling
                }
            }

            return result;
        }

        /// <summary>
        /// Get sub service list
        /// </summary>
        /// <param name="parentService">The parent service</param>
        /// <returns></returns>
        public ServiceList GetSubServiceList(string parentService)
        {
            ServiceList result = null;

            using (var da = new Enigma2WebInterfaceDataAdapter<ServiceList>(this.connectionManager.ActiveConnection))
            {
                try
                {
                    Dictionary<string, string> parameters = new Dictionary<string, string>();
                    parameters.Add("sRef", parentService);

                    result = da.Execute(Enigma2WebInterfacesMethods.GetServiceList, parameters);
                }
                catch (Exception ex)
                {
                    // TODO: Exception-Handling
                }
            }

            return result;
        }

        #endregion Service / Bouquets

        #region Timer

        /// <summary>
        /// Get list with timer entries
        /// </summary>
        /// <returns></returns>
        public TimerList GetTimerList()
        {
            TimerList result = null;

            using (var da = new Enigma2WebInterfaceDataAdapter<TimerList>(this.connectionManager.ActiveConnection))
            {
                try
                {
                    result = da.Execute(Enigma2WebInterfacesMethods.GetTimerList);
                }
                catch (Exception ex)
                {
                    // TODO: Exception-Handling
                }
            }

            return result;
        }

        /// <summary>
        /// Add new timer
        /// </summary>
        /// <param name="timer">The timer to add</param>
        /// <returns></returns>
        public bool AddTimer(Timer timer)
        {
            return true;
        }

        #endregion Timer
    }
}
