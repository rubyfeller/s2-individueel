using LOGIC.Entities;

namespace LOGIC.Interfaces
{
    public interface IDevice
    {
        int AddDevice(int clientId, int ticketId, string devicename, string deviceversion, string brand, string osVersion, string serialNumber);
        int UpdateDevice(int deviceId, int clientId, int ticketId, string devicename, string deviceversion, string brand, string osVersion, string serialNumber);
        int DeleteDevice(int deviceId);
        List<Device> GetDevices();
        List<Device> GetDevice(int deviceId);
    }
}
