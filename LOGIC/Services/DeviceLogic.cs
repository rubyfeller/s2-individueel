using LOGIC.DTO_s;
using LOGIC.Entities;
using LOGIC.Interfaces;

namespace LOGIC.DeviceLogic
{
    public class DeviceLogic : IDeviceLogic
    {
        private IDeviceDal _device;
        public DeviceLogic(IDeviceDal device)
        {
            _device = device;
        }
        public Object AddDevice(DeviceDTO deviceDto)
        {
            Object result = _device.AddDevice(deviceDto);

            return result;
        }

        public Object UpdateDevice(DeviceDTO deviceDto)
        {
            Object updateDeviceResult = _device.UpdateDevice(deviceDto);

            return updateDeviceResult;
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
