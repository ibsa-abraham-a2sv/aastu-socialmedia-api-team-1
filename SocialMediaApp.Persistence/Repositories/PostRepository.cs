using Microsoft.EntityFrameworkCore;
using SocialMediaApp.Application.Persistence.Contracts;
using SocialMediaApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.Persistence.Repositories;

public class PostRepository : GenericRepository<Post>, IPostRepository
{
    private readonly SocialMediaAppDbContext _dbContext;
    public PostRepository(SocialMediaAppDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<Post> GetPostDetails(Guid userId, Guid id)
    {
        var user = await _dbContext.Users.FindAsync(userId);
        if (user != null)
        {
            var post = await _dbContext.Posts.FindAsync(id);
            if (post != null)
            {
                return post;
            }
        }
        return null;
    }

    public async Task<List<Post>> GetPosts(Guid userId)
    {
        var user = await _dbContext.Users.FindAsync(userId);
        if (user != null)
        {
            var posts = await _dbContext.Posts.Where(n => n.UserId == userId).ToListAsync();
            return posts;
        }
        return null;
    }

    public List<Post> GetPostForNewsFeed()
    {
        return _dbContext.Posts
            .Include(p => p.UserId)
            .OrderByDescending(p => p.CreatedDate) 
            .ToList();
    }

}
