using LOGIC.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.Interfaces
{
    public interface IDeviceLogic
    {
        Boolean AddDevice(int clientId, int ticketId, string devicename, string deviceversion, string brand, string osVersion, string serialNumber);
        Boolean UpdateDevice(int deviceId, int clientId, int ticketId, string devicename, string deviceversion, string brand, string osVersion, string serialNumber);
        Boolean DeleteDevice(int deviceId);
        List<Device> GetDevices();
        List<Device> GetDevice(int deviceId);
    }
}
