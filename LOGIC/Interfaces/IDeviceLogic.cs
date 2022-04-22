using LOGIC.DTO_s;
using LOGIC.Entities;

namespace LOGIC.Interfaces
{
    public interface IDeviceLogic
    {
        Object AddDevice(DeviceDTO deviceDto);
        Object UpdateDevice(DeviceDTO deviceDto);
        Boolean DeleteDevice(int deviceId);
        List<Device> GetDevices();
        Device GetDevice(int deviceId);
    }
}
