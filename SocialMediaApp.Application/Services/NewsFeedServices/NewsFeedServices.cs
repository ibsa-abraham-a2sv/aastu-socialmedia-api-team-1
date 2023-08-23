using SocialMediaApp.Application.Persistence.Contracts;
using SocialMediaApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.Application.Services.NewsFeedServices
{
    public class NewsFeedServices
    {
        private readonly IPostRepository _postRepository;
        private readonly IUserRepository _userRepository;

        public NewsFeedServices(IPostRepository postRepository, IUserRepository userRepository)
        {
            _postRepository = postRepository;
            _userRepository = userRepository;

        }

        public List<NewsFeedItem> GetNewsFeed()
        {
            var posts = _postRepository.GetPostForNewsFeed();
            var newsFeedItems = new List<NewsFeedItem>();
            foreach (var post in posts)
            {
                var user = _userRepository.GetById(post.UserId).Result;

                var newsFeedItem = new NewsFeedItem
                {
                    Title = post.Title,
                    Content = post.Content,
                    Author = user.Name,
                    CreatedDate = post.CreatedDate
                };
                newsFeedItems.Add(newsFeedItem);
            }

            return newsFeedItems;
        }



    }
}
