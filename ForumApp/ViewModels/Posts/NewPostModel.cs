using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumApp.ViewModels.Posts
{
    public class NewPostModel
    {
        public string ForumName { get; set; }
        public int ForumId { get; set; }
        public string Content { get; set; }

        public string UserName { get; set; }
        public string FormImage { get; set; }

    }
}
