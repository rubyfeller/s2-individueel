using LOGIC.DTO_s;
using LOGIC.Entities;

namespace LOGIC.Interfaces
{
    public interface IDeviceDal
    {
        Object AddDevice(DeviceDTO deviceDto);
        Object UpdateDevice(DeviceDTO deviceDto);
        int DeleteDevice(int deviceId);
        List<Device> GetDevices();
        List<Device> GetDevice(int deviceId);
    }
}
