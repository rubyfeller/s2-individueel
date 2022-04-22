using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Data.Common;
using LOGIC.Interfaces;
using LOGIC.Entities;
using LOGIC.DTO_s;

namespace DAL.Functions
{
    public class DeviceFunctions : IDeviceDal
    {
        private readonly DBCollection dbConnection = new DBCollection();
        Object deviceResult;
        Object updateDeviceResult;
        int deleteDeviceResult;

        // Add a new device
        public Object AddDevice(DeviceDTO device)
        {
            Device newDevice = new Device
            {
                DeviceName = device.DeviceName,
                DeviceVersion = device.DeviceVersion,
                Brand = device.Brand,
                OsVersion = device.OsVersion,
                SerialNumber = device.SerialNumber
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
                    deviceResult = command.ExecuteNonQuery();
                }
            }
            return deviceResult;
        }

        // Get all devices
        public List<Device> GetDevices()
        {
            Device device = new Device();
            var connectionString = dbConnection.GetConnectionString();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.ConnectionString = connectionString;
                connection.Open();
                DbCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM Devices";
                List<Device> deviceList = new();
                using (DbDataReader reader = command.ExecuteReader())
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

        // Get specific device
        public Device GetDevice(int deviceid)
        {
            Device device = new Device();
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
                            device.ClientId = 0;
                            device.TicketId = 0;
                            //device.ClientId = reader.GetInt32("clientId");
                            //device.TicketId = reader.GetInt32("ticketId");
                            device.DeviceId = reader.GetInt32("deviceId");
                            device.DeviceName = reader.GetString("deviceName");
                            device.DeviceVersion = reader.GetString("deviceVersion");
                            device.Brand = reader.GetString("brand");
                            device.OsVersion = reader.GetString("osVersion");
                            device.SerialNumber = reader.GetString("serialNumber");

                            Device newDevice = new Device
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
                            };
                        }
                        return device;

                    }
                }
            }
        }

        // Update device
        public Object UpdateDevice(DeviceDTO device)
        {
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

        // Delete ticket
        public Int32 DeleteDevice(int deviceid)
        {
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
