using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialMediaApp.Domain.Common;

namespace SocialMediaApp.Domain;

public class User: BaseEntity
{
    public string Name { get; set; }
    public string email { get; set; }
    public string password { get; set; }
<<<<<<< HEAD
    public List<Follow>? Followers { get; set; }
    public List<Post>? Post { get; set; }
    public string? Bio { get; set; }
=======
    public List<Follow> Followers { get; set; }
    public List<Post> Post { get; set; }
    public List<Notification> Notifications { get; set; }
    public string Bio { get; set; }
>>>>>>> 17dd30b490fae7aebec7063d4b3fc8dca9301e4b

}
