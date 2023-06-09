﻿using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Data.Common;
using LOGIC.Interfaces;
using LOGIC.Entities;
using LOGIC.DTO_s;

namespace DAL.Functions
{
    public class DeviceData : IDeviceDal
    {
        private readonly DBCollection dbConnection = new DBCollection();

        public int AddDevice(DeviceDTO device)
        {
            int deviceResult;
            var connectionString = dbConnection.GetConnectionString();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                using (SqlCommand command = new SqlCommand("INSERT INTO Devices (clientId, ticketId, deviceName, deviceVersion, brand, osVersion, serialNumber) VALUES (@ClientId, @TicketId, @DeviceName, @DeviceVersion, @Brand, @OsVersion, @SerialNumber)", connection))
                {
                    command.Parameters.AddWithValue("@ClientId", device.ClientId ?? Convert.DBNull);
                    command.Parameters.AddWithValue("@TicketId", device.TicketId ?? Convert.DBNull);
                    command.Parameters.AddWithValue("@DeviceName", device.DeviceName);
                    command.Parameters.AddWithValue("@DeviceVersion", device.DeviceVersion);
                    command.Parameters.AddWithValue("@Brand", device.Brand);
                    command.Parameters.AddWithValue("@OsVersion", device.OsVersion);
                    command.Parameters.AddWithValue("@SerialNumber", device.SerialNumber);
                    connection.Open();
                    deviceResult = command.ExecuteNonQuery();
                }
            }
            return deviceResult;
        }

        public List<DeviceDTO> GetDevices()
        {
            Device device = new Device();
            var connectionString = dbConnection.GetConnectionString();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.ConnectionString = connectionString;
                connection.Open();
                DbCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM Devices";
                List<DeviceDTO> deviceList = new();
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        device.ClientId = (int?)(reader["clientId"] != DBNull.Value ? reader["clientId"] : 0);
                        device.TicketId = (int?)(reader["ticketId"] != DBNull.Value ? reader["ticketId"] : 0);
                        device.DeviceId = reader.GetInt32("deviceId");
                        device.DeviceName = reader.GetString("deviceName");
                        device.DeviceVersion = reader.GetString("deviceVersion");
                        device.Brand = reader.GetString("brand");
                        device.OsVersion = reader.GetString("osVersion");
                        device.SerialNumber = reader.GetString("serialNumber");
                        deviceList.Add(new DeviceDTO
                        {

                            ClientId = (int?)(reader["clientId"] != DBNull.Value ? reader["clientId"] : 0),
                            TicketId = (int?)(reader["ticketId"] != DBNull.Value ? reader["ticketId"] : 0),
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

        // Get specific device
        public DeviceDTO GetDevice(int deviceid)
        {
            DeviceDTO device = new DeviceDTO();
            var connectionString = dbConnection.GetConnectionString();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.ConnectionString = connectionString;
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM Devices WHERE deviceId = @DeviceId", connection))
                {
                    command.Parameters.AddWithValue("@DeviceId", deviceid);
                    List<Device> specificDeviceList = new();

                    using (DbDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            device.ClientId = (int?)(reader["clientId"] != DBNull.Value ? reader["clientId"] : 0);
                            device.TicketId = (int?)(reader["ticketId"] != DBNull.Value ? reader["ticketId"] : 0);
                            device.DeviceId = reader.GetInt32("deviceId");
                            device.DeviceName = reader.GetString("deviceName");
                            device.DeviceVersion = reader.GetString("deviceVersion");
                            device.Brand = reader.GetString("brand");
                            device.OsVersion = reader.GetString("osVersion");
                            device.SerialNumber = reader.GetString("serialNumber");

                            DeviceDTO newDevice = new DeviceDTO
                            {
                                ClientId = (int?)(reader["clientId"] != DBNull.Value ? reader["clientId"] : 0),
                                TicketId = (int?)(reader["ticketId"] != DBNull.Value ? reader["ticketId"] : 0),
                                DeviceId = Convert.ToInt32(reader.GetInt32("deviceId")),
                                DeviceName = reader.GetString("deviceName"),
                                DeviceVersion = reader.GetString("deviceVersion"),
                                Brand = reader.GetString("brand"),
                                OsVersion = reader.GetString("osVersion"),
                                SerialNumber = reader.GetString("serialNumber"),
                            };
                        }
                        return device;
                    }
                }
            }
        }

        public int UpdateDevice(DeviceDTO device)
        {
            int updateDeviceResult;
            Device newDevice = new Device
            {
                DeviceId = device.DeviceId,
                DeviceName = device.DeviceName,
                DeviceVersion = device.DeviceVersion,
                Brand = device.Brand,
                OsVersion = device.OsVersion,
                SerialNumber = device.SerialNumber
            };
            var connectionString = dbConnection.GetConnectionString();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                using (SqlCommand command = new SqlCommand("UPDATE Devices SET deviceName = @DeviceName, deviceVersion = @DeviceVersion, brand = @Brand, osVersion = @OsVersion, serialNumber = @SerialNumber WHERE deviceId = @DeviceId", connection))
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
                    updateDeviceResult = command.ExecuteNonQuery();
                }
            }
            return updateDeviceResult;
        }

        public int DeleteDevice(int deviceid)
        {
            int deleteDeviceResult;

            var connectionString = dbConnection.GetConnectionString();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                using (SqlCommand command = new SqlCommand("DELETE FROM Devices WHERE deviceId = @DeviceId", connection))
                {
                    command.Parameters.AddWithValue("@DeviceId", deviceid);
                    connection.Open();
                    deleteDeviceResult = command.ExecuteNonQuery();
                }
            }
            return deleteDeviceResult;
        }
    }
}
