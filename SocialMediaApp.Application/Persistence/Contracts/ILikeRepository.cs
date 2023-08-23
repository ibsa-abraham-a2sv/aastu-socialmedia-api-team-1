﻿using SocialMediaApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.Application.Persistence.Contracts;


public interface ILikeRepository : IGenericRepository<Like>

{
    Task<List<Like>> GetLikesById(int postId);
    bool LikeExists(int UserId, int PostId);

}