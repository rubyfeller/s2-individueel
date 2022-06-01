using Autofac.Extras.Moq;
using LOGIC;
using LOGIC.DTO_s;
using LOGIC.Entities;
using LOGIC.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace UnitTests
{
    public class CommentTest
    {
        private static List<CommentDTO> GetSampleComments()
        {
            List<CommentDTO> comments = new List<CommentDTO>
            {
                new CommentDTO
                {
                    CommentId = 48,
                    CommentContent = "Test comment",
                    CreatedDateTime = DateTime.Now,
                    TicketId = 1065,
                },

                new CommentDTO
                {
                    CommentId = 49,
                    CommentContent = "Test comment 2",
                    CreatedDateTime = DateTime.Now,
                    TicketId = 1065,
                },
            };
            return comments;
        }

        [Fact]
        public void TestIsCommentDTOTransferedToLogicObject()
        {
            // Arrange
            using var mock = AutoMock.GetLoose();
            mock.Mock<ICommentDal>().Setup(x => x.GetComments(0)).Returns(GetSampleComments());

            var logicInstance = mock.Create<CommentLogic>();

            var expectedResult = GetSampleComments();

            // Act
            var actualResult = logicInstance.GetComments(0);

            // Assert
            Assert.True(actualResult != null);
            Assert.IsType<Comment>(actualResult[0]);
            Assert.Equal(2, expectedResult.Count);
        }

        [Fact]
        public void TestGetComments()
        {
            // Arrange
            using var mock = AutoMock.GetLoose();
            var logicMock = mock.Create<CommentLogic>();
            var expectedResult = GetSampleComments();

            foreach (var comment in GetSampleComments())
            {
                mock.Mock<ICommentDal>().Setup(x => x.GetComments(comment.TicketId)).Returns(GetSampleComments());
                var actualResult = logicMock.GetComments(comment.TicketId);

                // Assert
                Assert.True(actualResult != null);

                for (int i = 0; i < expectedResult.Count; i++)
                {
                    Assert.Equal(expectedResult[i].CommentId, actualResult[i].CommentId);
                }
            }
        }

        [Fact]
        public void TestAddComment()
        {
            // Arrange
            using var mock = AutoMock.GetLoose();
            var comment = new CommentDTO
            {
                CommentId = 1054,
                CommentContent = "Nieuwe comment",
                CreatedDateTime = DateTime.Now,
                TicketId = 1065,
            };

            mock.Mock<ICommentDal>().Setup(x => x.AddComment(comment));
            var logicMock = mock.Create<ICommentDal>();

            // Act
            logicMock.AddComment(comment);

            // Assert
            mock.Mock<ICommentDal>().Verify(x => x.AddComment(comment), Times.Once);
        }

        [Fact]
        public void TestDeleteComment()
        {
            // Arrange
            using var mock = AutoMock.GetLoose();
            int commentId = 1054;
            mock.Mock<ICommentDal>().Setup(x => x.DeleteComment(commentId));
            var logicMock = mock.Create<CommentLogic>();

            // Act
            logicMock.DeleteComment(commentId);

            // Assert
            mock.Mock<ICommentDal>().Verify(x => x.DeleteComment(commentId), Times.Once);
        }
    }
}