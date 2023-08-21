﻿using SocialMediaApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.Domain;

public class Post:BaseEntity
{
    public string? Title { get; set; }   
    public string? Content { get; set; }
    public List<Comment>? Comments { get; set; }
    public List<Like>? Like { get; set; }
    public List<String>? HashTag { get; set; }



}
