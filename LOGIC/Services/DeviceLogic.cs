using LOGIC.DTO_s;
using LOGIC.Entities;
using LOGIC.Interfaces;

namespace LOGIC.DeviceLogic
{
    public class DeviceLogic : IDeviceLogic
    {
        private readonly IDeviceDal _device;
        public DeviceLogic(IDeviceDal device)
        {
            _device = device;
        }
        public int AddDevice(DeviceDTO deviceDto)
        {
            int result = _device.AddDevice(deviceDto);

            return result;
        }
        
        public int UpdateDevice(DeviceDTO deviceDto)
        {
            int updateDeviceResult = _device.UpdateDevice(deviceDto);

            return updateDeviceResult;
        }

        public Boolean DeleteDevice(int deviceId)
        {
            var deleteDeviceResult = _device.DeleteDevice(deviceId);
            return deleteDeviceResult > 0;
        }

        public List<Device> GetDevices()
        {
            List<DeviceDTO> devicesDTO = _device.GetDevices();
            List<Device> devices = new();

            foreach (var device in devicesDTO)
            {
                devices.Add(new Device
                {
                    DeviceId = device.DeviceId,
                    ClientId = device.ClientId,
                    TicketId = device.TicketId,
                    DeviceName = device.DeviceName,
                    DeviceVersion = device.DeviceVersion,
                    Brand = device.Brand,
                    OsVersion = device.OsVersion,
                    SerialNumber = device.SerialNumber,
                });
            }
            return devices;
        }

        public Device GetDevice(int deviceId)
        {

            DeviceDTO specificDevice = _device.GetDevice(deviceId);
            Device device = new Device()
            {
                DeviceId = specificDevice.DeviceId,
                ClientId = specificDevice.ClientId,
                TicketId = specificDevice.TicketId,
                DeviceName = specificDevice.DeviceName,
                DeviceVersion = specificDevice.DeviceVersion,
                Brand = specificDevice.Brand,
                OsVersion = specificDevice.OsVersion,
                SerialNumber = specificDevice.SerialNumber,
            };
            return device;
        }
    }
}
