﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.Domain;

public class Notification
{
    public string Content { get; set; } = "";
    public int UserId { get; set; }
    public bool IsRead { get; set; }
}
