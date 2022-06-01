using Autofac.Extras.Moq;
using LOGIC.DTO_s;
using LOGIC.Entities;
using LOGIC.Interfaces;
using LOGIC.TicketLogic;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace UnitTests
{
    public class TicketTest
    {
        private readonly Mock<ITicketDal> _ticketDal = new Mock<ITicketDal>();
        private readonly Mock<IEmployeeDal> _employeeDal = new Mock<IEmployeeDal>();
        private readonly Mock<ICommentDal> _commentDal = new Mock<ICommentDal>();
        private readonly Mock<IClientDal> _clientDal = new Mock<IClientDal>();
        private readonly Mock<IDeviceDal> _deviceDal = new Mock<IDeviceDal>();

        private readonly TicketLogic _TicketLogic;

        public TicketTest()
        {
            _TicketLogic = new TicketLogic(_ticketDal.Object, _commentDal.Object, _employeeDal.Object, _clientDal.Object, _deviceDal.Object);
        }

        private List<TicketDTO> GetSampleTickets()
        {
            List<TicketDTO> tickets = new List<TicketDTO>
            {
                new TicketDTO
                {
                    TicketId = 1,
                    TicketSubject = "Test",
                    TicketContent = "Test ticket",
                    TicketCategory = (TicketDTO.TicketCategories)1,
                    TicketPriority = (TicketDTO.TicketPriorities)2,
                    TicketStatus = (TicketDTO.TicketStatuses)1,
                    TicketLevel = (TicketDTO.TicketLevels)1,
                    CreatedDateTime = DateTime.Now,
                },

                new TicketDTO
                {
                    TicketId = 2,
                    TicketSubject = "Test 2",
                    TicketContent = "Test ticket 2",
                    TicketCategory = (TicketDTO.TicketCategories)1,
                    TicketPriority = (TicketDTO.TicketPriorities)2,
                    TicketStatus = (TicketDTO.TicketStatuses)1,
                    TicketLevel = (TicketDTO.TicketLevels)1,
                    CreatedDateTime = DateTime.Now,
                }
            };
            return tickets;
        }

        private TicketDTO GetSampleTicket()
        {
            TicketDTO ticket = new TicketDTO
            {
                TicketId = 1064,
                DeviceId = 1025,
                TicketSubject = "Test",
                TicketContent = "Test ticket",
                TicketCategory = (TicketDTO.TicketCategories)1,
                TicketPriority = (TicketDTO.TicketPriorities)2,
                TicketStatus = (TicketDTO.TicketStatuses)1,
                TicketLevel = (TicketDTO.TicketLevels)1,
                ResponsibleEmployee = 1,
                ClientId = 2,
                CreatedDateTime = DateTime.Now,
            };

            return ticket;
        }

        private List<CommentDTO> GetSampleComments()
        {
            List<CommentDTO> comments = new List<CommentDTO>
            {
                new CommentDTO
                {
                    CommentId = 48,
                    CommentContent = "Test comment",
                    CreatedDateTime = DateTime.Now,
                    TicketId = 1064,
                }
            };
            return comments;
        }

        private DeviceDTO GetSampleDevice()
        {
            DeviceDTO device = new DeviceDTO
            {
                DeviceId = 1025,
                ClientId = null,
                TicketId = null,
                DeviceName = "Samsung Galaxy S9",
                DeviceVersion = "S9",
                Brand = "Samsung",
                OsVersion = "9",
                SerialNumber = "123456",
            };

            return device;
        }

        private EmployeeDTO GetSampleEmployee()
        {
            EmployeeDTO employee = new EmployeeDTO
            {
                EmployeeId = 1025,
                FirstName = "Ruby",
                LastName = "Feller",
                Password = "123",
                Email = "ruby.feller@student.fontys.nl",
                CompetenceLevel = 3,
                Role = 3,
            };

            return employee;
        }

        private ClientDTO GetSampleClient()
        {
            ClientDTO client = new ClientDTO
            {
                ClientId = 1025,
                FirstName = "Ruby",
                LastName = "Feller",
                Password = "123",
                Email = "ruby.feller@student.fontys.nl",
            };

            return client;
        }

        private List<EmployeeDTO> GetSampleEmployees()
        {
            List<EmployeeDTO> employees = new List<EmployeeDTO>();
            {
                new EmployeeDTO
                {
                    EmployeeId = 1025,
                    FirstName = "Ruby",
                    LastName = "Feller",
                    Password = "123",
                    Email = "ruby.feller@student.fontys.nl",
                    CompetenceLevel = 3,
                    Role = 3,
                };

                return employees;
            }
        }

        [Fact]
        public void TestIsTicketDTOTransferedToLogicObject()
        {
            // Arrange
            //mock.Mock<ITicketDal>().Setup(x => x.GetTickets(0)).Returns(GetSampleTickets());
            _ticketDal.Setup(x => x.GetTickets(0)).Returns(GetSampleTickets());

            //var logicInstance = mock.Create<TicketLogic>();

            var expectedResult = GetSampleTickets();

            // Act
            var actualResult = _TicketLogic.GetTickets(0);

            // Assert
            Assert.True(actualResult != null);
            Assert.IsType<Ticket>(actualResult[0]);
            for (int i = 0; i < expectedResult.Count; i++)
            {
                Assert.Equal(expectedResult[i].TicketId, actualResult[i].TicketId);
                Assert.Equal(expectedResult[i].TicketContent, actualResult[i].TicketContent);
                Assert.Equal((int)expectedResult[i].TicketCategory, (int)actualResult[i].TicketCategory);
                Assert.Equal((int)expectedResult[i].TicketPriority, (int)actualResult[i].TicketPriority);
                Assert.Equal((int)expectedResult[i].TicketStatus, (int)actualResult[i].TicketStatus);
                Assert.Equal((int)expectedResult[i].TicketLevel, (int)actualResult[i].TicketLevel);
                Assert.Equal(expectedResult[i].ResponsibleEmployee, actualResult[i].ResponsibleEmployee);
                Assert.Equal(expectedResult[i].ClientId, actualResult[i].ClientId);
            }
            Assert.Equal(2, expectedResult.Count);
        }

        [Fact]
        public void TestAddTicket()
        {
            // Arrange
            var ticket = GetSampleTicket();
            _ticketDal.Setup(x => x.AddTicket(ticket));

            // Act
            _TicketLogic.AddTicket(ticket);

            // Assert
            _ticketDal.Verify(x => x.AddTicket(ticket), Times.Once);
        }

        [Fact]
        public void TestUpdateTicket()
        {
            // Arrange
            using var mock = AutoMock.GetLoose();
            var ticket = new TicketDTO
            {
                TicketId = 1,
                TicketSubject = "Test update",
                TicketContent = "Test ticket",
                TicketCategory = (TicketDTO.TicketCategories)1,
                TicketPriority = (TicketDTO.TicketPriorities)2,
                TicketStatus = (TicketDTO.TicketStatuses)1,
                TicketLevel = (TicketDTO.TicketLevels)1,
                CreatedDateTime = DateTime.Now,
            };
            _ticketDal.Setup(x => x.UpdateTicket(ticket));

            // Act
            _TicketLogic.UpdateTicket(ticket);

            // Assert
            _ticketDal.Verify(x => x.UpdateTicket(ticket), Times.Once);
        }

        [Fact]
        public void TestDeleteTicket()
        {
            // Arrange
            int ticketId = 1;
            _ticketDal.Setup(x => x.DeleteTicket(ticketId));

            // Act
            _TicketLogic.DeleteTicket(ticketId);

            // Assert
            _ticketDal.Verify(x => x.DeleteTicket(ticketId), Times.Once);
        }

        [Fact]
        public void TestGetTicket()
        {
            // Arrange
            var ticket = GetSampleTicket();
            var comments = GetSampleComments();
            var device = GetSampleDevice();
            var employee = GetSampleEmployee();
            var employees = GetSampleEmployees();
            var client = GetSampleClient();

            _ticketDal.Setup(x => x.GetTicket(ticket.TicketId)).Returns(ticket);
            _commentDal.Setup(x => x.GetComments(ticket.TicketId)).Returns(comments);
            _deviceDal.Setup(x => x.GetDevice(ticket.DeviceId)).Returns(device);
            _employeeDal.Setup(x => x.GetEmployee(ticket.ResponsibleEmployee)).Returns(employee);
            _employeeDal.Setup(x => x.GetEmployees()).Returns(employees);
            _clientDal.Setup(x => x.GetClient(ticket.ClientId)).Returns(client);

            var expectedResult = ticket;

            var actualResult = _TicketLogic.GetTicket(ticket.TicketId);

            // Assert
            Assert.True(actualResult != null);
            Assert.IsType<Ticket>(actualResult);
        }
    }
}