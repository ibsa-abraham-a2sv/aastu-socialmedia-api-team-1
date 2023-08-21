using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialMediaApp.Application.Exceptions;
using SocialMediaApp.Application.Persistence.Contracts;
using SocialMediaApp.Domain;

namespace SocialMediaApp.Persistence.Repositories;

public class FollowRepository : GenericRepository<Follow>, IFollowRepository
{
    private readonly SocialMediaAppDbContext _context;

    public FollowRepository(SocialMediaAppDbContext dbContext):base(dbContext)
    {
        _context = dbContext;
    }


    public  List<Follow>  GetFollowersAsync(int userId,int id)
    {
        var followers  = _context.Follows.Where(u => u.FollowerId == userId).ToList() ?? throw new NotFoundException("${userId}", id);
        return followers;
        
        }

    public List<Follow> GetFollowingsAsync(int userId, int id)
    {
        var followings =  _context.Follows.Where(u => u.FollowingId == userId).ToList() ?? throw new NotFoundException("${userId}", id);
        
        return followings;

    }

        
}
