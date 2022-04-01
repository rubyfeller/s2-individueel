using LOGIC.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.Interfaces
{
    public interface IDevice
    {
        Int32 AddDevice(int clientId, int ticketId, string devicename, string deviceversion, string brand, string osVersion, string serialNumber);
        Int32 UpdateDevice(int deviceId, int clientId, int ticketId, string devicename, string deviceversion, string brand, string osVersion, string serialNumber);
        Int32 DeleteDevice(int deviceId);
        List<Device> GetDevices();
        List<Device> GetDevice(int deviceId);
    }
}
