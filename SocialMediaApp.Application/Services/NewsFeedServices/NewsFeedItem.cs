using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaApp.Application.Services.NewsFeedServices
{
    public class NewsFeedItem
    {
        public string Title { get; set; } = "";
        public string Content { get; set; } = "";
        public string Author { get; set; } = "";

        public DateTime CreatedDate { get; set; }
    }
}
