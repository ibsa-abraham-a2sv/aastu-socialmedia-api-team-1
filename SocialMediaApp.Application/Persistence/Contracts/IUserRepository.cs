using SocialMediaApp.Domain;

namespace SocialMediaApp.Application.Persistence.Contracts;
public interface IUserRepository:IGenericRepository<User>
{
    Task<IReadOnlyList<User>> GetByNameAsync(string Name); 
}
