using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SocialMediaApp.Domain;
using SocialMediaApp.Application.Persistence.Contracts;
using Moq;

namespace test.UnitTest.CommentTest.Mocks
{
    public static class MockCommentRepository
    {
        public static Mock<ICommentRepository> GetCommentRepository()
        {
            var comments = new List<Comment>
            {
               new Comment
               {
                    Id = 1,
                    UserId = 2,
                    PostId = 1,
                    Text = "I like it :)" 
               },

               new Comment
               {
                    Id = 2,
                    UserId = 3,
                    PostId = 1,
                    Text = "Wow amazing :)" 
               }

            };

            var mockRepo = new Mock<ICommentRepository>();

            mockRepo.Setup(r => r.GetAll()).ReturnsAsync(comments);

            mockRepo.Setup(r => r.Add(It.IsAny<Comment>())).ReturnsAsync((Comment comment) => {
                comments.Add(comment);
                return comment;
            });

            return mockRepo;

        }
    }
}