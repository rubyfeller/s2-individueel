using Autofac.Extras.Moq;
using LOGIC.DTO_s;
using LOGIC.Entities;
using LOGIC.Interfaces;
using LOGIC.TicketLogic;
using System;
using System.Collections.Generic;
using Xunit;

namespace UnitTests
{
    public class TicketTest
    {
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
                TicketSubject = "Test",
                TicketContent = "Test ticket",
                TicketCategory = (TicketDTO.TicketCategories)1,
                TicketPriority = (TicketDTO.TicketPriorities)2,
                TicketStatus = (TicketDTO.TicketStatuses)1,
                TicketLevel = (TicketDTO.TicketLevels)1,
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

        [Fact]
        public void TestGetTickets()
        {
            // Arrange
            using var mock = AutoMock.GetLoose();
            mock.Mock<ITicketDal>().Setup(x => x.GetTickets()).Returns(GetSampleTickets);

            var logicMock = mock.Create<TicketLogic>();

            var expectedResult = GetSampleTickets();

            var actualResult = logicMock.GetTickets();

            // Assert
            Assert.True(actualResult != null);

            for (int i = 0; i < expectedResult.Count; i++)
            {
                Assert.Equal(expectedResult[i].TicketContent, actualResult[i].TicketContent);
            }
        }

        [Fact]
        public void TestAddTicket()
        {
            // Arrange
            using var mock = AutoMock.GetLoose();
            var ticket = new TicketDTO
            {
                TicketId = 1,
                TicketSubject = "Test",
                TicketContent = "Test ticket",
                TicketCategory = (TicketDTO.TicketCategories)1,
                TicketPriority = (TicketDTO.TicketPriorities)2,
                TicketStatus = (TicketDTO.TicketStatuses)1,
                TicketLevel = (TicketDTO.TicketLevels)1,
                CreatedDateTime = DateTime.Now,
            };

            mock.Mock<ITicketDal>().Setup(x => x.AddTicket(ticket));
            var logicMock = mock.Create<TicketLogic>();

            // Act
            logicMock.AddTicket(ticket);

            // Assert
            mock.Mock<ITicketDal>().Verify(x => x.AddTicket(ticket));
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

            mock.Mock<ITicketDal>().Setup(x => x.UpdateTicket(ticket));
            var logicMock = mock.Create<TicketLogic>();

            // Act
            logicMock.UpdateTicket(ticket);

            // Assert
            mock.Mock<ITicketDal>().Verify(x => x.UpdateTicket(ticket));
        }

        [Fact]
        public void TestDeleteTicket()
        {
            // Arrange
            using var mock = AutoMock.GetLoose();
            int ticketId = 1;
            mock.Mock<ITicketDal>().Setup(x => x.DeleteTicket(ticketId));
            var logicMock = mock.Create<TicketLogic>();

            // Act
            logicMock.DeleteTicket(ticketId);

            // Assert
            mock.Mock<ITicketDal>().Verify(x => x.DeleteTicket(ticketId));
        }
        [Fact]
        public void TestGetTicket()
        {
            // Arrange
            using var mock = AutoMock.GetLoose();
            var ticket = GetSampleTicket();
            mock.Mock<ITicketDal>().Setup(x => x.GetTicket(ticket.TicketId)).Returns(GetSampleTicket);
            mock.Mock<ICommentDal>().Setup(x => x.GetComments(ticket.TicketId)).Returns(GetSampleComments);

            var logicMock = mock.Create<TicketLogic>();

            var expectedResult = GetSampleTicket();

            var actualResult = logicMock.GetTicket(ticket.TicketId);

            // Assert
            Assert.True(actualResult != null);
            Assert.IsType<Ticket>(actualResult);
            Assert.Equal(expectedResult.TicketContent, actualResult.TicketContent);
        }
    }
}