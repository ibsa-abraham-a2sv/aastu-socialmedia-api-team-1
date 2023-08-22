using Microsoft.EntityFrameworkCore;
using SocialMediaApp.Application.Persistence.Contracts;
using SocialMediaApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.Persistence.Repositories;

public class LikeRepository: GenericRepository<Like>, ILikeRepository
{
    private readonly SocialMediaAppDbContext _dbContext;
    public LikeRepository(SocialMediaAppDbContext dbContext):base (dbContext)
    {
        _dbContext = dbContext;
        
    }

    public  bool LikeExists(int UserId, int PostId)
    {
        var user = _dbContext.Likes.Where(n => n.UserId == UserId && n.PostId == PostId).FirstOrDefault();
        throw new NotImplementedException();
    }
}
