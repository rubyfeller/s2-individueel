using LOGIC.DTO_s;
using LOGIC.Entities;
using LOGIC.Interfaces;

namespace LOGIC.TicketLogic
{
    public class TicketLogic : ITicketLogic
    {
        private readonly ITicketDal _ticket;
        private readonly ICommentDal _comment;
        private readonly IEmployeeDal _employee;
        private readonly IClientDal _client;
        private readonly IDeviceDal _device;

        public TicketLogic(ITicketDal ticket, ICommentDal comment, IEmployeeDal employee, IClientDal client, IDeviceDal device)
        {
            _ticket = ticket;
            _comment = comment;
            _employee = employee;
            _client = client;
            _device = device;
        }

        public int AddTicket(TicketDTO ticketDto)
        {
            var result = _ticket.AddTicket(ticketDto);

            return result;
        }

        public int UpdateTicket(TicketDTO ticketDto)
        {
            var updateDeviceResult = _ticket.UpdateTicket(ticketDto);

            return updateDeviceResult;
        }

        public Boolean DeleteTicket(int ticketid)
        {
            var deleteDeviceResult = _ticket.DeleteTicket(ticketid);
            return deleteDeviceResult > 0;
        }

        public List<Ticket> GetTickets(int ticketLevel)
        {
            List<TicketDTO> ticketsDto = _ticket.GetTickets(ticketLevel);
            List<Ticket> tickets = new();

            foreach (var ticket in ticketsDto)
            {
                tickets.Add(new Ticket
                {
                    TicketId = ticket.TicketId,
                    TicketSubject = ticket.TicketSubject,
                    TicketContent = ticket.TicketContent,
                    TicketCategory = (Ticket.TicketCategories)ticket.TicketCategory,
                    TicketPriority = (Ticket.TicketPriorities)ticket.TicketPriority,
                    TicketStatus = (Ticket.TicketStatuses)ticket.TicketStatus,
                    TicketLevel = (Ticket.TicketLevels)ticket.TicketLevel,
                    CreatedDateTime = ticket.CreatedDateTime,
                    //Comments = commentLogic.GetComments(ticket.TicketId),
                });
            }

            return tickets;
        }

        public List<Comment> TransferCommentDTO(int ticketId)
        {
            List<CommentDTO> comments = _comment.GetComments(ticketId);
            List<Comment> transferedComments = new();

            foreach (var comment in comments)
            {
                transferedComments.Add(new Comment
                {
                    CommentId = comment.CommentId,
                    CommentContent = comment.CommentContent,
                });
            }
            return transferedComments;
        }

        public List<Employee> TransferEmployeesDTO()
        {
            List<EmployeeDTO> employees = _employee.GetEmployees();
            List<Employee> transferedEmployees = new();

            foreach (var employee in employees)
            {
                transferedEmployees.Add(new Employee
                {
                    EmployeeId = employee.EmployeeId,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    Password = employee.Password,
                    Email = employee.Email,
                    CompetenceLevel = employee.CompetenceLevel,
                    Role = employee.Role,
                });
            }
            return transferedEmployees;
        }

        public Employee TransferEmployeeDTO(int employeeId)
        {
            EmployeeDTO employee = _employee.GetEmployee(employeeId);
            Employee newEmployee = new()
            {
                EmployeeId = employee.EmployeeId,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Password = employee.Password,
                Email = employee.Email,
                CompetenceLevel = employee.CompetenceLevel,
                Role = employee.Role,
            };

            return newEmployee;
        }

        public Client TransferClientDTO(int clientId)
        {
            ClientDTO client = _client.GetClient(clientId);
            Client newClient = new()
            {
                ClientId = client.ClientId,
                FirstName = client.FirstName,
                LastName = client.LastName,
                Password = client.Password,
                Email = client.Email,
            };

            return newClient;
        }

        public Device TransferDeviceDTO(int deviceId)
        {
            DeviceDTO device = _device.GetDevice(deviceId);
            Device newDevice = new()
            {
                DeviceId = device.DeviceId,
                DeviceName = device.DeviceName,
                DeviceVersion = device.DeviceVersion,
                Brand = device.Brand,
                OsVersion = device.OsVersion,
                SerialNumber = device.SerialNumber,
            };

            return newDevice;
        }

        public Ticket GetTicket(int ticketid)
        {
            TicketDTO specificTicket = _ticket.GetTicket(ticketid);
            Ticket ticket = new Ticket()
            {
                TicketId = specificTicket.TicketId,
                DeviceId = specificTicket.DeviceId,
                TicketSubject = specificTicket.TicketSubject,
                TicketContent = specificTicket.TicketContent,
                TicketCategory = (Ticket.TicketCategories)specificTicket.TicketCategory,
                TicketPriority = (Ticket.TicketPriorities)specificTicket.TicketPriority,
                TicketStatus = (Ticket.TicketStatuses)specificTicket.TicketStatus,
                TicketLevel = (Ticket.TicketLevels)specificTicket.TicketLevel,
                ResponsibleEmployee = specificTicket.ResponsibleEmployee,
                ClientId = specificTicket.ClientId,
                CreatedDateTime = specificTicket.CreatedDateTime,
                Comments = TransferCommentDTO(specificTicket.TicketId),
                Device = TransferDeviceDTO(specificTicket.DeviceId),
                Employee = TransferEmployeeDTO(specificTicket.ResponsibleEmployee),
                Employees = TransferEmployeesDTO(),
                Client = TransferClientDTO(specificTicket.ClientId),

            };

            return ticket;
        }
    }
}
