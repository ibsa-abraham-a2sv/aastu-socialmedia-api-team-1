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

    public async Task<List<Like>> GetLikesById(Guid postId)
    {
        var likes = await _dbContext.Likes.Where(L=>L.PostId == postId).ToListAsync();
        return likes;
    }

    public bool LikeExists(Guid UserId, Guid PostId)
    {
        var user = _dbContext.Posts.Where(n => n.UserId == UserId && n.Id == PostId).FirstOrDefault();
        return user != null;
    }

    public async Task<List<Like>> GetLikesByPostId(Guid userId, Guid PostId)
    {
        var likes = await _dbContext.Likes.Where(l => l.PostId == PostId).ToListAsync();
        return likes;
    }
}
