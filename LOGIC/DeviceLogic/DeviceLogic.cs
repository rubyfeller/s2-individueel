using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.DeviceLogic
{
    public class DeviceLogic
    {
        private IDevice _device = new DAL.Functions.DeviceFunctions();

        public async Task<Boolean> CreateNewDevice(int clientId, int ticketId, string devicename, string deviceversion, string brand, string osVersion, string serialNumber)
        {
            var result = await _device.AddDevice(clientId, ticketId, devicename, deviceversion, brand, osVersion, serialNumber);
            return result > 0;
        }
        public async Task<List<Device>> GetDevices()
        {
            List<Device> devices = await _device.GetDevices();
            return devices;
        }
    }
}