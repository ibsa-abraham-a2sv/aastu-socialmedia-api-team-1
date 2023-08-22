using Microsoft.EntityFrameworkCore;
using SocialMediaApp.Application.Persistence.Contracts;
using SocialMediaApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.Persistence.Repositories;

public class CommentRepository : GenericRepository<Comment>, ICommentRepository
{
    private readonly SocialMediaAppDbContext _dbContext;
    public CommentRepository(SocialMediaAppDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<Comment> GetCommentById(int postId)
    {
        throw new NotImplementedException();
    }

    public Task<List<Comment>> GetCommentsByPostId(int postId)
    {
        throw new NotImplementedException();
    }
}
