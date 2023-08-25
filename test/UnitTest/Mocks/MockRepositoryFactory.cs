using System.Runtime.InteropServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SocialMediaApp.Domain;
using SocialMediaApp.Application.Persistence.Contracts;
using Moq;

namespace test.UnitTest.CommentTest.Mocks
{
    public static class MockRepositoryFactory
    {
        public static Mock<ICommentRepository> GetCommentRepository()
        {
            var comments = new List<Comment>
            {
               new Comment
               {
                    Id = Guid.Parse("0b8b1a9d-2383-424c-9098-eb1b89e2efc8"),
                    UserId = Guid.Parse("0b8b1a9d-2383-424c-9098-eb1b89e2efc8"),
                    PostId = Guid.Parse("0b8b1a9d-2383-424c-9098-eb1b89e2efc8"),
                    Text = "I like it :)" 
               },

               new Comment
               {
                   Id = Guid.Parse("0b8b1a9d-2383-424c-9098-eb1b89e2efc8"),
                    UserId = Guid.Parse("0b8b1a9d-2383-424c-9098-eb1b89e2efc8"),
                    PostId = Guid.Parse("0b8b1a9d-2383-424c-9098-eb1b89e2efc8"),
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

        public static Mock<IPostRepository> GetPostRepository()
        {
            
            var posts = new List<Post>
            {
                new Post
                {
                    UserId = Guid.Parse("0b8b1a9d-2383-424c-9098-eb1b89e2efc8"),
                    Title = "Gamming Pc",
                    Content = "High performance, have a graphic card",
                },
                new Post
                {
                  UserId = Guid.Parse("0b8b1a9d-2383-424c-9098-eb1b89e2efc8"),
                  Title = "Desktop Pc",
                  Content = "low performance, have no  graphic card",
                }
            };

            var mockRepo = new Mock<IPostRepository>();

                mockRepo.Setup(r => r.GetAll()).ReturnsAsync(posts);

                mockRepo.Setup(r => r.Add(It.IsAny<Post>())).ReturnsAsync((Post post) => {
                    posts.Add(post);
                    return post;
                });

                return mockRepo;

        }




         public static Mock<IUserRepository> GetUserRepository()
        {
            /*p    public string Name { get; set; }
    public string email { get; set; }
    public string password { get; set; }*/
            var users = new List<User>
            {
                new User
                {
                    Name = "Jima Dube",
                    email = "jimd@gmail.com",
                    password = "High123@",
                },
                new User
                {
                    Name = "xBebe",
                    email = "bebe@gmail.com",
                    password = "bebe123#",
                }
            };

            var mockRepo = new Mock<IUserRepository>();

                mockRepo.Setup(r => r.GetAll()).ReturnsAsync(users);

                mockRepo.Setup(r => r.Add(It.IsAny<User>())).ReturnsAsync((User user) => {
                    users.Add(user);
                    return user;
                });
               
                mockRepo.Setup(r => r.Update(It.IsAny<User>()));
                
                mockRepo.Setup(r => r.GetById(It.IsAny<Guid>())).ReturnsAsync(new User());
                return mockRepo;

        }
    }
}