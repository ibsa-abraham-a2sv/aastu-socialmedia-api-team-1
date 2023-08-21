using Microsoft.EntityFrameworkCore;
using SocialMediaApp.Application.Persistence.Contracts;
using SocialMediaApp.Domain;

namespace SocialMediaApp.Persistence.Repositories;

public class NotificationRepository : GenericRepository<Notification>, INotificationRepository
{
    private readonly SocialMediaAppDbContext _dbContext;
    public NotificationRepository(SocialMediaAppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<Notification> GetNotificationDetails(int userId, int id)
    {
        var user = await _dbContext.Users.FindAsync(userId);
        if (user != null)
        {
            var notification = await _dbContext.Notifications.FindAsync(id);
            if (notification != null)
            {
                return notification;
            }
        }
        return null;
    }

    public async Task<List<Notification>> GetNotifications(int userId)
    {
        var user = await _dbContext.Users.FindAsync(userId);
        if (user != null)
        {
            var notifications = await  _dbContext.Notifications.Where(n=>n.UserId == userId).ToListAsync();
            return notifications;
        }
        return null;
    }
}
