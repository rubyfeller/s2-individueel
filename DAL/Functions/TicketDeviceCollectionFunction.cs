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
        DBCollection dbConnection = new DBCollection();


        // Get specific device
        public List<TicketDeviceCollection> GetTicketDevice(int ticketid)
        {
            TicketDeviceCollection ticketDeviceList = new TicketDeviceCollection();
            var connectionString = dbConnection.GetConnectionString();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.ConnectionString = connectionString;
                connection.Open();
                DbCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM TicketDeviceCollection WHERE ticketId = " + ticketid;
                List<TicketDeviceCollection> TicketDevice = new();
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //TicketDevice.Id = reader.GetInt32("id");
                        //TicketDevice.DeviceId = reader.GetInt32("deviceId");
                        //TicketDevice.TicketId = reader.GetInt32("ticketId");
                        //ticketDeviceList.Add(new TicketDeviceCollection(TicketDevice.Id, TicketDevice.DeviceId, TicketDevice.TicketId));
                    }
                }
                return TicketDevice;
            }
        }
    }
}
