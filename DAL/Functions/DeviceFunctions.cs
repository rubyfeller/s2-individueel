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
using System.Data.Common;

namespace DAL.Functions
{
    public class DeviceFunctions : IDevice
    {
        DBCollection dbConnection = new DBCollection();
        int deviceResult;
        int updateDeviceResult;
        int deleteDeviceResult;

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

        // Get all devices
        public async Task<List<Device>> GetDevices()
        {
            Device device = new Device();
            var connectionString = dbConnection.GetConnectionString();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.ConnectionString = connectionString;
                await connection.OpenAsync();
                DbCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM Devices";
                List<Device> deviceList = new();
                using (DbDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (reader.Read())
                    {
                        device.ClientId = 0;
                        device.TicketId = 0;
                        //device.ClientId = reader.GetInt32("clientId");
                        //device.TicketId = reader.GetInt32("ticketId");
                        device.DeviceId = Convert.ToInt32(reader.GetInt32("deviceId"));
                        device.DeviceName = reader.GetString("deviceName");
                        device.DeviceVersion = reader.GetString("deviceVersion");
                        device.Brand = reader.GetString("brand");
                        device.OsVersion = reader.GetString("osVersion");
                        device.SerialNumber = reader.GetString("serialNumber");
                        deviceList.Add(new Device
                        {
                            ClientId = 0,
                            TicketId = 0,
                            //device.ClientId = reader.GetInt32("clientId");
                            //device.TicketId = reader.GetInt32("ticketId");
                            DeviceId = Convert.ToInt32(reader.GetInt32("deviceId")),
                            DeviceName = reader.GetString("deviceName"),
                            DeviceVersion = reader.GetString("deviceVersion"),
                            Brand = reader.GetString("brand"),
                            OsVersion = reader.GetString("osVersion"),
                            SerialNumber = reader.GetString("serialNumber"),
                        });
                    }
                }
                return deviceList;
            }
        }
        // Update device
        public async Task<Int32> UpdateDevice(int deviceid, int ClientId, int TicketId, string devicename, string deviceversion, string brand, string osVersion, string serialNumber)
        {
            Device newDevice = new Device
            {
                DeviceId = deviceid,
                DeviceName = devicename,
                DeviceVersion = deviceversion,
                Brand = brand,
                OsVersion = osVersion,
                SerialNumber = serialNumber
            };
            var connectionString = dbConnection.GetConnectionString();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                using (SqlCommand command = new SqlCommand("UPDATE Devices SET deviceName = @DeviceName WHERE deviceId = @DeviceId", connection))
                {
                    command.Parameters.AddWithValue("@DeviceId", newDevice.DeviceId);
                    command.Parameters.AddWithValue("@ClientId", newDevice.ClientId ?? Convert.DBNull);
                    command.Parameters.AddWithValue("@TicketId", newDevice.TicketId ?? Convert.DBNull);
                    command.Parameters.AddWithValue("@DeviceName", newDevice.DeviceName);
                    command.Parameters.AddWithValue("@DeviceVersion", newDevice.DeviceVersion);
                    command.Parameters.AddWithValue("@Brand", newDevice.Brand);
                    command.Parameters.AddWithValue("@OsVersion", newDevice.OsVersion);
                    command.Parameters.AddWithValue("@SerialNumber", newDevice.SerialNumber);
                    connection.Open();
                    updateDeviceResult = await command.ExecuteNonQueryAsync();
                }
            }
            return updateDeviceResult;
        }
        public async Task<Int32> DeleteDevice(int deviceid)
        {
            var connectionString = dbConnection.GetConnectionString();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                using (SqlCommand command = new SqlCommand("DELETE FROM Devices WHERE deviceId = @DeviceId", connection))
                {
                    command.Parameters.AddWithValue("@DeviceId", deviceid);
                    connection.Open();
                    deleteDeviceResult = await command.ExecuteNonQueryAsync();
                }
            }
            return deleteDeviceResult;
        }
    }
}