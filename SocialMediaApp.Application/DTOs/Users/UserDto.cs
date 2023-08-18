using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.Application.DTOs.Users;

public class UserDto: BaseDto
{
    public string Name { get; set; }
    public string email { get; set; }
    public string password { get; set; }
    public List<UserDto> Followers { get; set; }
    public List<PostDto> Post { get; set; }
    public string Bio { get; set; }
}
