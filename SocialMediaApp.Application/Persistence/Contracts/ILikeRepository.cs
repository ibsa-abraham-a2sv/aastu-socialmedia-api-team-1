using SocialMediaApp.Application.DTOs.Likes;
using SocialMediaApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.Application.Persistence.Contracts;

public interface ILikeRepository : IGenericRepository<Like>
{
    bool LikeExists(int UserId, int PostId);
    
    // Task<List<Like>> GetLikesByPostId(int userId, int Id);
    Task<List<Like>> GetLikesById(int postId);

}
