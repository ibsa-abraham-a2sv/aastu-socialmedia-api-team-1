using SocialMediaApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.Application.Persistence.Contracts;


public interface ILikeRepository : IGenericRepository<Like>

{
    Task<Like> GetLike (int UserId, int PostId);

    bool LikeExists(int UserId, int PostId);


}