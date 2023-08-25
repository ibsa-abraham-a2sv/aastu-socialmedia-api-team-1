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

    Task<List<Like>> GetLikesById(Guid PostId);
    bool LikeExists(Guid UserId, Guid PostId);

}
