using LOGIC.DTO_s;

namespace LOGIC.Interfaces
{
    public interface IDeviceDal
    {
        int AddDevice(DeviceDTO deviceDto);
        int UpdateDevice(DeviceDTO deviceDto);
        int DeleteDevice(int deviceId);
        List<DeviceDTO> GetDevices();
        DeviceDTO GetDevice(int deviceId);
    }
}
