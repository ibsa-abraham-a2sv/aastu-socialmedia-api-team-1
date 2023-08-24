using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialMediaApp.Domain.Common;

namespace SocialMediaApp.Domain;

public class Follow : BaseEntity
{
    public int CurrentUser { get; set; }
    public int ToBeFollowed { get; set; }
}

