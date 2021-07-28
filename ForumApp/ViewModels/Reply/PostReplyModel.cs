using System;

namespace ForumApp.ViewModels.Reply
{
    public class PostReplyModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public int UserRaiting { get; set; }
        public string ImageUrl { get; set; }
        public DateTime Created { get; set; }
        public string ReplyContent { get; set; }
        public int PostId { get; set; }

    }
}
