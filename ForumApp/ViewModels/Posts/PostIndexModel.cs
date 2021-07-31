using ForumApp.ViewModels.Reply;
using System;
using System.Collections.Generic;

namespace ForumApp.ViewModels.Posts
{
    public class PostIndexModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string ImageUrl { get; set; }
        public int UserRaiting { get; set; }
        public int ForumId { get; set; }
        public string ForumName { get; set; }
        public DateTime Created { get; set; }
        public string PostContent { get; set; }
        public bool IsAdmin { get; set; }

        public IEnumerable<PostReplyModel> Replies { get; set; }

    }
}
