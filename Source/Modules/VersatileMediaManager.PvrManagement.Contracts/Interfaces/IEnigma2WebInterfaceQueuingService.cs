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
        DeviceInfo GetDeviceInfo();
    }
}
