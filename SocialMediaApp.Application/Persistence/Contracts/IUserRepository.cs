﻿using SocialMediaApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.Application.Persistence.Contracts;
public interface IUserRepository:IGenericRepository<User>
{

    Task<IReadOnlyList<User>> GetByNameAsync(string Name); 

}
