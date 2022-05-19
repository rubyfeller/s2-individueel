using LOGIC.DTO_s;
using LOGIC.Entities;

namespace LOGIC.Interfaces
{
    public interface IDeviceLogic
    {
        int AddDevice(DeviceDTO deviceDto);
        int UpdateDevice(DeviceDTO deviceDto);
        Boolean DeleteDevice(int deviceId);
        List<Device> GetDevices();
        Device GetDevice(int deviceId);
    }
}
