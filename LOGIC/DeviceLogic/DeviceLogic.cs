using LOGIC.Entities;
using LOGIC.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.DeviceLogic
{
    public class DeviceLogic : IDeviceLogic
    {
        private IDevice _device;
        public DeviceLogic(IDevice device)
        {
            _device = device;
        }
        public Boolean AddDevice(int clientId, int ticketId, string devicename, string deviceversion, string brand, string osVersion, string serialNumber)
        {
            var result = _device.AddDevice(clientId, ticketId, devicename, deviceversion, brand, osVersion, serialNumber);
            return result > 0;
        }

        public Boolean UpdateDevice(int deviceId, int clientId, int ticketId, string devicename, string deviceversion, string brand, string osVersion, string serialNumber)
        {
            var updateDeviceResult = _device.UpdateDevice(deviceId, clientId, ticketId, devicename, deviceversion, brand, osVersion, serialNumber);
            return updateDeviceResult > 0;
        }

        public Boolean DeleteDevice(int deviceId)
        {
            var deleteDeviceResult = _device.DeleteDevice(deviceId);
            return deleteDeviceResult > 0;
        }

        public List<Device> GetDevices()
        {
            List<Device> devices = _device.GetDevices();
            return devices;
        }

        public List<Device> GetDevice(int deviceId)
        {
            List<Device> specificDeviceList = _device.GetDevice(deviceId);
            return specificDeviceList;
        }
    }
}
