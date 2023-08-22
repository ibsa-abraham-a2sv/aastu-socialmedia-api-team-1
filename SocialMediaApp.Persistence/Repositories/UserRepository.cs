using SocialMediaApp.Application.Persistence.Contracts;
using SocialMediaApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.Persistence.Repositories;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    private readonly SocialMediaAppDbContext _dbContext;
    public UserRepository(SocialMediaAppDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
}
