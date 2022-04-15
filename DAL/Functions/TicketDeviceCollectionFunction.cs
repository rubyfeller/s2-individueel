using LOGIC.Entities;
using LOGIC.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Functions
{
    public class TicketDeviceCollectionFunction : ITicketDeviceCollectionDal
    {
        private readonly DBCollection dbConnection = new DBCollection();


        // Get specific device
        public List<TicketDeviceCollection> GetTicketDevices(int ticketid)
        {
            TicketDeviceCollection ticketDeviceCollection = new TicketDeviceCollection();
            var connectionString = dbConnection.GetConnectionString();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.ConnectionString = connectionString;
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM TicketDeviceCollection INNER JOIN Devices ON Devices.ticketId = TicketDeviceCollection.ticketId WHERE ticketId = @TicketId", connection))
                {
                    command.Parameters.AddWithValue("@TicketId", ticketid);
                    List<TicketDeviceCollection> TicketDeviceList = new();
                    using (DbDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ticketDeviceCollection.Id = reader.GetInt32("id");
                            ticketDeviceCollection.DeviceId = reader.GetInt32("deviceId");
                            ticketDeviceCollection.TicketId = reader.GetInt32("ticketId");
                            TicketDeviceList.Add(new TicketDeviceCollection
                            {
                                Id = Convert.ToInt32(reader.GetInt32("id")),
                                DeviceId = Convert.ToInt32(reader.GetInt32("deviceId")),
                                TicketId = Convert.ToInt32(reader.GetInt32("ticketId")),
                                DeviceName = reader.GetString("deviceName"),
                                DeviceVersion = reader.GetString("deviceVersion"),
                                Brand = reader.GetString("brand"),
                                OsVersion = reader.GetString("osVersion"),
                                SerialNumber = reader.GetString("serialNumber"),
                            });
                        }
                    }
                    return TicketDeviceList;
                }
            }
        }
    }
}
