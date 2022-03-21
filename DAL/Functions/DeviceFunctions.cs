using DAL.DataContext;
using DAL.Interfaces;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using System.Data;

namespace DAL.Functions
{
    public class DeviceFunctions : IDevice
    {
        DBCollection dbConnection = new DBCollection();
        int deviceResult;
        //DatabaseContext context = new DatabaseContext(DatabaseContext.options.dbOptions);
        // Add a new device
        public async Task<Int32> AddDevice(int ClientId, int TicketId, string devicename, string deviceversion, string brand, string osVersion, string serialNumber)
        {
            Device newDevice = new Device
            {
                DeviceName = devicename,
                DeviceVersion = deviceversion,
                Brand = brand,
                OsVersion = osVersion,
                SerialNumber = serialNumber
            };
            var connectionString = dbConnection.GetConnectionString();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                using (SqlCommand command = new SqlCommand("INSERT INTO Devices (clientId, ticketId, deviceName, deviceVersion, brand, osVersion, serialNumber) VALUES (@ClientId, @TicketId, @DeviceName, @DeviceVersion, @Brand, @OsVersion, @SerialNumber)", connection))
                {
                    command.Parameters.AddWithValue("@ClientId", newDevice.ClientId ?? Convert.DBNull);
                    command.Parameters.AddWithValue("@TicketId", newDevice.TicketId ?? Convert.DBNull);
                    command.Parameters.AddWithValue("@DeviceName", newDevice.DeviceName);
                    command.Parameters.AddWithValue("@DeviceVersion", newDevice.DeviceVersion);
                    command.Parameters.AddWithValue("@Brand", newDevice.Brand);
                    command.Parameters.AddWithValue("@OsVersion", newDevice.OsVersion);
                    command.Parameters.AddWithValue("@SerialNumber", newDevice.SerialNumber);
                    connection.Open();
                    deviceResult = await command.ExecuteNonQueryAsync();
                }
            }
            return deviceResult;
        }

        // Get all users
        public async Task<List<Device>> GetDevices()
        {
            List<Device> users = new List<Device>();
            using (var context = new DatabaseContext(DatabaseContext.options.dbOptions))
            {
                users = await context.Devices.ToListAsync();
            }
            return users;
        }

        //// Edit device
        //public async Task<Device> EditDevice(int DeviceId, Device updatedDevice)
        //{
        //    Device device;
        //    device = (Device)context.Devices.FromSqlRaw("SELECT * FROM devices");
        //    using (context)
        //    {

        //        device = await (context.Devices.Where(s => s.DeviceId == 1).FirstOrDefaultAsync());

        //        if (device != null)
        //        {
        //            device.SerialNumber = updatedDevice.SerialNumber;
        //            device.DeviceName = updatedDevice.DeviceName;
        //            device.DeviceVersion = updatedDevice.DeviceVersion;
        //            device.Brand = updatedDevice.Brand;
        //            device.OsVersion = updatedDevice.OsVersion;
        //            device.SerialNumber = updatedDevice.SerialNumber;
        //        }


        //        context.Devices.Update(device);
        //        await context.SaveChangesAsync();
        //        return device;
        //    }
        //}
    }
}

//            // Get all devices
//            public async Task<List<Device>> GetDevices()
//            {
//                List<Device> devices = new List<Device>();
//                using (var context = new DatabaseContext(DatabaseContext.options.dbOptions))
//                {
//                    devices = await context.Devices.ToListAsync();
//                }
//                return devices;
//            }
//        }
//    }
//}