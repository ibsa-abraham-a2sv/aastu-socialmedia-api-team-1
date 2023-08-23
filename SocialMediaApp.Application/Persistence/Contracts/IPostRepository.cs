using SocialMediaApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.Application.Persistence.Contracts;


public interface IPostRepository:IGenericRepository<Post>

{
    Task<List<Post>> GetPosts(int userId);
    Task<Post> GetPostDetails(int userId, int id);
}
