using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialMediaApp.Application.Exceptions;
using SocialMediaApp.Application.Persistence.Contracts;
using SocialMediaApp.Domain;

namespace SocialMediaApp.Persistence.Repositories;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    private readonly SocialMediaAppDbContext _dbContext;
    public UserRepository(SocialMediaAppDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public User? GetByEmail(string email)
    {
        throw new NotImplementedException();
    }

    public async Task<IReadOnlyList<User>> GetByNameAsync(string Name)
    {
        var users = _dbContext.Users.Where(u => u.Name.Contains(Name)).ToList() ?? throw new NotFoundException("${Name}", Name);
        return users;
    }

}
