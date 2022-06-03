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
        private readonly Mock<ICommentDal> _commentDal = new Mock<ICommentDal>();

        private readonly CommentLogic _CommentLogic;

        public CommentTest()
        {
            _CommentLogic = new CommentLogic(_commentDal.Object);
        }

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
            _commentDal.Setup(x => x.GetComments(0)).Returns(GetSampleComments());

            var expectedResult = GetSampleComments();

            // Act
            var actualResult = _CommentLogic.GetComments(0);

            // Assert
            Assert.True(actualResult != null);
            Assert.IsType<Comment>(actualResult[0]);
            for (int i = 0; i < expectedResult.Count; i++)
            {
                Assert.Equal(expectedResult[i].CommentId, actualResult[i].CommentId);
                Assert.Equal(expectedResult[i].CommentContent, actualResult[i].CommentContent);
                Assert.Equal(expectedResult[i].TicketId, actualResult[i].TicketId);
            }
            Assert.Equal(2, expectedResult.Count);
        }

        [Fact]
        public void TestGetComments()
        {
            // Arrange
            var expectedResult = GetSampleComments();

            foreach (var comment in GetSampleComments())
            {
                _commentDal.Setup(x => x.GetComments(comment.TicketId)).Returns(GetSampleComments);

                var actualResult = _CommentLogic.GetComments(comment.TicketId);

                // Assert
                Assert.True(actualResult != null);

                for (int i = 0; i < expectedResult.Count; i++)
                {
                    Assert.Equal(expectedResult[i].CommentId, actualResult[i].CommentId);
                    Assert.Equal(expectedResult[i].CommentContent, actualResult[i].CommentContent);
                    Assert.Equal(expectedResult[i].TicketId, actualResult[i].TicketId);
                }
            }
        }

        [Fact]
        public void TestAddComment()
        {
            // Arrange
            var comment = new CommentDTO
            {
                CommentId = 1054,
                CommentContent = "Nieuwe comment",
                CreatedDateTime = DateTime.Now,
                TicketId = 1065,
            };

            _commentDal.Setup(x => x.AddComment(comment));

            // Act
            _CommentLogic.AddComment(comment);

            // Assert
            _commentDal.Verify(x => x.AddComment(comment), Times.Once);
        }

        [Fact]
        public void TestDeleteComment()
        {
            // Arrange
            int commentId = 1054;
            _commentDal.Setup(x => x.DeleteComment(commentId));

            // Act
            _CommentLogic.DeleteComment(commentId);

            // Assert
            _commentDal.Verify(x => x.DeleteComment(commentId), Times.Once);
        }
    }
}