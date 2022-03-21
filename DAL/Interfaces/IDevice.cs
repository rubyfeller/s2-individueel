using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IDevice
    {
        Task<Int32> AddDevice(int clientId, int ticketId, string devicename, string deviceversion, string brand, string osVersion, string serialNumber);
        //Task<Device> EditDevice(int DeviceId, Device updatedDevice);
        Task<List<Device>> GetDevices();
    }
}
