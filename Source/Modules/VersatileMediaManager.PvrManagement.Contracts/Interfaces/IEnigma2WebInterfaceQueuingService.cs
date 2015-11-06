using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VersatileMediaManager.PvrManagement.Contracts.Model.Enigma2;

namespace VersatileMediaManager.PvrManagement.Contracts.Interfaces
{
    public interface IEnigma2WebInterfaceQueuingService
    {
        #region Device-Info

        /// <summary>
        /// Get device info
        /// </summary>
        /// <returns></returns>
        DeviceInfo GetDeviceInfo();

        #endregion Device-Info

        #region Locations

        /// <summary>
        /// Get list of locations, e.g. /hdd/movie
        /// </summary>
        /// <returns></returns>
        LocationList GetLocationList();

        /// <summary>
        /// Get current location, e.g. /hdd/movie
        /// </summary>
        /// <returns></returns>
        Location GetCurrentLocation();

        #endregion Locations

        #region Service / Bouquets

        /// <summary>
        /// Get list with services
        /// </summary>
        /// <returns></returns>
        ServiceList GetServiceList();

        /// <summary>
        /// Get sub service list
        /// </summary>
        /// <param name="parentService">The parent service</param>
        /// <returns></returns>
        ServiceList GetSubServiceList(string parentService);

        #endregion Service / Bouquets

        #region Timer

        /// <summary>
        /// Get list with timer entries
        /// </summary>
        /// <returns></returns>
        TimerList GetTimerList();

        /// <summary>
        /// Add new timer
        /// </summary>
        /// <param name="timer">The timer to add</param>
        /// <returns></returns>
        bool AddTimer(Timer timer);

        #endregion Timer
    }
}
