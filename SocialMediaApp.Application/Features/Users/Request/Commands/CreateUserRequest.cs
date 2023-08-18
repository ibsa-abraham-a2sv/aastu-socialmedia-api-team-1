using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SocialMediaApp.Application.DTOs.Users;
namespace SocialMediaApp.Application.Features.Users.Request.Commands;

public class CreateUserRequest:IRequest<int>
{
    public CreateUserDto CreateUserDto { get; set; } = null!;

}
